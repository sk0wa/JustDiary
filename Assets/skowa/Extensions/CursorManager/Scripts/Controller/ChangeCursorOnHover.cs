namespace skowa.Extensions.CursorManager
{
    using UnityEngine;
    using UnityEngine.EventSystems;

    /// <summary>
    /// Изменение курсора при его наведении на объект
    /// </summary>
    public class ChangeCursorOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] protected CursorType hoverCursor = CursorType.Arrow;

        [SerializeField] protected bool defaultOnDisable = true;

        protected virtual void OnDisable()
        {
            if (CursorManager.Instance != null && defaultOnDisable)
            {
                CursorManager.Instance.SetDefaultCursor();
            }
        }

        public virtual void OnPointerEnter(PointerEventData _eventData)
        {
            if (CursorManager.Instance != null)
            {
                CursorManager.Instance.SetCursor(hoverCursor);
            }
        }

        public virtual void OnPointerExit(PointerEventData _eventData)
        {
            if (CursorManager.Instance != null)
            {
                CursorManager.Instance.SetDefaultCursor();
            }
        }
    }
}
