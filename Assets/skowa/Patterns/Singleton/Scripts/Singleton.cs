namespace skowa.Patterns.Singleton
{
    using System;

    using UnityEngine;

    using skowa.EDebug;

    /// <summary>
    /// Реализация паттерна синглтон
    /// </summary>
    public class Singleton<T> : MonoBehaviour
        where T : Component
    {
        /// <summary>
        /// Событие инициализации экземпляра синглтона
        /// </summary>
        public static event Action onInitizalized = delegate { };

        /// <summary>
        /// Экземпляр синглтона
        /// </summary>
        public static T Instance => _instance;
        private static T _instance = default;

        [SerializeField] private bool _dontDestroyOnLoad = false;

        protected virtual void Awake()
        {
            if (_instance == null)
            {
                _instance = this as T;
                onInitizalized();

                if (_dontDestroyOnLoad)
                {
                    DontDestroyOnLoad(this);
                }

                return;
            }

            Destroy(this);

            EDebug.LogError(typeof(T).Name, $"Был удален дубликат синглтона ({nameof(name)} = {name}).", _instance.gameObject);
        }
    }
}
