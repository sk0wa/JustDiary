namespace JustDiary.DayNoteSearching
{
    using System;
    using System.Globalization;

    using UnityEngine;

    using skowa.EDebug;
    using skowa.Data.ValueContainer;

    using JustDiary.DayNote;

    /// <summary>
    /// TMP кнопка сеттинга дневной заметки с датой
    /// </summary>
    public class DayNoteDateSettingButtonTMP : DayNoteSettingButtonTMP
    {
        [SerializeField] protected DateTimeValueContainer date = default;

        protected string noteDate => note != null ? note.Id.Substring(0, DayNote.DATE_FMT.Length) : "";

        public override void UpdateView()
        {
            if (HandleError())
            {
                return;
            }

            // NOTE: Согласно логике задания идентификатора в DayNoteListController
            btnText.text = $"{noteDate} {note.Caption}";
        }

        public override void OnButtonClicked()
        {
            base.OnButtonClicked();

            if (HandleError())
            {
                return;
            }

            date.SetValue(DateTime.ParseExact(noteDate, DayNote.DATE_FMT, CultureInfo.CurrentCulture));
        }

        protected override bool HandleError()
        {
            if (base.HandleError())
            {
                return true;
            }

            if (date == null)
            {
                EDebug.LogError(this.GetType().Name, $"Переменная {nameof(date)} была null.");

                return true;
            }

            return false;
        }
    }
}
