namespace JustDiary.DayNote
{
    using UnityEngine;

    using skowa.EDebug;
    using skowa.UI.AbstractView;

    /// <summary>
    /// Абстрактная кнопка дневной заметки
    /// </summary>
    public abstract class AbstractDayNoteButton : AbstractButton
    {
        /// <summary>
        /// Ассоциирующаяся заметка с кнопкой
        /// </summary>
        public DayNote Note => note;
        protected DayNote note = default;

        /// <summary>
        /// Инициализировать
        /// </summary>
        /// <param name="_note">Экземпляр заметки</param>
        public virtual void Init(DayNote _note)
        {
            note = _note;
        }

        protected virtual bool HandleError()
        {
            if (note == null)
            {
                EDebug.LogError(this.GetType().Name, $"Переменная {nameof(note)} не была инициализирована извне.", this);

                return true;
            }

            return false;
        }
    }
}
