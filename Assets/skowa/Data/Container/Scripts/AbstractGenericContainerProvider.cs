namespace skowa.Data.Container
{
    using UnityEngine;

    /// <summary>
    /// Абтрактный обобщенный провайдер экземпляра класса из контейнера
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AbstractGenericContainerProvider<T> : MonoBehaviour
        where T : class
    {
        [SerializeField] protected AbstractGenericContainer<T> container = default;

        protected T instance = default;

        protected virtual void OnEnable()
        {
            if (instance != null)
            {
                UpdateAction();
            }

            container.onInstanceChanged += OnInstanceChanged;
        }

        protected virtual void OnDisable()
        {
            container.onInstanceChanged -= OnInstanceChanged;
        }

        protected virtual void OnInstanceChanged()
        {
            instance = container.Instance;
            UpdateAction();
        }

        /// <summary>
        /// Действие, совершаемое при обновлении даты в контейнере
        /// </summary>
        protected abstract void UpdateAction();
    }
}
