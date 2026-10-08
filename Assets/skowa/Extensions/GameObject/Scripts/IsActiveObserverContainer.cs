namespace skowa.Extensions.GameObject
{
    using UnityEngine;

    using skowa.Data.Container;

    /// <summary>
    /// Наблюдатель за изменением статуса активности объекта (сериализация - объект из контейнера)
    /// </summary>
    public abstract class IsActiveObserverContainer : AbstractGenericContainerProvider<IsActiveNotifier>
    {
        protected override void OnInstanceChanged()
        {
            Unsubscribe();

            base.OnInstanceChanged();
        }

        protected override void UpdateAction()
        {
            Unsubscribe();
            Subscribe();
        }

        protected virtual void Subscribe()
        {
            if (instance != null)
            {
                instance.onIsActiveChanged += OnIsActiveChanged;
            }
        }

        protected virtual void Unsubscribe()
        {
            if (instance != null)
            {
                instance.onIsActiveChanged -= OnIsActiveChanged;
            }
        }

        /// <summary>
        /// Действие, совершаемое при изменении статуса активности объекта
        /// </summary>
        /// <param name="_isActive"></param>
        protected abstract void OnIsActiveChanged(bool _isActive);
    }
}
