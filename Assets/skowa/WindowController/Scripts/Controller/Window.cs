namespace skowa.WindowController
{
    using System;

    using UnityEngine;

    using skowa.Extensions.GameObject;

    /// <summary>
    /// Компонент окна
    /// </summary>
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Canvas))]
    public class Window : IsActiveNotifier
    {
        /// <summary>
        /// Событие изменения фокуса окна
        /// </summary>
        public event Action onFocusChanged = delegate { };

        /// <summary>
        /// Находится ли окно в фокусе
        /// </summary>
        public bool IsFocused
        {
            get => isFocused;
            set
            {
                bool _val = value && (gameObject.activeSelf && Application.isFocused);

                if (isFocused != _val)
                {
                    isFocused = _val;
                    if (isFocused && isFrontOnFocused)
                    {
                        transform.SetAsLastSibling();
                    }

                    onFocusChanged();
                }
            }
        }
        protected bool isFocused = false;

        [SerializeField] protected bool isFrontOnFocused = true;

        protected override void OnEnable()
        {
            base.OnEnable();

            IsFocused = true;
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            IsFocused = false;
        }

        protected virtual void OnApplicationFocus(bool _focus)
        {
            if (!_focus)
            {
                IsFocused = false;
            }
        }
    }
}
