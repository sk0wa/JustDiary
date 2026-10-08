namespace skowa.UI.HoverCursor
{
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.EventSystems;

    /// <summary>
    /// Изменение цвета при наведении курсора
    /// </summary>
    public class ChangeColorOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] protected Graphic target = default;
        [SerializeField] protected Color color = Color.white;

        [SerializeField] protected bool defaultOnDisable = true;

        protected Color defaultColor = Color.white;
        protected bool isDefaultInited = false;

        protected virtual void OnEnable()
        {
            if (target != null && !isDefaultInited)
            {
                defaultColor = target.color;
                isDefaultInited = true;
            }
        }

        protected virtual void OnDisable()
        {
            if (target != null && defaultOnDisable && isDefaultInited)
            {
                target.color = defaultColor;
            }
        }

        public virtual void OnPointerEnter(PointerEventData _eventData)
        {
            if (target != null)
            {
                target.color = color;
            }
        }

        public virtual void OnPointerExit(PointerEventData _eventData)
        {
            if (target != null)
            {
                target.color = defaultColor;
            }
        }
    }
}
