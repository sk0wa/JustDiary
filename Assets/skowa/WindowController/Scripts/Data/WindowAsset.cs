namespace skowa.WindowController
{
    using UnityEngine;
    using skowa.Data.ID;

    /// <summary>
    /// Ассет, хранящий префаб окна
    /// </summary>
    [CreateAssetMenu(fileName = nameof(WindowAsset), menuName = "skowa/WindowController/" + nameof(WindowAsset))]
    public class WindowAsset : ScriptableObject
    {
        /// <summary>
        /// Идентификатор окна
        /// </summary>
        public ID Id => id;
        [SerializeField] protected ID id = default;

        /// <summary>
        /// Префаб окна
        /// </summary>
        public Window Window => window;
        [SerializeField] protected Window window = default;
    }
}
