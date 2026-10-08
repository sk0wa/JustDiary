namespace JustDiary.Calendar
{
    using UnityEngine;
    using UnityEngine.InputSystem;

    using skowa.Extensions.InputAction;

    /// <summary>
    /// Клавиша перелистывания страницы календаря
    /// </summary>
    public class TurnCalendarPageKey : BaseInputAction
    {
        [SerializeField] protected CalendarPage calendar = default;
        [SerializeField] protected bool isNextPage = false;

        protected override void OnPerfomed(InputAction.CallbackContext _ctx)
        {
            if (calendar != null)
            {
                calendar.TurnCalendarPage(isNextPage);
            }
        }
    }
}
