namespace JustDiary.DayNote
{
    using UnityEngine;

    using skowa.UI.AbstractView;

    /// <summary>
    /// Кнопка добавления дневной заметки
    /// </summary>
    public class DayNoteAddingButton : AbstractButton
    {
        [SerializeField] protected DayNoteListController controller = default;

        [SerializeField] protected string defaultCaption = "Caption";
        [SerializeField] protected string defaultText = "Text";

        public override void OnButtonClicked()
        {
            if (controller != null)
            {
                controller.AddNote(defaultCaption, defaultText);
            }
        }
    }
}
