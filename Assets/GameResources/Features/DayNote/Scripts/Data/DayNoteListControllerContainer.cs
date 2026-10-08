namespace JustDiary.DayNote
{
    using UnityEngine;

    using skowa.Data.Container;

    /// <summary>
    /// Контейнер контроллера списка дневных заметок
    /// </summary>
    [CreateAssetMenu(fileName = nameof(DayNoteListControllerContainer), menuName = "JustDiary/DayNote/" + nameof(DayNoteListControllerContainer))]
    public class DayNoteListControllerContainer : AbstractGenericContainer<DayNoteListController>
    {

    }
}
