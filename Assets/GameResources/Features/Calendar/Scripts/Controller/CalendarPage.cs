namespace JustDiary.Calendar
{
    using System;

    using UnityEngine;

    using skowa.EDebug;

    /// <summary>
    /// Страница календаря
    /// </summary>
    public class CalendarPage : MonoBehaviour
    {
        /// <summary>
        /// Событие изменения даты страницы календаря
        /// </summary>
        public event Action onCalendarPageDataChanged = delegate { };

        /// <summary>
        /// Фактическая дата
        /// </summary>
        public DateTime ActualDate { get; protected set; } = DateTime.MinValue;

        public int CurrentYear { get; protected set; } = 1;
        public int CurrentMonth { get; protected set; } = 1;
        public int DaysInMonth { get; protected set; } = 1;
        public DayOfWeek FirstDayOfWeekInMonth { get; protected set; } = DayOfWeek.Monday;

        [SerializeField] protected CalendarData calendarData = default;

        protected DateTime bufDate = default;

        protected virtual void Awake()
        {
            UpdateActualDate();
            bufDate = GetBeginningOfMonth(ActualDate);

            TryChangeCalendarPageData(ActualDate);
        }

        protected virtual void OnEnable()
        {
            UpdateActualDate();
        }

        /// <summary>
        /// Получить начало месяца
        /// </summary>
        /// <param name="_date">Дата</param>
        /// <returns>Дата</returns>
        public static DateTime GetBeginningOfMonth(DateTime _date)
        {
            return new DateTime(_date.Year, _date.Month, 1, 0, 0, 0);
        }

        /// <summary>
        /// Перелистнуть страницу календаря
        /// </summary>
        /// <param name="_isNextPage">Следующая ли страница</param>
        public virtual void TurnCalendarPage(bool _isNextPage)
        {
            int _add = _isNextPage ? 1 : -1;

            if (TryChangeCalendarPageData(bufDate.AddMonths(_add)))
            {
                bufDate = bufDate.AddMonths(_add);
            }
        }

        /// <summary>
        /// Обновить фактическую дату
        /// </summary>
        public virtual void UpdateActualDate()
        {
            ActualDate = DateTime.Now;
        }

        protected virtual bool TryChangeCalendarPageData(DateTime _date)
        {
            if (calendarData.MinInclusiveSupportedYear <= _date.Year && _date.Year <= calendarData.MaxInclusiveSupportedYear)
            {
                CurrentYear = _date.Year;
                CurrentMonth = _date.Month;
                DaysInMonth = DateTime.DaysInMonth(CurrentYear, CurrentMonth);
                FirstDayOfWeekInMonth = GetBeginningOfMonth(_date).DayOfWeek;

                UpdateActualDate();

                onCalendarPageDataChanged();

                return true;
            }

            EDebug.LogError(this.GetType().Name, $"Попытка задания не поддерживаемого года - {_date.Year}.", this);

            return false;
        }
    }
}
