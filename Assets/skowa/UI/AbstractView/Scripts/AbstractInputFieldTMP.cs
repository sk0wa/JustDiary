namespace skowa.UI.AbstractView
{
    using UnityEngine;
    using TMPro;

    /// <summary>
    /// Абстрактное поле ввода (TMP)
    /// </summary>
    [RequireComponent(typeof(TMP_InputField))]
    public abstract class AbstractInputFieldTMP : MonoBehaviour
    {
        /// <summary>
        /// Экземпляр поля ввода
        /// </summary>
        public TMP_InputField InputField
        {
            get
            {
                if (inputField == null)
                {
                    inputField = GetComponent<TMP_InputField>();
                }

                return inputField;
            }
        }
        protected TMP_InputField inputField = default;

        protected virtual void OnEnable()
        {
            InputField.onValueChanged.AddListener(OnValueChanged);
            InputField.onEndEdit.AddListener(OnEndEdit);
            InputField.onSelect.AddListener(OnSelect);
            InputField.onDeselect.AddListener(OnDeselect);
        }

        protected virtual void OnDisable()
        {
            InputField.onValueChanged.RemoveListener(OnValueChanged);
            InputField.onEndEdit.RemoveListener(OnEndEdit);
            InputField.onSelect.RemoveListener(OnSelect);
            InputField.onDeselect.RemoveListener(OnDeselect);
        }

        protected virtual void OnValueChanged(string _value)
        {
            // NOTE: При необходимости переопределить в наследнике
        }

        protected virtual void OnEndEdit(string _value)
        {
            // NOTE: При необходимости переопределить в наследнике
        }

        protected virtual void OnSelect(string _value)
        {
            // NOTE: При необходимости переопределить в наследнике
        }

        protected virtual void OnDeselect(string _value)
        {
            // NOTE: При необходимости переопределить в наследнике
        }
    }
}
