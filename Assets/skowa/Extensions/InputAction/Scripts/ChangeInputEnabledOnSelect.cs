namespace skowa.Extensions.InputAction
{
    using System.Collections.Generic;

    using UnityEngine;
    using UnityEngine.InputSystem;
    using UnityEngine.EventSystems;

    /// <summary>
    /// Изменение активности инпута при выборе Selectable объекта
    /// </summary>
    public class ChangeInputEnabledOnSelect : MonoBehaviour, ISelectHandler, IDeselectHandler
    {
        [SerializeField] protected List<InputActionReference> inputs = new List<InputActionReference>();
        protected List<bool> inputsEnabled = new List<bool>();

        [SerializeField, Tooltip("Задать изначальную активность на OnDisable")] protected bool setOriginalEnabledOnDisable = true;

        protected virtual void Awake()
        {
            for (int _i = 0; _i < inputs.Count; _i++)
            {
                inputsEnabled.Add(inputs[_i] != null && inputs[_i].action.enabled);
            }
        }

        protected virtual void OnEnable()
        {
            if (!setOriginalEnabledOnDisable)
            {
                return;
            }

            for (int _i = 0; _i < inputs.Count; _i++)
            {
                inputsEnabled[_i] = inputs[_i] != null && inputs[_i].action.enabled;
            }
        }

        protected virtual void OnDisable()
        {
            if (!setOriginalEnabledOnDisable)
            {
                return;
            }

            for (int _i = 0; _i < inputs.Count; _i++)
            {
                if (inputs[_i] != null)
                {
                    if (inputsEnabled[_i])
                    {
                        inputs[_i].action.Enable();
                    }
                    else
                    {
                        inputs[_i].action.Disable();
                    }
                }
            }
        }

        public virtual void OnSelect(BaseEventData _eventData)
        {
            foreach (InputActionReference _input in inputs)
            {
                if (_input != null)
                {
                    _input.action.Disable();
                }
            }
        }

        public virtual void OnDeselect(BaseEventData _eventData)
        {
            foreach (InputActionReference _input in inputs)
            {
                if (_input != null)
                {
                    _input.action.Enable();
                }
            }
        }
    }
}
