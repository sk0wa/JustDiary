namespace skowa.Extensions.Coroutine
{
    /// <summary>
    /// Перечисление типов ожидания для корутины
    /// </summary>
    public enum WaitForType
    {
        /// <summary>
        /// В начале следующего кадра
        /// </summary>
        Null,

        /// <summary>
        /// В конце текущего кадра
        /// </summary>
        EndOfFrame,

        /// <summary>
        /// В начале следующего вызова FixedUpdate
        /// </summary>
        FixedUpdate,

        /// <summary>
        /// В начале кадра по истечении заданного времени с учетом TimeScale
        /// </summary>
        Seconds,

        /// <summary>
        /// В начале кадра по истечении заданного времени, игнорируя TimeScale
        /// </summary>
        SecondsRealtime
    }
}
