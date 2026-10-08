namespace JustDiary.Calendar
{
    using System;
    using System.Globalization;

    using UnityEngine;

    using skowa.UI.AbstractView;

    /// <summary>
    /// Текстовое представление дня недели
    /// </summary>
    public class DayOfWeekText : AbstractTextTMP
    {
        [SerializeField] protected DayOfWeek day = default;

        protected virtual void OnEnable()
        {
            Text.text = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedDayName(day);
        }
    }
}
