namespace skowa.Extensions.InputAction
{
    using UnityEngine;
    using UnityEngine.InputSystem;

    /// <summary>
    /// Базовое действие при инпуте
    /// </summary>
    public class BaseInputAction : MonoBehaviour
    {
        [SerializeField] protected InputActionReference input = default;

        protected virtual void OnEnable()
        {
            if (input != null)
            {
                input.action.performed += OnPerfomed;
                input.action.started += OnStarted;
                input.action.canceled += OnCanceled;
            }
        }

        protected virtual void OnDisable()
        {
            if (input != null)
            {
                input.action.performed -= OnPerfomed;
                input.action.started -= OnStarted;
                input.action.canceled -= OnCanceled;
            }
        }

        protected virtual void OnPerfomed(InputAction.CallbackContext _ctx)
        {
            // NOTE: Переопределить в наследнике
        }

        protected virtual void OnStarted(InputAction.CallbackContext _ctx)
        {
            // NOTE: Переопределить в наследнике
        }

        protected virtual void OnCanceled(InputAction.CallbackContext _ctx)
        {
            // NOTE: Переопределить в наследнике
        }
    }
}
