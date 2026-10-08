namespace skowa.Data.PlayerPrefs
{
    using UnityEngine;
    using UnityEditor;

    /// <summary>
    /// Расширение пользования PlyerPrefs
    /// </summary>
    public static class PlayerPrefsHelper
    {
        #region GET
        /// <summary>
        /// Есть ли значение по ключу
        /// </summary>
        /// <param name="_key">Ключ</param>
        /// <returns>Факт существования</returns>
        public static bool HasKey(string _key)
        {
            return PlayerPrefs.HasKey(_key);
        }

        /// <summary>
        /// Получить значение int
        /// </summary>
        /// <param name="_key">Ключ</param>
        /// <param name="_default">Значение по умолчанию</param>
        /// <returns>Значение ключа</returns>
        public static int GetInt(string _key, int _default = 0)
        {
            if (PlayerPrefs.HasKey(_key))
            {
                return PlayerPrefs.GetInt(_key);
            }

            SetInt(_key, _default);

            return _default;
        }

        /// <summary>
        /// Получить значение float
        /// </summary>
        /// <param name="_key">Ключ</param>
        /// <param name="_default">Значение по умолчанию</param>
        /// <returns>Значение ключа</returns>
        public static float GetFloat(string _key, float _default = 0f)
        {
            if (PlayerPrefs.HasKey(_key))
            {
                return PlayerPrefs.GetFloat(_key);
            }

            SetFloat(_key, _default);

            return _default;
        }

        /// <summary>
        /// Получить значение string
        /// </summary>
        /// <param name="_key">Ключ</param>
        /// <param name="_default">Значение по умолчанию</param>
        /// <returns>Значение ключа</returns>
        public static string GetString(string _key, string _default = "")
        {
            if (PlayerPrefs.HasKey(_key))
            {
                return PlayerPrefs.GetString(_key);
            }

            SetString(_key, _default);

            return _default;
        }

        /// <summary>
        /// Получить значение bool
        /// </summary>
        /// <param name="_key">Ключ</param>
        /// <param name="_default">Значение по умолчанию</param>
        /// <returns>Значение ключа</returns>
        public static bool GetBool(string _key, bool _default = false)
        {
            if (PlayerPrefs.HasKey(_key))
            {
                return PlayerPrefs.GetInt(_key) == 1;
            }

            SetBool(_key, _default);

            return _default;
        }
        #endregion

        #region SET
        /// <summary>
        /// Задать значение int
        /// </summary>
        /// <param name="_key">Ключ</param>
        /// <param name="_val">Значение</param>
        public static void SetInt(string _key, int _val)
        {
            PlayerPrefs.SetInt(_key, _val);
            PlayerPrefs.Save();
        }

        /// <summary>
        /// Задать значение float
        /// </summary>
        /// <param name="_key">Ключ</param>
        /// <param name="_val">Значение</param>
        public static void SetFloat(string _key, float _val)
        {
            PlayerPrefs.SetFloat(_key, _val);
            PlayerPrefs.Save();
        }

        /// <summary>
        /// Задать значение string
        /// </summary>
        /// <param name="_key">Ключ</param>
        /// <param name="_val">Значение</param>
        public static void SetString(string _key, string _val)
        {
            PlayerPrefs.SetString(_key, _val);
            PlayerPrefs.Save();
        }

        /// <summary>
        /// Задать значение bool
        /// </summary>
        /// <param name="_key">Ключ</param>
        /// <param name="_val">Значение</param>
        public static void SetBool(string _key, bool _val)
        {
            PlayerPrefs.SetInt(_key, _val ? 1 : 0);
            PlayerPrefs.Save();
        }
        #endregion

        #region CLEAR
        /// <summary>
        /// Очистить пару ключ-значение
        /// </summary>
        /// <param name="_key">Ключ</param>
        public static void ClearKey(string _key)
        {
            PlayerPrefs.DeleteKey(_key);
            PlayerPrefs.Save();
        }

        /// <summary>
        /// Очистить все пары ключ-значение
        /// </summary>
        public static void ClearAll()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }
        #endregion
    }
}
