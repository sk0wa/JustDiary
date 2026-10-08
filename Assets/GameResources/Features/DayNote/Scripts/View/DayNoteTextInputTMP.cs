namespace JustDiary.DayNote
{
    using UnityEngine;

    using skowa.UI.AbstractView;

    /// <summary>
    /// TMP поле ввода текста дневной заметки
    /// </summary>
    public class DayNoteTextInputTMP : AbstractInputFieldTMP
    {
        [SerializeField] protected DayNoteController controller = default;

        protected override void OnEnable()
        {
            base.OnEnable();

            if (controller != null && controller.DayNote != null)
            {
                InputField.SetTextWithoutNotify(controller.DayNote.Text);
            }
        }

        protected override void OnEndEdit(string _value)
        {
            if (controller != null)
            {
                controller.SetText(_value);
            }
        }
    }
}
