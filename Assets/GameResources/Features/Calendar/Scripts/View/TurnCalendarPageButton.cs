namespace JustDiary.Calendar
{
    using UnityEngine;

    using skowa.UI.AbstractView;

    /// <summary>
    /// Кнопка перелистывания страницы календаря
    /// </summary>
    public class TurnCalendarPageButton : AbstractButton
    {
        [SerializeField] protected CalendarPage calendar = default;
        [SerializeField] protected bool isNextPage = false;

        public override void OnButtonClicked()
        {
            if (calendar != null)
            {
                calendar.TurnCalendarPage(isNextPage);
            }
        }
    }
}
