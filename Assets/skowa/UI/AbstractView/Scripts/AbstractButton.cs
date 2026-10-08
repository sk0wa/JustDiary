namespace skowa.UI.AbstractView
{
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Абстрактная кнопка
    /// </summary>
    [RequireComponent(typeof(Button))]
    public abstract class AbstractButton : MonoBehaviour
    {
        /// <summary>
        /// Экземпляр кнопки
        /// </summary>
        public Button Button
        {
            get
            {
                if (button == null)
                {
                    button = GetComponent<Button>();
                }

                return button;
            }
        }
        protected Button button = default;

        protected virtual void OnEnable()
        {
            Button.onClick.AddListener(OnButtonClicked);
        }

        protected virtual void OnDisable()
        {
            Button.onClick.RemoveListener(OnButtonClicked);
        }

        /// <summary>
        /// Действие, совершаемое при клике на кнопку
        /// </summary>
        public abstract void OnButtonClicked();
    }
}
