namespace skowa.UI.HoverCursor
{
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.EventSystems;

    /// <summary>
    /// Изменение спрайта имэджа при наведении курсора
    /// </summary>
    public class ChangeImageOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] protected Image target = default;
        [SerializeField] protected Sprite sprite = default;

        [SerializeField] protected bool defaultOnDisable = true;

        protected Sprite defaultSprite = default;
        protected bool isDefaultInited = false;

        protected virtual void OnEnable()
        {
            if (target != null && !isDefaultInited)
            {
                defaultSprite = target.sprite;
                isDefaultInited = true;
            }
        }

        protected virtual void OnDisable()
        {
            if (target != null && defaultOnDisable && isDefaultInited)
            {
                target.sprite = defaultSprite;
            }
        }

        public void OnPointerEnter(PointerEventData _eventData)
        {
            if (target != null)
            {
                target.sprite = sprite;
            }
        }

        public void OnPointerExit(PointerEventData _eventData)
        {
            if (target != null)
            {
                target.sprite = defaultSprite;
            }
        }
    }
}
