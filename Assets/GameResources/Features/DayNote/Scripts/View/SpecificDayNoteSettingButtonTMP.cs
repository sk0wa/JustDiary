namespace JustDiary.DayNote
{
    using UnityEngine;

    using skowa.EDebug;
    using skowa.Data.ID;
    using skowa.Data.PlayerPrefs;

    /// <summary>
    /// TMP кнопка сеттинга конкретной дневной заметки
    /// </summary>
    public class SpecificDayNoteSettingButtonTMP : DayNoteSettingButtonTMP
    {
        [SerializeField] protected ID idDayNote = default;

        [SerializeField] protected string defaultCaption = "Caption";
        [SerializeField, TextArea(2, 3)] protected string defaultText = "Text";

        protected override void OnEnable()
        {
            base.OnEnable();

            if (idDayNote == null)
            {
                EDebug.LogError(this.GetType().Name, $"Переменная {nameof(idDayNote)} была null.", this);
            }

            if (!PlayerPrefsHelper.HasKey(idDayNote.Id))
            {
                DayNote _note = new DayNote(idDayNote.Id) { Caption = defaultCaption, Text = defaultText };
                PlayerPrefsHelper.SetString(idDayNote.Id, JsonUtility.ToJson(_note));
            }

            Init(JsonUtility.FromJson<DayNote>(PlayerPrefsHelper.GetString(idDayNote.Id)));
        }
    }
}
