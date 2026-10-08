namespace JustDiary.Calendar
{
    using UnityEngine;

    /// <summary>
    /// Дата календаря
    /// </summary>
    [CreateAssetMenu(fileName = nameof(CalendarData), menuName = "JustDiary/Calendar/" + nameof(CalendarData))]
    public class CalendarData : ScriptableObject
    {
        /// <summary>
        /// Минимальный (включительно) поддерживаемый год календарем
        /// </summary>
        public int MinInclusiveSupportedYear => minInclusiveSupportedYear;

        /// <summary>
        /// Максимальный (включительно) поддерживаемый год календарем
        /// </summary>
        public int MaxInclusiveSupportedYear => maxInclusiveSupportedYear;

        [SerializeField] protected int minInclusiveSupportedYear = 2003;
        [SerializeField] protected int maxInclusiveSupportedYear = 2077;
    }
}
