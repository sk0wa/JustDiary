namespace skowa.Data.ID
{
    using UnityEngine;

    /// <summary>
    /// Идентификатор
    /// </summary>
    [CreateAssetMenu(fileName = nameof(ID), menuName = "skowa/Data/" + nameof(ID))]
    public class ID : ScriptableObject
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public string Id => id;
        [SerializeField] protected string id = string.Empty;

        protected virtual void OnEnable()
        {
            id = this.name;
        }
    }
}
