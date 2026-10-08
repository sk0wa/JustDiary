namespace skowa.Data.Container
{
    using UnityEngine;

    /// <summary>
    /// Абстрактный обобщенный инсталлер экземпляра класса в контейнер
    /// </summary>
    /// <typeparam name="T">Тип класса</typeparam>
    public abstract class AbstractGenericContainerInstaller<T> : MonoBehaviour
        where T : class
    {
        [SerializeField] protected T instance = default;
        [SerializeField] protected AbstractGenericContainer<T> container = default;

        protected virtual void Awake()
        {
            InitInstance();

            if (instance != null)
            {
                container.Instance = instance;
            }
        }

        protected virtual void InitInstance()
        {
            // NOTE: При необходимости переопределить в наследнике
        }
    }
}
