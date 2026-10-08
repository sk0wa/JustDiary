namespace skowa.UI.AbstractView
{
    using UnityEngine;
    using TMPro;

    /// <summary>
    /// Абстрактный выпадающий список (TMP)
    /// </summary>
    [RequireComponent(typeof(TMP_Dropdown))]
    public abstract class AbstractDropdownTMP : MonoBehaviour
    {
        /// <summary>
        /// Экземпляр выпадающего списка
        /// </summary>
        public TMP_Dropdown Dropdown
        {
            get
            {
                if (dropdown == null)
                {
                    dropdown = GetComponent<TMP_Dropdown>();
                }

                return dropdown;
            }
        }
        protected TMP_Dropdown dropdown = default;

        protected virtual void OnEnable()
        {
            Dropdown.onValueChanged.AddListener(OnValueChanged);
        }

        protected virtual void OnDisable()
        {
            Dropdown.onValueChanged.RemoveListener(OnValueChanged);
        }

        /// <summary>
        /// Действие, совершаемое при изменении текущего выбранного значения
        /// </summary>
        /// <param name="_value">Индекс нового значения</param>
        protected virtual void OnValueChanged(int _value)
        {
            // NOTE: При необходимости переопределить в наследнике
        }
    }
}
