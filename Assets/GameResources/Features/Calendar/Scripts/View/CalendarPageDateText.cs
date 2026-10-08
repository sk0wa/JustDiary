namespace JustDiary.Calendar
{
    using System.Globalization;

    using UnityEngine;

    using skowa.UI.AbstractView;

    /// <summary>
    /// Текст даты страницы календаря (месяц, год)
    /// </summary>
    public class CalendarPageDateText : AbstractTextTMP
    {
        [SerializeField] protected CalendarPage calendar = default;

        protected string month = string.Empty;
        protected string year = string.Empty;

        protected virtual void OnEnable()
        {
            if (calendar != null)
            {
                calendar.onCalendarPageDataChanged += UpdateText;
            }

            UpdateText();
        }

        protected virtual void OnDisable()
        {
            if (calendar != null)
            {
                calendar.onCalendarPageDataChanged -= UpdateText;
            }
        }

        protected virtual void UpdateText()
        {
            if (calendar != null)
            {
                month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(calendar.CurrentMonth);
                year = calendar.CurrentYear.ToString();

                Text.text = $"{month}, {year}";
            }
        }
    }
}
