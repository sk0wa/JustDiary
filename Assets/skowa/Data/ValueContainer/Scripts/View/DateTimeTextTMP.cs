namespace skowa.Data.ValueContainer
{
    using UnityEngine;

    using skowa.EDebug;
    using skowa.UI.AbstractView;

    /// <summary>
    /// Текстовое отображение даты в контейнере
    /// </summary>
    public class DateTimeTextTMP : AbstractTextTMP
    {
        [SerializeField] protected DateTimeValueContainer container = default;
        [SerializeField] protected string fmt = DateTimeValueContainer.DATE_TIME_FMT;

        protected virtual void OnEnable()
        {
            container.onValueChanged += UpdateView;
            UpdateView();
        }

        protected virtual void OnDisable()
        {
            container.onValueChanged -= UpdateView;
        }

        /// <summary>
        /// Обновить отображение текста
        /// </summary>
        public virtual void UpdateView()
        {
            if (container == null)
            {
                EDebug.LogError(this.GetType().Name, $"Переменная {nameof(container)} была null.", this);

                return;
            }

            Text.text = container.Value.ToString(fmt);
        }
    }
}
