namespace skowa.Data.ValueContainer
{
    using UnityEngine;

    using skowa.Data.PlayerPrefs;

    /// <summary>
    /// Контейнер значения с плавающей точкой
    /// </summary>
    [CreateAssetMenu(fileName = nameof(FloatValueContainer), menuName = "skowa/Data/ValueContainer/" + nameof(FloatValueContainer))]
    public class FloatValueContainer : AbstractValueContainer<float>
    {
        public override float Value
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
                        val = PlayerPrefsHelper.GetFloat(Id, defaultValue);
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
                            PlayerPrefsHelper.SetFloat(Id, val);
                        }
                    }

                    OnValueChanged();
                }
            }
        }
    }
}
