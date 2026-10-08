namespace skowa.UI.AbstractView
{
    using UnityEngine;
    using TMPro;

    /// <summary>
    /// Абстрактный текст (TMP)
    /// </summary>
    [RequireComponent(typeof(TMP_Text))]
    public abstract class AbstractTextTMP : MonoBehaviour
    {
        /// <summary>
        /// Экземпляр текста
        /// </summary>
        public TMP_Text Text
        {
            get
            {
                if (text == null)
                {
                    text = GetComponent<TMP_Text>();
                }

                return text;
            }
        }
        protected TMP_Text text = default;
    }
}
