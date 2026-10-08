namespace skowa.Extensions.GameObject
{
    using UnityEngine;

    /// <summary>
    /// Количество дочерних объектов трансформа
    /// </summary>
    public static class TransformChildrenCount
    {
        /// <summary>
        /// Получить количество дочерних объектов
        /// </summary>
        /// <param name="_transform">Родитель</param>
        /// <param name="_countInactive">Учитывать неактивные объекты</param>
        /// <returns>Количество</returns>
        public static int GetChildrenCount(this Transform _transform, bool _countInactive)
        {
            if (_countInactive)
            {
                return _transform.childCount;
            }

            int _res = 0;
            foreach (Transform _child in _transform)
            {
                _res += _child.gameObject.activeSelf ? 1 : 0;
            }

            return _res;
        }
    }
}
