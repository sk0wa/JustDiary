namespace JustDiary.DayNote
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using UnityEngine;

    using skowa.EDebug;
    using skowa.Data.PlayerPrefs;
    using skowa.Data.ValueContainer;

    /// <summary>
    /// Контроллер списка дневных заметок
    /// </summary>
    public class DayNoteListController : MonoBehaviour
    {
        /// <summary>
        /// Разделитель между индексами
        /// </summary>
        public const string SEPARATOR = " ";
        
        /// <summary>
        /// Максимальное количество заметок на один день
        /// </summary>
        public const int DAY_NOTES_LIMIT_COUNT = 20;

        /// <summary>
        /// Событие изменения заметок на дату
        /// </summary>
        public event Action onNotesChanged = delegate { };

        /// <summary>
        /// Идентификатор списка
        /// </summary>
        public string ListId => date != null ? date.Value.ToString(DayNote.DATE_FMT) : string.Empty;

        /// <summary>
        /// Заметки на дату
        /// </summary>
        public IReadOnlyList<DayNote> Notes => notes;
        protected List<DayNote> notes = new List<DayNote>();

        [SerializeField] protected DateTimeValueContainer date = default;
        [SerializeField] protected IntegerIncrementValueContainer increment = default;

        protected virtual void OnEnable()
        {
            onNotesChanged += ProcessNotesChanged;
            InitNotes();
        }

        protected virtual void OnDisable()
        {
            onNotesChanged -= ProcessNotesChanged;
        }

        /// <summary>
        /// Получить заметку
        /// </summary>
        /// <param name="_id">Идентификатор заметки</param>
        /// <returns>Заметка</returns>
        public virtual DayNote GetNote(string _id)
        {
            if (HandleError())
            {
                return null;
            }

            return notes.Find(_x => _x.Id == _id);
        }

        /// <summary>
        /// Добавить заметку
        /// </summary>
        /// <param name="_caption">Заголовок</param>
        /// <param name="_text">Текст</param>
        public virtual void AddNote(string _caption = "", string _text = "")
        {
            if (HandleError())
            {
                return;
            }

            if (notes.Count >= DAY_NOTES_LIMIT_COUNT)
            {
                EDebug.LogError(this.GetType().Name, $"Достигнуто максимальное количество заметок на день.", this);

                return;
            }

            // NOTE: ID = "дата_дня автоинкрментирующийся_индекс"
            DayNote _note = new DayNote($"{ListId} {increment.GetValue()}");

            if (_caption != "" || _text != "")
            {
                _note.SetCaption(_caption);
                _note.SetText(_text);
            }

            notes.Add(_note);

            OnNotesChanged();
        }

        /// <summary>
        /// Удалить заметку
        /// </summary>
        /// <param name="_id">Идентификатор заметки</param>
        public virtual void DeleteNote(string _id)
        {
            if (HandleError())
            {
                return;
            }

            int _idx = notes.FindIndex(_x => _x.Id == _id);

            if (_idx != -1)
            {
                notes[_idx].Delete();
                notes.RemoveAt(_idx);

                OnNotesChanged();
            }
        }

        protected virtual void InitNotes()
        {
            if (HandleError())
            {
                return;
            }

            notes.Clear();

            string _idxsStr = PlayerPrefsHelper.GetString(ListId);
            List<string> _idxs = _idxsStr.Split(SEPARATOR, StringSplitOptions.RemoveEmptyEntries).ToList();

            foreach (string _idxStr in _idxs)
            {
                int _idx = 0;
                try
                {
                    _idx = int.Parse(_idxStr);
                }
                catch
                {
                    EDebug.LogError(this.GetType().Name, $"Не удалось преобразовать строку '{_idxStr}' в тип int.", this);

                    continue;
                }

                if (PlayerPrefsHelper.HasKey($"{ListId}{SEPARATOR}{_idx}"))
                {
                    string _noteStr = PlayerPrefsHelper.GetString($"{ListId} {_idx}");
                    DayNote _note = JsonUtility.FromJson<DayNote>(_noteStr);

                    notes.Add(_note);
                }
            }

            OnNotesChanged();
        }

        protected virtual void ProcessNotesChanged()
        {
            if (HandleError())
            {
                return;
            }

            string _idxs = "";
            string _idx = "";
            foreach (DayNote _note in notes)
            {
                _idx = _note.Id.Substring(_note.Id.IndexOf(SEPARATOR) + 1);
                _idxs += SEPARATOR + _idx;
            }
            _idxs = _idxs.Length > 0 ? _idxs.Substring(1) : _idxs;

            if (!string.IsNullOrWhiteSpace(_idxs))
            {
                PlayerPrefsHelper.SetString(ListId, _idxs);
            }
            else
            {
                PlayerPrefsHelper.ClearKey(ListId);
            }
        }

        protected virtual void OnNotesChanged()
        {
            onNotesChanged();
        }

        protected virtual bool HandleError()
        {
            if (date == null)
            {
                EDebug.LogError(this.GetType().Name, $"Переменная {nameof(date)} была null.", this);

                return true;
            }

            if (increment == null)
            {
                EDebug.LogError(this.GetType().Name, $"Переменная {nameof(increment)} была null.", this);

                return true;
            }

            return false;
        }
    }
}
