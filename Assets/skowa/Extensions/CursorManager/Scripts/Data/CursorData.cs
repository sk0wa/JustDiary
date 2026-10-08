namespace skowa.Extensions.CursorManager
{
    using System;

    using UnityEngine;

    /// <summary>
    /// Дата курсора
    /// </summary>
    [Serializable]
    public class CursorData
    {
        /// <summary>
        /// Тип курсора
        /// </summary>
        public CursorType CursorType = CursorType.Arrow;

        /// <summary>
        /// Текстура курсора
        /// </summary>
        public Texture2D CursorTexture = default;

        /// <summary>
        /// Отступ для текстуры
        /// </summary>
        public Vector2 HotSpot = default;
    }
}
