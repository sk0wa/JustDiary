namespace skowa.WindowController
{
    using UnityEngine;

    using skowa.UI.AbstractView;

    /// <summary>
    /// Абстрактная кнопка управления контроллером окон
    /// </summary>
    public abstract class AbstractWindowControllerButton : AbstractButton
    {
        protected WindowController controller = default;

        protected virtual void Awake()
        {
            controller = WindowController.Instance;
        }

        public override void OnButtonClicked()
        {
            if (controller != null)
            {
                WindowControllerAction();
            }
        }

        /// <summary>
        /// Действие контроллера окон при клике на кнопку
        /// </summary>
        protected abstract void WindowControllerAction();
    }
}
