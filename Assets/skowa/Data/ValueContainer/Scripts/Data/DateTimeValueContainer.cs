namespace skowa.Data.ValueContainer
{
    using System;

    using UnityEngine;

    using skowa.EDebug;
    using skowa.Data.PlayerPrefs;

    /// <summary>
    /// Контейнер значения даты-времени
    /// </summary>
    [CreateAssetMenu(fileName = nameof(DateTimeValueContainer), menuName = "skowa/Data/ValueContainer/" + nameof(DateTimeValueContainer))]
    public class DateTimeValueContainer : AbstractValueContainer<DateTime>
    {
        /// <summary>
        /// Формат даты-времени
        /// </summary>
        public const string DATE_TIME_FMT = "dd.MM.yyyy HH:mm:ss";

        public override DateTime Value
        {
            get
            {
                if (isFirstCall)
                {
                    if (DateTime.TryParseExact(defaultValueStr, DATE_TIME_FMT, null, System.Globalization.DateTimeStyles.None, out defaultValue))
                    {
                        val = defaultValue;
                    }
                    else
                    {
                        val = DateTime.MinValue;
                        defaultValue = DateTime.MinValue;
                        defaultValueStr = val.ToString(DATE_TIME_FMT);

                        EDebug.LogError(this.GetType().Name, $"Дефолтное значение {nameof(defaultValueStr)}={defaultValueStr} было некорректным, задано {val.ToString(DATE_TIME_FMT)}.", this);
                    }

                    isFirstCall = false;
                }

                if (isSaveable)
                {
                    if (IsValidId())
                    {
                        val = DateTime.ParseExact(PlayerPrefsHelper.GetString(Id, defaultValue.ToString(DATE_TIME_FMT)), DATE_TIME_FMT, null, System.Globalization.DateTimeStyles.None);
                    }
                }

                return val;
            }
            protected set
            {
                if (value != val)
                {
                    val = value;

                    if (isFirstCall)
                    {
                        isFirstCall = false;
                    }

                    if (isSaveable)
                    {
                        if (IsValidId())
                        {
                            PlayerPrefsHelper.SetString(Id, val.ToString(DATE_TIME_FMT));
                        }
                    }

                    OnValueChanged();
                }
            }
        }

        [SerializeField] protected string defaultValueStr = "01.01.0001 00:00:00";
    }
}
