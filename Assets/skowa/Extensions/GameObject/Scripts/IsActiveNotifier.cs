namespace skowa.Extensions.GameObject
{
    using System;

    using UnityEngine;

    /// <summary>
    /// Уведомитель изменения статуса активности объекта
    /// </summary>
    public class IsActiveNotifier : MonoBehaviour
    {
        /// <summary>
        /// Событие изменения статуса активности объекта
        /// </summary>
        public event Action<bool> onIsActiveChanged = delegate { };

        protected virtual void OnEnable()
        {
            onIsActiveChanged(true);
        }

        protected virtual void OnDisable()
        {
            onIsActiveChanged(false);
        }
    }
}
