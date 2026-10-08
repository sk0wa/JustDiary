namespace JustDiary.DayNote
{
    using UnityEngine;

    using skowa.UI.AbstractView;
    using skowa.Data.PlayerPrefs;
    using skowa.Data.ValueContainer;

    /// <summary>
    /// Текстовое TMP отображение времени создания дневной заметки
    /// </summary>
    public class DayNoteCreationTimeTextTMP : AbstractTextTMP
    {
        [SerializeField] protected StringValueContainer container = default;

        protected DayNote note = default;

        protected virtual void OnEnable()
        {
            if (container != null && PlayerPrefsHelper.HasKey(container.Value))
            {
                note = JsonUtility.FromJson<DayNote>(PlayerPrefsHelper.GetString(container.Value));
            }

            UpdateView();
        }

        protected virtual void UpdateView()
        {
            if (note != null)
            {
                Text.text = note.CreationTimeStr;
            }
        }
    }
}
