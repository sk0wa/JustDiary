namespace JustDiary.DayNote
{
    using System.Collections.Generic;

    using UnityEngine;

    using skowa.EDebug;

    /// <summary>
    /// Контроллер кнопок дневных заметок
    /// </summary>
    public class DayNoteButtonController : MonoBehaviour
    {
        [SerializeField] protected DayNoteListController controller = default;

        [SerializeField] protected DayNoteButtonList prefabButtonList = default;

        protected List<DayNoteButtonList> buttons = new List<DayNoteButtonList>();

        protected virtual void OnEnable()
        {
            if (HandleError())
            {
                return;
            }

            controller.onNotesChanged += ProcessButtons;
            ProcessButtons();
        }

        protected virtual void OnDisable()
        {
            if (HandleError())
            {
                return;
            }

            controller.onNotesChanged -= ProcessButtons;
        }

        protected virtual void ProcessButtons()
        {
            if (HandleError())
            {
                return;
            }

            int _i = 0;

            for (; _i < controller.Notes.Count; _i++)
            {
                if (buttons.Count < _i + 1)
                {
                    SpawnButtons(controller.Notes[_i]);

                    continue;
                }

                foreach (AbstractDayNoteButton _btn in buttons[_i].Buttons)
                {
                    if (_btn != null)
                    {
                        _btn.Init(controller.Notes[_i]);
                    }
                }

                buttons[_i].gameObject.SetActive(true);
            }

            for (; _i < buttons.Count; _i++)
            {
                foreach (AbstractDayNoteButton _btn in buttons[_i].Buttons)
                {
                    if (_btn != null)
                    {
                        _btn.Init(null);
                    }
                }

                buttons[_i].gameObject.SetActive(false);
            }
        }

        protected virtual void SpawnButtons(DayNote _note)
        {
            DayNoteButtonList _list = Instantiate(prefabButtonList, transform);

            foreach (AbstractDayNoteButton _btn in _list.Buttons)
            {
                if (_btn != null)
                {
                    _btn.Init(_note);
                }
            }

            buttons.Add(_list);
        }

        protected virtual bool HandleError()
        {
            if (controller == null)
            {
                EDebug.LogError(this.GetType().Name, $"Переменная {nameof(controller)} была null.", this);

                return true;
            }

            if (controller == null)
            {
                EDebug.LogError(this.GetType().Name, $"Переменная {nameof(prefabButtonList)} была null.", this);

                return true;
            }

            return false;
        }
    }
}
