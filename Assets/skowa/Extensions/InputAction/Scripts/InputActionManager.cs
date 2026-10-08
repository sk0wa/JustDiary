namespace skowa.Extensions.InputAction
{
    using System.Collections.Generic;

    using UnityEngine;
    using UnityEngine.InputSystem;

    using skowa.EDebug;
    using skowa.Patterns.Singleton;

    /// <summary>
    /// Менеджер инпутов
    /// </summary>
    /// 
    /// NOTE: Стоит задать порядок выполнения скриптов
    public class InputActionManager : Singleton<InputActionManager>
    {
        [SerializeField] protected List<InputActionReference> inputs = new List<InputActionReference>();

        protected virtual void OnEnable()
        {
            ChangeInputsEnabled(true, this);
        }

        protected virtual void OnDisable()
        {
            ChangeInputsEnabled(false, this);
        }

        /// <summary>
        /// Попробовать включить инпут
        /// </summary>
        /// <param name="_input">Инпут</param>
        /// <param name="_caller">Вызывающий</param>
        /// <returns></returns>
        public virtual bool TryEnableInput(InputActionReference _input, Object _caller = null)
        {
            int _idx = inputs.IndexOf(_input);

            if (_idx == -1)
            {
                EDebug.LogError(this.GetType().Name, $"Не удалось найти заданный инпут.", this);

                return false;
            }

            inputs[_idx].action.Enable();

            EDebug.Log(this.GetType().Name, $"Был включен инпут {_input.name}.", _caller != null ? _caller : this);

            return true;
        }

        /// <summary>
        /// Попробовать выключить инпут
        /// </summary>
        /// <param name="_input">Инпут</param>
        /// <param name="_caller">Вызывающий</param>
        /// <returns></returns>
        public virtual bool TryDisableInput(InputActionReference _input, Object _caller = null)
        {
            int _idx = inputs.IndexOf(_input);

            if (_idx == -1)
            {
                EDebug.LogError(this.GetType().Name, $"Не удалось найти заданный инпут.", this);

                return false;
            }

            inputs[_idx].action.Disable();

            EDebug.Log(this.GetType().Name, $"Был выключен инпут {_input.name}.", _caller != null ? _caller : this);

            return true;
        }

        /// <summary>
        /// Изменить активность всех инпутов
        /// </summary>
        /// <param name="_enabled">Активность</param>
        /// <param name="_caller">Вызывающий</param>
        public virtual void ChangeInputsEnabled(bool _enabled, Object _caller)
        {
            if (_caller == null)
            {
                EDebug.LogError(this.GetType().Name, $"Попытка изменить активность инпутов неизвестным объектом.", this);

                return;
            }

            for (int _i = 0; _i < inputs.Count; _i++)
            {
                if (inputs[_i] != null)
                {
                    if (_enabled)
                    {
                        inputs[_i].action.Enable();
                    }
                    else
                    {
                        inputs[_i].action.Disable();
                    }
                }
            }

            EDebug.Log(this.GetType().Name, $"Были {(_enabled ? "включены" : "выключены")} все инпуты объектом {_caller.name}.", _caller);
        }
    }
}
