namespace JustDiary.DayNote
{
    using System.Collections.Generic;

    using UnityEngine;

    public class DayNoteButtonList : MonoBehaviour
    {
        /// <summary>
        /// Список кнопок дневных заметок
        /// </summary>
        public IReadOnlyList<AbstractDayNoteButton> Buttons => buttons;
        [SerializeField] protected List<AbstractDayNoteButton> buttons = new List<AbstractDayNoteButton>();
    }
}
