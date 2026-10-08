namespace JustDiary.DayNote
{
    using UnityEngine;
    using TMPro;

    using skowa.EDebug;
    using skowa.Data.ValueContainer;

    /// <summary>
    /// TMP кнопка сеттинга дневной заметки
    /// </summary>
    public class DayNoteSettingButtonTMP : AbstractDayNoteButton
    {
        [SerializeField] protected TMP_Text btnText = default;

        [SerializeField] protected StringValueContainer idContainer = default;

        protected override void OnEnable()
        {
            base.OnEnable();

            if (note != null)
            {
                UpdateView();
            }
        }

        /// <summary>
        /// Обновить отображение
        /// </summary>
        public virtual void UpdateView()
        {
            if (HandleError())
            {
                return;
            }

            btnText.text = note.Caption;
        }

        /// <summary>
        /// Инициализировать
        /// </summary>
        /// <param name="_note">Экземпляр заметки</param>
        public override void Init(DayNote _note)
        {
            base.Init(_note);

            if (note != null)
            {
                UpdateView();
            }
        }

        public override void OnButtonClicked()
        {
            if (HandleError())
            {
                return;
            }

            idContainer.SetValue(note.Id);
        }

        protected override bool HandleError()
        {
            if (base.HandleError())
            {
                return true;
            }

            if (btnText == null)
            {
                EDebug.LogError(this.GetType().Name, $"Переменная {nameof(btnText)} была null.", this);

                return true;
            }

            if (idContainer == null)
            {
                EDebug.LogError(this.GetType().Name, $"Переменная {nameof(idContainer)} была null.", this);

                return true;
            }

            return false;
        }
    }
}
