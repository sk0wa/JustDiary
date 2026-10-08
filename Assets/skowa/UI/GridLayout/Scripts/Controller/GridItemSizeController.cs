namespace skowa.UI.GridLayout
{
    using System.Collections.Generic;

    using UnityEngine;

    using skowa.EDebug;
    using skowa.Extensions.GameObject;
    using skowa.UI.AbstractView;

    /// <summary>
    /// Контроллер размера итемов сетки
    /// </summary>
    public class GridItemSizeController : AbstractGridLayoutGroup
    {
        [SerializeField] protected List<GridItemCountInterval> datas = new List<GridItemCountInterval>();
        [SerializeField] protected bool countInactiveChildren = false;

        protected int childrenCount = 0;

        protected virtual void OnEnable()
        {
            ApplySize();
        }

        /// <summary>
        /// Применить размер
        /// </summary>
        [ContextMenu("Применить размер")]
        public virtual void ApplySize()
        {
            childrenCount = transform.GetChildrenCount(countInactiveChildren);

            foreach (GridItemCountInterval _data in datas)
            {
                if (_data.FromInclusive <= childrenCount && childrenCount <= _data.ToInclusive)
                {
                    Grid.cellSize = _data.ItemData.Size;
                    Grid.spacing = _data.ItemData.Spacing;

                    return;
                }
            }

            EDebug.LogError(this.GetType().Name, $"Ни один интервал не подошел под количество дочерних объектов ({childrenCount}).", this);
        }

        /// <summary>
        /// Применить размер
        /// </summary>
        /// <param name="_count">Количество, для которого нужно применить размер</param>
        public virtual void ApplySize(int _count)
        {
            foreach (GridItemCountInterval _data in datas)
            {
                if (_data.FromInclusive <= _count && _count <= _data.ToInclusive)
                {
                    Grid.cellSize = _data.ItemData.Size;
                    Grid.spacing = _data.ItemData.Spacing;

                    return;
                }
            }

            EDebug.LogError(this.GetType().Name, $"Ни один интервал не подошел под заданное количество объектов ({_count}).", this);
        }
    }
}
