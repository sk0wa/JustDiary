namespace JustDiary.DayNoteSearching
{
    using System.Collections.Generic;

    using UnityEngine;

    using skowa.EDebug;

    using JustDiary.DayNote;
    using skowa.Data.ValueContainer;

    /// <summary>
    /// Контроллер кнопок дневных заметок, полученных серчером
    /// </summary>
    public class DayNoteSearcherButtonController : MonoBehaviour
    {
        [SerializeField] protected DayNoteSearcher searcher = default;
        [SerializeField] protected AbstractDayNoteButton buttonPrefab = default;

        [SerializeField] protected StringValueContainer searchStringContainer = default;

        protected List<AbstractDayNoteButton> buttons = new List<AbstractDayNoteButton>();

        protected virtual void OnEnable()
        {
            if (HandleError())
            {
                return;
            }

            searchStringContainer.onValueChanged += InitButtons;
        }

        protected virtual void OnDisable()
        {
            if (HandleError())
            {
                return;
            }

            searchStringContainer.onValueChanged -= InitButtons;
            HideAll();
        }

        /// <summary>
        /// Инициализировать кнопки
        /// </summary>
        public virtual void InitButtons()
        {
            if (HandleError())
            {
                return;
            }

            List<DayNote> _notes = searcher.Search(searchStringContainer.Value);

            if (_notes.Count == 0)
            {
                HideAll();
            }

            int _i = 0;

            for (; _i < _notes.Count; _i++)
            {
                if (buttons.Count < _i + 1)
                {
                    SpawnButton(_notes[_i]);

                    continue;
                }

                buttons[_i].Init(_notes[_i]);
                buttons[_i].gameObject.SetActive(true);
            }

            for (; _i < buttons.Count; _i++)
            {
                buttons[_i].gameObject.SetActive(false);
            }
        }

        protected virtual void SpawnButton(DayNote _note)
        {
            AbstractDayNoteButton _btn = Instantiate(buttonPrefab, transform);
            _btn.Init(_note);

            buttons.Add(_btn);
        }

        protected virtual void HideAll()
        {
            foreach (AbstractDayNoteButton _btn in buttons)
            {
                _btn.gameObject.SetActive(false);
            }
        }

        protected virtual bool HandleError()
        {
            if (searcher == null)
            {
                EDebug.LogError(this.GetType().Name, $"Переменная {nameof(searcher)} была null.");

                return true;
            }

            if (buttonPrefab == null)
            {
                EDebug.LogError(this.GetType().Name, $"Переменная {nameof(buttonPrefab)} была null.");

                return true;
            }

            if (searchStringContainer == null)
            {
                EDebug.LogError(this.GetType().Name, $"Переменная {nameof(searchStringContainer)} была null.");

                return true;
            }

            return false;
        }
    }
}
