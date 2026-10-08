namespace skowa.Data.ValueContainer
{
    using UnityEngine;

    using skowa.Data.PlayerPrefs;

    /// <summary>
    /// Контейнер строковоого значения
    /// </summary>
    [CreateAssetMenu(fileName = nameof(StringValueContainer), menuName = "skowa/Data/ValueContainer/" + nameof(StringValueContainer))]
    public class StringValueContainer : AbstractValueContainer<string>
    {
        public override string Value
        {
            get
            {
                if (isFirstCall)
                {
                    val = defaultValue;
                    isFirstCall = false;
                }

                if (isSaveable)
                {
                    if (IsValidId())
                    {
                        val = PlayerPrefsHelper.GetString(Id, defaultValue);
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
                            PlayerPrefsHelper.SetString(Id, val);
                        }
                    }

                    OnValueChanged();
                }
            }
        }
    }
}
