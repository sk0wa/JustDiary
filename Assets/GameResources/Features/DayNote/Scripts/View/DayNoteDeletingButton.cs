namespace JustDiary.DayNote
{
    using UnityEngine;

    using skowa.EDebug;

    /// <summary>
    /// Кнопка удаления дневной заметки
    /// </summary>
    public class DayNoteDeletingButton : AbstractDayNoteButton
    {
        [SerializeField] protected DayNoteListControllerContainer container = default;

        public override void OnButtonClicked()
        {
            if (HandleError())
            {
                return;
            }

            container.Instance.DeleteNote(note.Id);
        }

        protected override bool HandleError()
        {
            if (base.HandleError())
            {
                return true;
            }

            if (container == null)
            {
                EDebug.LogError(this.GetType().Name, $"Переменная {nameof(container)} была null.", this);

                return true;
            }

            if (container.Instance == null)
            {
                EDebug.LogError(this.GetType().Name, $"Экземпляр в контейнере {nameof(container)} был null.", this);

                return true;
            }

            return false;
        }
    }
}
