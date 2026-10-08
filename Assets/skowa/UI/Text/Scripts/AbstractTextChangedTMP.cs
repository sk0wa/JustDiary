namespace skowa.UI.Text
{
    using UnityEngine;
    using TMPro;

    using skowa.UI.AbstractView;

    /// <summary>
    /// Абстрактный листенер изменения TMP текста
    /// </summary>
    public abstract class AbstractTextChangedTMP : AbstractTextTMP
    {
        protected virtual void OnEnable()
        {
            TMPro_EventManager.TEXT_CHANGED_EVENT.Add(OnTextChanged);
        }

        protected virtual void OnDisable()
        {
            TMPro_EventManager.TEXT_CHANGED_EVENT.Remove(OnTextChanged);
        }

        protected virtual void OnTextChanged(Object _obj)
        {
            if (_obj == Text)
            {
                ActionOnTextChanged();
            }
        }

        /// <summary>
        /// Действие совершаемое при изменении текста
        /// </summary>
        protected abstract void ActionOnTextChanged();
    }
}
