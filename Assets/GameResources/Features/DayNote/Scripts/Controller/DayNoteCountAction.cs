namespace JustDiary.DayNote
{
    using UnityEngine;
    using UnityEngine.Events;

    using skowa.Extensions.Comparison;

    /// <summary>
    /// Действие, совершаемое при достижении заданного количества заметок на день
    /// </summary>
    public class DayNoteCountAction : MonoBehaviour
    {
        [SerializeField] protected DayNoteListController controller = default;

        [SerializeField, Min(0)] protected int targetCount = DayNoteListController.DAY_NOTES_LIMIT_COUNT;
        [SerializeField] protected ComparisonType comparisonType = ComparisonType.Equal;

        [SerializeField] protected UnityEvent action = default;

        protected virtual void OnEnable()
        {
            if (controller != null)
            {
                controller.onNotesChanged += MakeComparison;
            }

            MakeComparison();
        }

        protected virtual void OnDisable()
        {
            if (controller != null)
            {
                controller.onNotesChanged -= MakeComparison;
            }
        }

        protected virtual void MakeComparison()
        {
            if (controller != null && Comparator.Compare(comparisonType, controller.Notes.Count, targetCount))
            {
                Action();
            }
        }

        protected virtual void Action()
        {
            if (action != null)
            {
                action.Invoke();
            }
        }
    }
}
