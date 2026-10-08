namespace skowa.UI.HoverCursor
{
    using UnityEngine;
    using UnityEngine.EventSystems;

    /// <summary>
    /// Изменение скейла при наведении курсора
    /// </summary>
    public class ChangeScaleOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] protected Transform target = default;
        [SerializeField] protected Vector3 scale = Vector3.one;

        [SerializeField] protected bool defaultOnDisable = true;

        protected Vector3 defaultScale = default;
        protected bool isDefaultInited = false;

        protected virtual void OnEnable()
        {
            if (target != null && !isDefaultInited)
            {
                defaultScale = target.localScale;
                isDefaultInited = true;
            }
        }

        protected virtual void OnDisable()
        {
            if (target != null && defaultOnDisable && isDefaultInited)
            {
                target.localScale = defaultScale;
            }
        }

        public void OnPointerEnter(PointerEventData _eventData)
        {
            if (target != null)
            {
                target.localScale = scale;
            }
        }

        public void OnPointerExit(PointerEventData _eventData)
        {
            if (target != null)
            {
                target.localScale = defaultScale;
            }
        }
    }
}
