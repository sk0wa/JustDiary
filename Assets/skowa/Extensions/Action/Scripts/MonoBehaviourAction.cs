namespace skowa.Extensions.Action
{
    using UnityEngine;
    using UnityEngine.Events;

    /// <summary>
    /// Действия, совершаемые в ключевых методах MonoBehaviour
    /// </summary>
    public class MonoBehaviourAction : MonoBehaviour
    {
        [SerializeField] protected UnityEvent actionAwake = default;
        [SerializeField] protected UnityEvent actionOnEnable = default;
        [SerializeField] protected UnityEvent actionStart = default;
        [SerializeField] protected UnityEvent actionOnDisable = default;
        [SerializeField] protected UnityEvent actionOnDestroy = default;

        protected virtual void Awake()
        {
            actionAwake?.Invoke();
        }

        protected virtual void OnEnable()
        {
            actionOnEnable?.Invoke();
        }

        protected virtual void Start()
        {
            actionStart?.Invoke();
        }

        protected virtual void OnDisable()
        {
            actionOnDisable?.Invoke();
        }

        protected virtual void OnDestroy()
        {
            actionOnDestroy?.Invoke();
        }
    }
}
