namespace JustDiary.DayNoteSearching
{
    using System;
    using System.Collections.Generic;

    using UnityEngine;

    using skowa.EDebug;
    using skowa.Data.ID;
    using skowa.Data.PlayerPrefs;

    using JustDiary.DayNote;

    /// <summary>
    /// Серчер дневных записок
    /// </summary>
    public class DayNoteSearcher : MonoBehaviour
    {
        [SerializeField] protected ID idRecord = default;

        /// <summary>
        /// Поиск
        /// </summary>
        /// <param name="_entry">Строка, вхождение которой ищется</param>
        /// <returns>Список дневных заметок</returns>
        public virtual List<DayNote> Search(string _entry, bool _ignoreCase = true)
        {
            List<DayNote> _res = new List<DayNote>();

            if (HandleError())
            {
                return _res;
            }

            if (string.IsNullOrWhiteSpace(_entry))
            {
                return _res;
            }

            string _dates = PlayerPrefsHelper.GetString(idRecord.Id);
            string _idxs = "";
            string _idDayNote = "";

            // NOTE: Поиск производится согласно логике в DayNoteListController
            foreach (string _date in _dates.Split(DayNoteListIdRecorder.SEPARATOR, StringSplitOptions.RemoveEmptyEntries))
            {
                if (!PlayerPrefsHelper.HasKey(_date))
                {
                    continue;
                }

                _idxs = PlayerPrefsHelper.GetString(_date);

                if (!string.IsNullOrWhiteSpace(_idxs))
                {
                    foreach (string _idx in _idxs.Split(DayNoteListController.SEPARATOR, StringSplitOptions.RemoveEmptyEntries))
                    {
                        _idDayNote = $"{_date}{DayNoteListController.SEPARATOR}{_idx}";

                        if (PlayerPrefsHelper.HasKey(_idDayNote))
                        {
                            DayNote _buf = JsonUtility.FromJson<DayNote>(PlayerPrefsHelper.GetString(_idDayNote));

                            if (_buf.Caption.Contains(_entry, _ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal) || _buf.Text.Contains(_entry, _ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal))
                            {
                                _res.Add(_buf);
                            }
                        }
                    }
                }
            }

            return _res;
        }

        protected virtual bool HandleError()
        {
            if (idRecord == null)
            {
                EDebug.LogError(this.GetType().Name, $"Переменная {nameof(idRecord)} была null.", this);

                return true;
            }

            return false;
        }
    }
}
