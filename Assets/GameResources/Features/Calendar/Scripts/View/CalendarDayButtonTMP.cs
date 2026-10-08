namespace JustDiary.Calendar
{
    using System;

    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;

    using skowa.EDebug;
    using skowa.UI.AbstractView;
    using skowa.Data.PlayerPrefs;
    using skowa.Data.ValueContainer;
    using skowa.Extensions.CursorManager;

    using JustDiary.DayNote;

    /// <summary>
    /// TMP кнопка дня календаря
    /// </summary>
    public class CalendarDayButtonTMP : AbstractButton
    {
        [SerializeField] protected TMP_Text btnText = default;
        [SerializeField] protected Image btnImage = default;
        [Space]

        [SerializeField] protected Sprite defaultSprite = default;
        [SerializeField] protected Sprite todaySprite = default;
        [Space]

        [SerializeField] protected Color textColor = Color.white;
        [SerializeField] protected Color emptyColor = Color.white;
        [SerializeField] protected Color defaultColor = Color.white;
        [SerializeField] protected Color highlightColor = Color.white;
        [Space]

        [SerializeField] protected DateTimeValueContainer dateContainer = default;

        protected ChangeCursorOnHover cursorComponent = default;

        protected DateTime date = default;

        protected virtual void Awake()
        {
            cursorComponent = GetComponent<ChangeCursorOnHover>();
        }

        /// <summary>
        /// Задать внешний вид
        /// </summary>
        /// <param name="_isEmpty">Пустышка ли</param>
        /// <param name="_isToday">Сегодня ли</param>
        /// <param name="_date">Ассоциирующаяся дата</param>
        public virtual void SetView(bool _isEmpty, bool _isToday, DateTime _date)
        {
            if (HandleError())
            {
                return;
            }

            date = _date;

            Button.interactable = !_isEmpty;
            if (cursorComponent != null)
            {
                cursorComponent.enabled = !_isEmpty;
            }

            btnText.color = _isEmpty ? emptyColor : textColor;
            btnText.text = date.ToString("dd");

            btnImage.color = _isEmpty ? emptyColor : defaultColor;
            btnImage.sprite = _isToday ? todaySprite : defaultSprite;

            if (!_isEmpty && PlayerPrefsHelper.HasKey(date.ToString(DayNote.DATE_FMT)))
            {
                btnImage.color = highlightColor;
            }
        }

        protected virtual bool HandleError()
        {
            if (btnText == null)
            {
                EDebug.LogError(this.GetType().Name, $"Переменная {nameof(btnText)} была null.", this);

                return true;
            }

            if (btnImage == null)
            {
                EDebug.LogError(this.GetType().Name, $"Переменная {nameof(btnImage)} была null.", this);

                return true;
            }

            if (dateContainer == null)
            {
                EDebug.LogError(this.GetType().Name, $"Переменная {nameof(dateContainer)} была null.", this);

                return true;
            }

            return false;
        }

        public override void OnButtonClicked()
        {
            if (HandleError())
            {
                return;
            }

            dateContainer.SetValue(date);
        }
    }
}
