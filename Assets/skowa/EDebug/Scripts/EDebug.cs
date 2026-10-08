namespace skowa.EDebug
{
    using UnityEngine;

    /// <summary>
    /// Кастомный дебаг только для эдитора
    /// </summary>
    public static class EDebug
    {
        #region CONSTS
        /// <summary>
        /// Цвет обычного лога
        /// </summary>
        public const string COLOR_LOG = "#00FF00";

        /// <summary>
        /// Цвет лога ошибки
        /// </summary>
        public const string COLOR_ERROR = "#FF0000";

        /// <summary>
        /// Цвет лога предупреждения
        /// </summary>
        public const string COLOR_WARNING = "#FFFF00";
        #endregion

        #region Log
        /// <summary>
        /// Обычный лог
        /// </summary>
        /// <param name="_message">Сообщение</param>
        public static void Log(string _message)
        {
#if UNITY_EDITOR
            Debug.Log(_message);
#endif
        }

        /// <summary>
        /// Обычный лог
        /// </summary>
        /// <param name="_message">Сообщение</param>
        /// <param name="_context">Объект отправителя</param>
        public static void Log(string _message, Object _context)
        {
#if UNITY_EDITOR
            Debug.Log(_message, _context);
#endif
        }

        /// <summary>
        /// Обычный лог
        /// </summary>
        /// <param name="_header">Заголовок</param>
        /// <param name="_message">Сообщение</param>
        public static void Log(string _header, string _message)
        {
#if UNITY_EDITOR
            Debug.Log($"<color={COLOR_LOG}>[{_header}]:</color> {_message}");
#endif
        }

        /// <summary>
        /// Обычный лог
        /// </summary>
        /// <param name="_header">Заголовок</param>
        /// <param name="_message">Сообщение</param>
        /// <param name="_context">Объект отправителя</param>
        public static void Log(string _header, string _message, Object _context)
        {
#if UNITY_EDITOR
            Debug.Log($"<color={COLOR_LOG}>[{_header}]:</color> {_message}", _context);
#endif
        }
        #endregion

        #region LogError
        /// <summary>
        /// Лог ошибки
        /// </summary>
        /// <param name="_message">Сообщение</param>
        public static void LogError(string _message)
        {
#if UNITY_EDITOR
            Debug.LogError(_message);
#endif
        }

        /// <summary>
        /// Лог ошибки
        /// </summary>
        /// <param name="_message">Сообщение</param>
        /// <param name="_context">Объект отправителя</param>
        public static void LogError(string _message, Object _context)
        {
#if UNITY_EDITOR
            Debug.LogError(_message, _context);
#endif
        }

        /// <summary>
        /// Лог ошибки
        /// </summary>
        /// <param name="_header">Заголовок</param>
        /// <param name="_message">Сообщение</param>
        public static void LogError(string _header, string _message)
        {
#if UNITY_EDITOR
            Debug.LogError($"<color={COLOR_ERROR}>[{_header}]:</color> {_message}");
#endif
        }

        /// <summary>
        /// Лог ошибки
        /// </summary>
        /// <param name="_header">Заголовок</param>
        /// <param name="_message">Сообщение</param>
        /// <param name="_context">Объект отправителя</param>
        public static void LogError(string _header, string _message, Object _context)
        {
#if UNITY_EDITOR
            Debug.LogError($"<color={COLOR_ERROR}>[{_header}]:</color> {_message}", _context);
#endif
        }
        #endregion

        #region LogWarning
        /// <summary>
        /// Лог предупреждения
        /// </summary>
        /// <param name="_message">Сообщение</param>
        public static void LogWarning(string _message)
        {
#if UNITY_EDITOR
            Debug.LogWarning(_message);
#endif
        }

        /// <summary>
        /// Лог предупреждения
        /// </summary>
        /// <param name="_message">Сообщение</param>
        /// <param name="_context">Объект отправителя</param>
        public static void LogWarning(string _message, Object _context)
        {
#if UNITY_EDITOR
            Debug.LogWarning(_message, _context);
#endif
        }

        /// <summary>
        /// Лог предупреждения
        /// </summary>
        /// <param name="_header">Заголовок</param>
        /// <param name="_message">Сообщение</param>
        public static void LogWarning(string _header, string _message)
        {
#if UNITY_EDITOR
            Debug.LogWarning($"<color={COLOR_WARNING}>[{_header}]:</color> {_message}");
#endif
        }

        /// <summary>
        /// Лог предупреждения
        /// </summary>
        /// <param name="_header">Заголовок</param>
        /// <param name="_message">Сообщение</param>
        /// <param name="_context">Объект отправителя</param>
        public static void LogWarning(string _header, string _message, Object _context)
        {
#if UNITY_EDITOR
            Debug.LogWarning($"<color={COLOR_WARNING}>[{_header}]:</color> {_message}", _context);
#endif
        }
        #endregion
    }
}
