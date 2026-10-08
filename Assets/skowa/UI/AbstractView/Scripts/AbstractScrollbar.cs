namespace skowa.UI.AbstractView
{
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Абстрактный скроллбар
    /// </summary>
    [RequireComponent(typeof(Scrollbar))]
    public abstract class AbstractScrollbar : MonoBehaviour
    {
        /// <summary>
        /// Экземпляр скроллбара
        /// </summary>
        public Scrollbar Scrollbar
        {
            get
            {
                if (scrollbar == null)
                {
                    scrollbar = GetComponent<Scrollbar>();
                }

                return scrollbar;
            }
        }
        protected Scrollbar scrollbar = default;
    }
}
