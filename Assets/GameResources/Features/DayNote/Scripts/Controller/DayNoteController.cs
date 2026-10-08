namespace JustDiary.DayNote
{
    using UnityEngine;

    using skowa.EDebug;

    /// <summary>
    /// Контроллер дневной заметки
    /// </summary>
    public class DayNoteController : BaseDayNoteProvider
    {
        /// <summary>
        /// Задать заголовок
        /// </summary>
        /// <param name="_caption">Заголовок</param>
        public void SetCaption(string _caption)
        {
            if (HandleError())
            {
                return;
            }

            DayNote.SetCaption(_caption);
        }

        /// <summary>
        /// Задать текст
        /// </summary>
        /// <param name="_text">Текст</param>
        public void SetText(string _text)
        {
            if (HandleError())
            {
                return;
            }

            DayNote.SetText(_text);
        }

        protected virtual bool HandleError()
        {
            if (DayNote == null)
            {
                EDebug.LogError(this.GetType().Name, $"Переменная {nameof(DayNote)} была null.", this);

                return true;
            }

            return false;
        }
    }
}
