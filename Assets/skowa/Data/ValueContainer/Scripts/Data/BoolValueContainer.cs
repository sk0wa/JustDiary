namespace skowa.Data.ValueContainer
{
    using UnityEngine;

    using skowa.Data.PlayerPrefs;

    /// <summary>
    /// Контейнер булевого значения
    /// </summary>
    [CreateAssetMenu(fileName = nameof(BoolValueContainer), menuName = "skowa/Data/ValueContainer/" + nameof(BoolValueContainer))]
    public class BoolValueContainer : AbstractValueContainer<bool>
    {
        public override bool Value
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
                        val = PlayerPrefsHelper.GetBool(Id, defaultValue);
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
                            PlayerPrefsHelper.SetBool(Id, val);
                        }
                    }

                    OnValueChanged();
                }
            }
        }
    }
}
