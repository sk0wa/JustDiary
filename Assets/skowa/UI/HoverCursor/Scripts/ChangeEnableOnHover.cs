namespace skowa.UI.HoverCursor
{
    using UnityEngine;
    using UnityEngine.EventSystems;

    /// <summary>
    /// Изменение активности объекта при наведении курсора
    /// </summary>
    public class ChangeEnableOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] protected GameObject target = default;
        [SerializeField, Tooltip("true - вкл при наведении, false - выкл при наведении")] protected bool isEnabled = true;

        [SerializeField] protected bool defaultOnDisable = true;

        protected bool defaultEnabled = true;
        protected bool isDefaultInited = false;

        protected virtual void OnEnable()
        {
            if (target != null && !isDefaultInited)
            {
                defaultEnabled = target.activeSelf;
                isDefaultInited = true;
            }
        }

        protected virtual void OnDisable()
        {
            if (target != null && defaultOnDisable && isDefaultInited)
            {
                target.SetActive(defaultEnabled);
            }
        }

        public virtual void OnPointerEnter(PointerEventData _eventData)
        {
            if (target != null)
            {
                target.SetActive(isEnabled);
            }
        }

        public virtual void OnPointerExit(PointerEventData _eventData)
        {
            if (target != null)
            {
                target.SetActive(defaultEnabled);
            }
        }
    }
}
