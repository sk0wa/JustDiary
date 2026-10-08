namespace skowa.Extensions.GameObject
{
    using UnityEngine;

    /// <summary>
    /// Наблюдатель за изменением статуса активности объекта (сериализация - объект со сцены)
    /// </summary>
    public abstract class IsActiveObserverInspector : MonoBehaviour
    {
        [SerializeField] protected IsActiveNotifier notifier = default;

        protected virtual void OnEnable()
        {
            if (notifier != null)
            {
                notifier.onIsActiveChanged += OnIsActiveChanged;
            }
        }

        protected virtual void OnDisable()
        {
            if (notifier != null)
            {
                notifier.onIsActiveChanged -= OnIsActiveChanged;
            }
        }

        /// <summary>
        /// Действие, совершаемое при изменении статуса активности объекта
        /// </summary>
        /// <param name="_isActive"></param>
        protected abstract void OnIsActiveChanged(bool _isActive);
    }
}
