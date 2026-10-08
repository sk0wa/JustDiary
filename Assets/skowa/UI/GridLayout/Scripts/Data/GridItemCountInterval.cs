namespace skowa.UI.GridLayout
{
    using System;

    /// <summary>
    /// Сопоставление интервала количества итемов сетки к их дате размера
    /// </summary>
    [Serializable]
    public class GridItemCountInterval
    {
        /// <summary>
        /// От (включительно)
        /// </summary>
        public int FromInclusive = 0;

        /// <summary>
        /// До (включительно)
        /// </summary>
        public int ToInclusive = 0;

        /// <summary>
        /// Дата итема
        /// </summary>
        public GridItemSizeData ItemData = new GridItemSizeData();
    }
}
