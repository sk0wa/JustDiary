namespace JustDiary.Calendar
{
    using System;
    using System.Collections.Generic;

    using UnityEngine;

    using skowa.EDebug;
    using skowa.UI.GridLayout;

    /// <summary>
    /// Контроллер TMP кнопок дней календаря
    /// </summary>
    public class CalendarDayButtonTMPController : MonoBehaviour
    {
        [Header("Порядок важен")]
        [SerializeField] protected List<CalendarDayButtonTMP> buttons = new List<CalendarDayButtonTMP>();
        [Space]

        [SerializeField] protected CalendarPage calendar = default;
        [SerializeField] protected GridItemSizeController grid = default;

        protected int emptyCount = 0;
        protected DateTime bufDate = default;

        protected virtual void OnEnable()
        {
            if (HandleError())
            {
                return;
            }

            calendar.onCalendarPageDataChanged += SetButtonsView;
            SetButtonsView();
        }

        protected virtual void OnDisable()
        {
            if (HandleError())
            {
                return;
            }

            calendar.onCalendarPageDataChanged -= SetButtonsView;
        }

        protected virtual void SetButtonsView()
        {
            if (HandleError())
            {
                return;
            }

            emptyCount = calendar.FirstDayOfWeekInMonth == DayOfWeek.Sunday ? 6 : (int)calendar.FirstDayOfWeekInMonth - 1;
            bufDate = new DateTime(calendar.CurrentYear, calendar.CurrentMonth, 1, 0, 0, 0);

            for (int _i = 0; _i < emptyCount; _i++)
            {
                buttons[_i].SetView(true, false, bufDate);
            }

            for (int _i = emptyCount; _i < emptyCount + calendar.DaysInMonth; _i++)
            {
                buttons[_i].SetView(false, bufDate.Day == calendar.ActualDate.Day && bufDate.Month == calendar.ActualDate.Month && bufDate.Year == calendar.ActualDate.Year, bufDate);
                bufDate = bufDate.AddDays(1);
            }
            bufDate = bufDate.AddDays(-1);

            for (int _i = emptyCount + calendar.DaysInMonth; _i < buttons.Count; _i++)
            {
                buttons[_i].SetView(true, false, bufDate);
            }

            if (grid != null)
            {
                grid.ApplySize(calendar.DaysInMonth + emptyCount);
            }
        }

        protected virtual bool HandleError()
        {
            if (calendar == null)
            {
                EDebug.LogError(this.GetType().Name, $"Переменная {nameof(calendar)} была null.");

                return true;
            }

            return false;
        }
    }
}
