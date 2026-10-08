namespace skowa.Data.ValueContainer
{
    using UnityEngine;

    using skowa.Data.PlayerPrefs;

    /// <summary>
    /// Контейнер целочисленного значения
    /// </summary>
    [CreateAssetMenu(fileName = nameof(IntegerValueContainer), menuName = "skowa/Data/ValueContainer/" + nameof(IntegerValueContainer))]
    public class IntegerValueContainer : AbstractValueContainer<int>
    {
        public override int Value
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
                        val = PlayerPrefsHelper.GetInt(Id, defaultValue);
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
                            PlayerPrefsHelper.SetInt(Id, val);
                        }
                    }

                    OnValueChanged();
                }
            }
        }

        public override void SetValue(int _val)
        {
            Value = _val;
        }

        public override void SetDefaultValue()
        {
            Value = defaultValue;
        }
    }
}
