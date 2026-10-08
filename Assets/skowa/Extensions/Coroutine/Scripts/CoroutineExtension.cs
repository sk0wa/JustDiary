namespace skowa.Extensions.Coroutine
{
    using UnityEngine;

    /// <summary>
    /// Расширение пользования корутиной
    /// </summary>
    public class CoroutineExtension
    {
        /// <summary>
        /// Монобех-владелец корутины
        /// </summary>
        public MonoBehaviour Owner { get; protected set; } = default;

        /// <summary>
        /// Корутина
        /// </summary>
        public Coroutine Coroutine
        {
            get => coroutine;
            set
            {
                if (coroutine != null)
                {
                    Owner.StopCoroutine(coroutine);
                    coroutine = null;
                }

                coroutine = value;
            }
        }
        protected Coroutine coroutine = default;

        public CoroutineExtension(MonoBehaviour _owner)
        {
            Owner = _owner;
        }
    }
}
