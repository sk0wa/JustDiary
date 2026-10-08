namespace skowa.Patterns.Resettable
{
    /// <summary>
    /// Контракт на сброс
    /// </summary>
    public interface IResettable
    {
        /// <summary>
        /// Сбросить
        /// </summary>
        public void Reset();
    }
}
