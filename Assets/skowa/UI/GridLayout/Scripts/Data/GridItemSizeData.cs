namespace skowa.UI.GridLayout
{
    using System;

    using UnityEngine;

    /// <summary>
    /// Дата размера итема сетки
    /// </summary>
    [Serializable]
    public class GridItemSizeData
    {
        /// <summary>
        /// Размер итема
        /// </summary>
        public Vector2 Size = Vector2.zero;

        /// <summary>
        /// Отступ между итемами
        /// </summary>
        public Vector2 Spacing = Vector2.zero;
    }
}
