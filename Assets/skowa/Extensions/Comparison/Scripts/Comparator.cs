namespace skowa.Extensions.Comparison
{
    using System;

    using skowa.EDebug;

    /// <summary>
    /// Компаратор
    /// </summary>
    public static class Comparator
    {
        /// <summary>
        /// Сравнить
        /// </summary>
        /// <param name="_operator">Оператор сравнения</param>
        /// <param name="_val1">Левый операнд</param>
        /// <param name="_val2">Правый операнд</param>
        /// <returns>Результат сравнения</returns>
        public static bool Compare(ComparisonType _operator, IComparable _val1, IComparable _val2)
        {
            try
            {
                switch (_operator)
                {
                    case ComparisonType.Less:
                        return _val1.CompareTo(_val2) < 0;

                    case ComparisonType.LeesOrEqual:
                        return _val1.CompareTo(_val2) <= 0;

                    case ComparisonType.Equal:
                        return _val1.CompareTo(_val2) == 0;

                    case ComparisonType.MoreOrEqual:
                        return _val1.CompareTo(_val2) >= 0;

                    case ComparisonType.More:
                        return _val1.CompareTo(_val2) > 0;

                    default:
                        EDebug.LogError(nameof(Comparator), $"Не предусмотренный опреатор {_operator}.");
                        return false;
                }
            }
            catch (Exception _exc)
            {
                EDebug.LogError(nameof(Comparator), $"Возникла ошибка {_exc.Message}\n{_exc.StackTrace}.");
            }

            return false;
        }
    }
}
