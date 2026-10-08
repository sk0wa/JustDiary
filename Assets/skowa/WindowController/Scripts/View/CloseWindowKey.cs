namespace skowa.WindowController
{
    using UnityEngine;
    using UnityEngine.InputSystem;

    using skowa.Extensions.InputAction;

    /// <summary>
    /// Клавиша закрытия окна
    /// </summary>
    public class CloseWindowKey : BaseInputAction
    {
        protected override void OnPerfomed(InputAction.CallbackContext _ctx)
        {
            if (WindowController.Instance != null)
            {
                WindowController.Instance.CloseWindow();
            }
        }
    }
}
