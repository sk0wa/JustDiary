namespace skowa.UI.AbstractView
{
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Абстрактная сетка
    /// </summary>
    [RequireComponent(typeof(GridLayoutGroup))]
    public abstract class AbstractGridLayoutGroup : MonoBehaviour
    {
        /// <summary>
        /// Экземпляр сетки
        /// </summary>
        public GridLayoutGroup Grid
        {
            get
            {
                if (grid == null)
                {
                    grid = GetComponent<GridLayoutGroup>();
                }

                return grid;
            }
        }
        protected GridLayoutGroup grid = default;
    }
}
