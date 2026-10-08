namespace skowa.Extensions.Application
{
    using UnityEngine;

    /// <summary>
    /// Компонент изменения работы приложения в фоне
    /// </summary>
    public sealed class RunInBackgroundComponent : MonoBehaviour
    {
        private static bool _defaultState = false;
        private static bool _wasInited = false;

        private void Awake()
        {
            if (!_wasInited)
            {
                _defaultState = Application.runInBackground;
                _wasInited = true;
            }
        }

        /// <summary>
        /// Задать статус работы приложения в фоне
        /// </summary>
        /// <param name="_runInBackground">Работать в фоне</param>
        public void SetState(bool _runInBackground)
        {
            Application.runInBackground = _runInBackground;
        }

        /// <summary>
        /// Задать статус работы приложения в фоне по умолчанию
        /// </summary>
        public void SetStateDefault()
        {
            Application.runInBackground = _defaultState;
        }
    }
}
