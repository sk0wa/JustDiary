namespace skowa.Data.Container
{
    using System;

    using UnityEngine;

    /// <summary>
    /// Абстрактный обобщенный контейнер, хранящий экземпляр класса
    /// </summary>
    /// <typeparam name="T">Тип экземпляра класса</typeparam>
    public abstract class AbstractGenericContainer<T> : ScriptableObject, IDisposable
        where T : class
    {
        /// <summary>
        /// Событие изменения экземпляра класса в контейнере
        /// </summary>
        public event Action onInstanceChanged = delegate { };

        /// <summary>
        /// Экземпляр класса
        /// </summary>
        public T Instance
        {
            get => instance;
            set
            {
                instance = value;
                onInstanceChanged();
            }
        }
        protected T instance = default;

        public virtual void Dispose()
        {
            Instance = null;
        }
    }
}
