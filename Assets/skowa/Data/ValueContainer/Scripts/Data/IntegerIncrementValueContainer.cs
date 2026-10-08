namespace skowa.Data.ValueContainer
{
    using UnityEngine;

    using skowa.EDebug;

    /// <summary>
    /// Контейнер целочисленного значения с авто инкрементом
    /// </summary>
    [CreateAssetMenu(fileName = nameof(IntegerIncrementValueContainer), menuName = "skowa/Data/ValueContainer/" + nameof(IntegerIncrementValueContainer))]
    public class IntegerIncrementValueContainer : IntegerValueContainer
    {
        [SerializeField] protected int incrementValue = 1;

        /// <summary>
        /// Получить значение с авто инкрементом
        /// </summary>
        /// <param name="_increment">Инкрементировать</param>
        /// <returns>Значение</returns>
        public virtual int GetValue(bool _increment = true)
        {
            if (_increment)
            {
                Value = Value + incrementValue;

                return Value - incrementValue;
            }

            return Value;
        }

        public override void SetValue(int _val)
        {
            EDebug.LogError(this.GetType().Name, $"Значение с авто инкрементом недоступно менять произвольно");
        }
    }
}
