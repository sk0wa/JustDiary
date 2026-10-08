namespace skowa.UI.Scrollbar
{
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Реализация скролл вью с использованием слайдера
    /// </summary>
    public class SliderScrollView : MonoBehaviour
    {
        [SerializeField] protected ScrollRect scrollRect = default;
        [SerializeField] protected Slider slider = default;

        [SerializeField, Tooltip("true - вертикальный, false - горизонтальный")] protected bool isVertical = true;
        [SerializeField, Tooltip("true - динамически скрывать/отображать слайдер, false - ничего не делать")] protected bool autoHideSlider = true;

        protected virtual void Awake()
        {
            scrollRect.vertical = isVertical;
            scrollRect.horizontal = !isVertical;

            slider.minValue = 0f;
            slider.maxValue = 1f;
        }

        protected virtual void OnEnable()
        {
            slider.onValueChanged.AddListener(OnSliderValueChanged);
            scrollRect.onValueChanged.AddListener(OnScrollRectValueChanged);

            HandleSliderVisibility();
        }

        protected virtual void OnDisable()
        {
            slider.onValueChanged.RemoveListener(OnSliderValueChanged);
            scrollRect.onValueChanged.RemoveListener(OnScrollRectValueChanged);
        }

        /// <summary>
        /// Обработать видимость слайдера
        /// </summary>
        [ContextMenu("Обработать видимость слайдера")]
        public virtual void HandleSliderVisibility()
        {
            bool _visible = !autoHideSlider;

            if (autoHideSlider)
            {
                if (isVertical)
                {
                    _visible = scrollRect.viewport.rect.height < scrollRect.content.rect.height;
                }
                else
                {
                    _visible = scrollRect.viewport.rect.width < scrollRect.content.rect.width;
                }
            }

            slider.gameObject.SetActive(_visible);
        }

        protected virtual void OnSliderValueChanged(float _val)
        {
            if (isVertical)
            {
                if (scrollRect.verticalNormalizedPosition != _val)
                {
                    scrollRect.verticalNormalizedPosition = _val;
                }
            }
            else
            {
                if (scrollRect.horizontalNormalizedPosition != _val)
                {
                    scrollRect.horizontalNormalizedPosition = _val;
                }
            }
        }

        protected virtual void OnScrollRectValueChanged(Vector2 _val)
        {
            if (isVertical)
            {
                slider.SetValueWithoutNotify(Mathf.Clamp01(_val.y));
            }
            else
            {
                slider.SetValueWithoutNotify(Mathf.Clamp01(_val.x));
            }

            HandleSliderVisibility();
        }
    }
}
