namespace skowa.Extensions.Coroutine
{
    using System;
    using System.Collections;

    using UnityEngine;

    /// <summary>
    /// Расширение пользования ожидания для корутины
    /// </summary>
    [Serializable]
    public class WaitForExtension
    {
        /// <summary>
        /// Тип ожидания
        /// </summary>
        public WaitForType WaitType = WaitForType.Null;

        /// <summary>
        /// Время ожидания в секундах
        /// </summary>
        [Min(0.01f)] public float WaitSeconds = 1f;

        protected object waitInstruction = default;

        /// <summary>
        /// Инициализировать
        /// </summary>
        public virtual void Init()
        {
            if (WaitType == WaitForType.Null)
            {
                waitInstruction = null;
                return;
            }

            if (WaitType == WaitForType.EndOfFrame)
            {
                waitInstruction = new WaitForEndOfFrame();
                return;
            }

            if (WaitType == WaitForType.FixedUpdate)
            {
                waitInstruction = new WaitForFixedUpdate();
                return;
            }

            if (WaitType == WaitForType.Seconds)
            {
                waitInstruction = new WaitForSeconds(WaitSeconds);
                return;
            }

            if (WaitType == WaitForType.SecondsRealtime)
            {
                waitInstruction = new WaitForSecondsRealtime(WaitSeconds);
                return;
            }
        }

        /// <summary>
        /// Ожидать
        /// </summary>
        /// <returns>Инструкция ожидания</returns>
        public virtual IEnumerator Wait()
        {
            yield return waitInstruction;
        }
    }
}
