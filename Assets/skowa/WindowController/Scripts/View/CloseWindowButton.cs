namespace skowa.WindowController
{
    using UnityEngine;

    /// <summary>
    /// Кнопка закрытия окна
    /// </summary>
    public class CloseWindowButton : AbstractWindowControllerButton
    {
        protected override void WindowControllerAction()
        {
            controller.CloseWindow();
        }
    }
}
