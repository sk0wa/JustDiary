namespace skowa.Extensions.Action
{
    using System.Collections;

    using UnityEngine;
    using UnityEngine.Events;

    using skowa.Extensions.Coroutine;

    /// <summary>
    /// Действия, совершаемые с задержкой
    /// </summary>
    public class DelayedAction : MonoBehaviour
    {
        [SerializeField] protected UnityEvent action = default;

        [SerializeField] protected WaitForExtension delayWait = default;
        protected CoroutineExtension delayCoroutine = default;

        protected bool isInited = false;

        protected virtual void Awake()
        {
            Init();
        }

        protected virtual void OnDisable()
        {
            delayCoroutine.Coroutine = null;
        }

        /// <summary>
        /// Начать отложенное действие
        /// </summary>
        public virtual void StartDelayedAction()
        {
            // NOTE: Бывают случаи, когда действие вызывается в OnEnable, который отрабатывает раньше Awake, из-за чего возникает ошибка nullref (это связано с порядком выполнения скриптов)
            // Пока решение с проверкой инициализации единственное рабочее
            if (!isInited)
            {
                Init();
            }

            delayCoroutine.Coroutine = StartCoroutine(DelayCoroutine());
        }

        protected virtual void Init()
        {
            if (!isInited)
            {
                delayWait.Init();
                delayCoroutine = new CoroutineExtension(this);

                isInited = true;
            }
        }

        protected virtual void Action()
        {
            action?.Invoke();

            // NOTE: При необходимости переопределить в наследнике
        }

        protected virtual IEnumerator DelayCoroutine()
        {
            yield return delayWait.Wait();

            Action();
        }
    }
}
