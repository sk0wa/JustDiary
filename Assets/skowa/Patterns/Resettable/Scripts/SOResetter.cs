namespace skowa.Patterns.Resettable
{
    using UnityEngine;
    using UnityEditor;

    /// <summary>
    /// Ресеттер сбрасываемых SO
    /// </summary>
    public class SOResetter
    {
        /// <summary>
        /// Сбросить сбрасываемые SO
        /// </summary>
        [MenuItem("skowa/ScriptableObject/Reset All SO")]
        public static void ResetSO()
        {
            foreach (ScriptableObject _so in Resources.FindObjectsOfTypeAll<ScriptableObject>())
            {
                if (_so is IResettable _resettable)
                {
                    _resettable.Reset();
                }
            }
        }
    }
}
