namespace JustDiary.DayNoteSearching
{
    using UnityEngine;

    using skowa.EDebug;
    using skowa.Data.ID;
    using skowa.Data.Container;
    using skowa.Data.PlayerPrefs;

    using JustDiary.DayNote;

    /// <summary>
    /// Рекордер идентификатора контроллера списка дневных заметок
    /// </summary>
    public class DayNoteListIdRecorder : AbstractGenericContainerProvider<DayNoteListController>
    {
        /// <summary>
        /// Разделитель между записями
        /// </summary>
        public const string SEPARATOR = " ";

        /// <summary>
        /// Запись
        /// </summary>
        public string Record
        {
            get
            {
                if (record == string.Empty && id != null)
                {
                    record = PlayerPrefsHelper.GetString(id.Id);
                }

                return record;
            }
            protected set
            {
                if (id == null)
                {
                    EDebug.LogError(this.GetType().Name, $"Идентификатор {nameof(id)} был null.", this);

                    return;
                }

                record = value;
                PlayerPrefsHelper.SetString(id.Id, value);
            }
        }
        protected string record = string.Empty;

        [SerializeField] protected ID id = default;

        protected override void OnInstanceChanged()
        {
            Unsubscribe();

            base.OnInstanceChanged();
        }

        protected override void UpdateAction()
        {
            Unsubscribe();
            Subscribe();

            OnNotesChanged();
        }

        protected virtual void Subscribe()
        {
            if (instance != null)
            {
                instance.onNotesChanged += OnNotesChanged;
            }
        }

        protected virtual void Unsubscribe()
        {
            if (instance != null)
            {
                instance.onNotesChanged -= OnNotesChanged;
            }
        }

        protected virtual void OnNotesChanged()
        {
            if (instance.Notes.Count > 0)
            {
                if (!Record.Contains(instance.ListId))
                {
                    Record += instance.ListId + SEPARATOR;
                }
            }
            else
            {
                if (Record.Contains(instance.ListId))
                {
                    Record = Record.Replace(instance.ListId + SEPARATOR, string.Empty);
                }
            }
        }
    }
}
