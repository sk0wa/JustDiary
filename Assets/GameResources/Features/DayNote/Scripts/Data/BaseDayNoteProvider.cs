namespace JustDiary.DayNote
{
    using UnityEngine;

    using skowa.Data.PlayerPrefs;
    using skowa.Data.ValueContainer;

    /// <summary>
    /// Базовый провайдер дневной заметки
    /// </summary>
    public class BaseDayNoteProvider : MonoBehaviour
    {
        /// <summary>
        /// Экземпляр дневной заметки
        /// </summary>
        public DayNote DayNote
        {
            get
            {
                if (idContainer == null)
                {
                    return null;
                }

                if (!PlayerPrefsHelper.HasKey(idContainer.Value))
                {
                    return null;
                }

                return JsonUtility.FromJson<DayNote>(PlayerPrefsHelper.GetString(idContainer.Value));
            }
        }

        [SerializeField] protected StringValueContainer idContainer = default;
    }
}
