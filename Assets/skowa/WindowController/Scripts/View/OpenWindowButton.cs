namespace skowa.WindowController
{
    using UnityEngine;

    /// <summary>
    /// Кнопка открытия окна
    /// </summary>
    public class OpenWindowButton : AbstractWindowControllerButton
    {
        [SerializeField] protected WindowAsset window = default;
        [SerializeField] protected bool closeCurrentWindow = true;

        protected override void WindowControllerAction()
        {
            controller.OpenWindow(window, closeCurrentWindow);
        }
    }
}
