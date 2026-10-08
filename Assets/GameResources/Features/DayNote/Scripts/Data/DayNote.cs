namespace JustDiary.DayNote
{
    using System;
    using System.Globalization;

    using UnityEngine;

    using skowa.Data.PlayerPrefs;
    using skowa.Extensions.Application;

    /// <summary>
    /// Дневная заметка
    /// </summary>
    [Serializable]
    public class DayNote
    {
        /// <summary>
        /// Формат даты
        /// </summary>
        public const string DATE_FMT = "dd.MM.yyyy";

        /// <summary>
        /// Формат даты-времени
        /// </summary>
        public const string DATE_TIME_FMT = "dd.MM.yyyy HH:mm:ss";

        /// <summary>
        /// Идентификатор заметки
        /// </summary>
        public string Id = string.Empty;

        /// <summary>
        /// Время создания
        /// </summary>
        public DateTime CreationTime => DateTime.ParseExact(CreationTimeStr, DATE_TIME_FMT, CultureInfoComponent.Instance != null ? CultureInfoComponent.Instance.CurrentCulture : CultureInfo.CurrentCulture);

        /// <summary>
        /// Строковое представление времени создания
        /// </summary>
        public string CreationTimeStr = DateTime.MinValue.ToString(DATE_TIME_FMT);

        /// <summary>
        /// Время изменения
        /// </summary>
        public DateTime ChangeTime => DateTime.ParseExact(ChangeTimeStr, DATE_TIME_FMT, CultureInfoComponent.Instance != null ? CultureInfoComponent.Instance.CurrentCulture : CultureInfo.CurrentCulture);

        /// <summary>
        /// Строковое представление времени изменения
        /// </summary>
        public string ChangeTimeStr = DateTime.MinValue.ToString(DATE_TIME_FMT);

        /// <summary>
        /// Заголовок
        /// </summary>
        public string Caption = string.Empty;

        /// <summary>
        /// Текст
        /// </summary>
        public string Text = string.Empty;

        public DayNote(string _id)
        {
            CreationTimeStr = DateTime.Now.ToString(DATE_TIME_FMT);
            ChangeTimeStr = CreationTimeStr;

            Id = _id;
        }

        /// <summary>
        /// Задать заголовок
        /// </summary>
        /// <param name="_caption">Заголовок</param>
        public virtual void SetCaption(string _caption)
        {
            Caption = _caption;
            UpdateChangeTime();

            Save();
        }

        /// <summary>
        /// Задать текст
        /// </summary>
        /// <param name="_text">Текст</param>
        public virtual void SetText(string _text)
        {
            Text = _text;
            UpdateChangeTime();

            Save();
        }

        /// <summary>
        /// Сохранить данные
        /// </summary>
        public virtual void Save()
        {
            PlayerPrefsHelper.SetString(Id, JsonUtility.ToJson(this));
        }

        /// <summary>
        /// Удалить данные
        /// </summary>
        public virtual void Delete()
        {
            PlayerPrefsHelper.ClearKey(Id);
        }

        protected virtual void UpdateChangeTime()
        {
            ChangeTimeStr = DateTime.Now.ToString(DATE_TIME_FMT); ;
        }
    }
}
