namespace skowa.Data.ValueContainer
{
    using System;

    using UnityEngine;

    using skowa.EDebug;
    using skowa.Data.ID;
    using skowa.Patterns.Resettable;

    /// <summary>
    /// Абстрактное значение в контейнере
    /// </summary>
    public abstract class AbstractValueContainer<T> : ScriptableObject, IResettable
    {
        /// <summary>
        /// Событие изменения значения
        /// </summary>
        public event Action onValueChanged = delegate { };

        /// <summary>
        /// Значение
        /// </summary>
        public abstract T Value { get; protected set; }
        protected T val = default;

        /// <summary>
        /// Идентификатор значения
        /// </summary>
        public string Id => id != null ? id.Id : string.Empty;

        [Header("Обязательно, если значение сохраняемое")]
        [SerializeField] protected ID id = default;
        [Space]

        [SerializeField] protected T defaultValue = default;

        [Tooltip("Сохраняемое ли значение")]
        [SerializeField] protected bool isSaveable = false;

        [Tooltip("Сбрасывать ли значение в контейнере при каждом запуске")]
        [SerializeField] protected bool isResettable = true;

        protected bool isFirstCall = true;

        /// <summary>
        /// Задать значение
        /// </summary>
        /// <param name="_val">Значение</param>
        public virtual void SetValue(T _val)
        {
            Value = _val;
        }

        /// <summary>
        /// Задать дефолтное значение
        /// </summary>
        public virtual void SetDefaultValue()
        {
            SetValue(defaultValue);
        }

        protected virtual void OnValueChanged()
        {
            onValueChanged();
        }

        protected virtual bool IsValidId()
        {
            if (id == null)
            {
                EDebug.LogError(this.GetType().Name, $"{nameof(id)} было null.", this);

                return false;
            }

            if (string.IsNullOrWhiteSpace(id.Id))
            {
                EDebug.LogError(this.GetType().Name, $"{nameof(id)} было пустым.", this);

                return false;
            }

            return true;
        }

        public virtual void Reset()
        {
            isFirstCall = true;

            if (isResettable)
            {
                SetDefaultValue();
            }
        }
    }
}
