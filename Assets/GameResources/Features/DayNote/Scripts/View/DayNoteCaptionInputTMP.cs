namespace JustDiary.DayNote
{
    using UnityEngine;

    using skowa.UI.AbstractView;

    /// <summary>
    /// TMP поле ввода заголовка дневной заметки
    /// </summary>
    public class DayNoteCaptionInputTMP : AbstractInputFieldTMP
    {
        [SerializeField] protected DayNoteController controller = default;

        protected override void OnEnable()
        {
            base.OnEnable();

            if (controller != null && controller.DayNote != null)
            {
                InputField.SetTextWithoutNotify(controller.DayNote.Caption);
            }
        }

        protected override void OnEndEdit(string _value)
        {
            if (controller != null)
            {
                controller.SetCaption(_value);
            }
        }
    }
}
