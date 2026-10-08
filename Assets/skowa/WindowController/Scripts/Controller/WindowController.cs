namespace skowa.WindowController
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using UnityEngine;

    using skowa.EDebug;
    using skowa.Data.ID;
    using skowa.Patterns.Singleton;

    /// <summary>
    /// Контроллер окон
    /// </summary>
    public class WindowController : Singleton<WindowController>
    {
        /// <summary>
        /// Событие изменения текущего окна
        /// </summary>
        public event Action onCurrentWindowChanged = delegate { };

        /// <summary>
        /// Текущее окно
        /// </summary>
        public Window CurrentWindow
        {
            get => currentWindow;
            protected set
            {
                if (currentWindow != value)
                {
                    currentWindow = value;
                    CurrentWindowId = value == null ? null : windows.FirstOrDefault(_x => _x.Value == value).Key;

                    onCurrentWindowChanged();
                }
            }
        }
        protected Window currentWindow = default;

        /// <summary>
        /// Идентификатор текущего окна
        /// </summary>
        public ID CurrentWindowId { get; protected set; } = default;

        [SerializeField] protected WindowAsset startWindow = default;
        [SerializeField] protected List<WindowAsset> availableWindows = new List<WindowAsset>();

        protected Dictionary<ID, Window> windows = new Dictionary<ID, Window>();
        protected Stack<ID> historyWindows = new Stack<ID>();

        protected virtual void OnValidate()
        {
            if (startWindow != null)
            {
                if (!availableWindows.Contains(startWindow))
                {
                    availableWindows.Insert(0, startWindow);
                }
            }
            else if (availableWindows.Count > 0)
            {
                startWindow = availableWindows[0];
            }
        }

        protected override void Awake()
        {
            base.Awake();

            HandlePossibleErrors();
            Init();

            if (!IsWindowNull(startWindow))
            {
                OpenWindow(startWindow, false);
            }
            else
            {
                if (availableWindows.Count > 0)
                {
                    startWindow = availableWindows[0];
                    OpenWindow(startWindow, false);

                    EDebug.LogError(this.GetType().Name, $"Не удалось открыть стартовое окно - было открыто окно {startWindow.name} как стартовое.", this);
                }
                else
                {
                    EDebug.LogError(this.GetType().Name, $"Не удалось открыть стартовое окно - все окна были null.", this);
                }
            }
        }

        /// <summary>
        /// Открыть окно
        /// </summary>
        /// <param name="_window">Ассет окна</param>
        /// <param name="_closeCurrent">Закрыть текущее окно</param>
        public virtual void OpenWindow(WindowAsset _window, bool _closeCurrent = true)
        {
            if (IsWindowNull(_window))
            {
                EDebug.LogError(this.GetType().Name, $"Не удалось открыть окно - ошибка null.", this);

                return;
            }

            if (!windows.ContainsKey(_window.Id))
            {
                EDebug.LogError(this.GetType().Name, $"Не удалось открыть окно {_window.name} (ID = {_window.Id.Id}).", this);

                return;
            }

            if (CurrentWindowId == _window.Id)
            {
                return;
            }

            if (_closeCurrent)
            {
                CloseWindow(false);
            }
            OpenWindow(_window.Id);
        }

        /// <summary>
        /// Закрыть окно
        /// </summary>
        public virtual void CloseWindow()
        {
            CloseWindow(true);
        }

        protected virtual void Init()
        {
            foreach (WindowAsset _window in availableWindows)
            {
                windows.TryAdd(_window.Id, _window.Window);
            }

            foreach (ID _id in windows.Keys.ToList())
            {
                windows[_id] = Instantiate(windows[_id], transform);
                windows[_id].gameObject.SetActive(false);
            }
        }

        protected virtual void OpenWindow(ID _windowId)
        {
            if (CurrentWindow != null)
            {
                CurrentWindow.IsFocused = false;
            }

            CurrentWindow = windows[_windowId];
            SetCurrentWindow(true);
        }

        protected virtual void CloseWindow(bool _openPrevious)
        {
            SetCurrentWindow(false);

            if (_openPrevious)
            {
                if (historyWindows.Count > 0)
                {
                    OpenWindow(historyWindows.Peek());
                    HandleHistory(false);
                }
                else
                {
                    EDebug.LogError(this.GetType().Name, $"Не удалось открыть предыдущее окно - история окон была пустой.", this);
                }
            }
            else
            {
                HandleHistory(true);
            }
        }

        protected virtual void SetCurrentWindow(bool _status)
        {
            if (CurrentWindow == null)
            {
                return;
            }

            CurrentWindow.gameObject.SetActive(_status);
            CurrentWindow.IsFocused = _status;
        }

        protected virtual void HandleHistory(bool _isPush)
        {
            if (_isPush)
            {
                if (CurrentWindowId != null)
                {
                    historyWindows.Push(CurrentWindowId);
                }
                else
                {
                    EDebug.LogError(this.GetType().Name, $"Не удалось добавить элемент в историю окон - идентификатор окна был null.", this);
                }
            }
            else
            {
                if (historyWindows.Count > 0)
                {
                    historyWindows.Pop();
                }
                else
                {
                    EDebug.LogError(this.GetType().Name, $"Не удалось удалить последний элемент из истории окон - количество элементов было 0.", this);
                }
            }
        }

        #region ERROR HANDLERS
        protected bool IsWindowNull(WindowAsset _window)
        {
            return _window == null || _window.Id == null || _window.Window == null;
        }

        protected virtual void HandlePossibleErrors()
        {
            HandleNullWindows();
            HandleDuplicateWindows();
        }

        protected virtual void HandleNullWindows()
        {
            availableWindows.RemoveAll(_x => IsWindowNull(_x));
        }

        protected virtual void HandleDuplicateWindows()
        {
            List<WindowAsset> _duplicates = new List<WindowAsset>();
            List<WindowAsset> _duplicatesIteration = new List<WindowAsset>();

            for (int _i = 0; _i < availableWindows.Count - 1; _i++)
            {
                if (_duplicates.Contains(availableWindows[_i]))
                {
                    continue;
                }

                for (int _j = _i + 1; _j < availableWindows.Count; _j++)
                {
                    if (availableWindows[_i].Id == availableWindows[_j].Id)
                    {
                        _duplicatesIteration.Add(availableWindows[_j]);
                    }
                }

                if (_duplicatesIteration.Count > 0)
                {
                    EDebug.LogError(this.GetType().Name, $"Для окна {availableWindows[_i].name} (ID = {availableWindows[_i].Id.Id}) были обнаружены дубликаты: {string.Join(", ", _duplicatesIteration.Select(_x => _x.name).ToList())}.", this);

                    _duplicates.AddRange(_duplicatesIteration);
                    _duplicatesIteration.Clear();
                }
            }

            foreach (WindowAsset _dublicate in _duplicates)
            {
                availableWindows.Remove(_dublicate);
            }
        }
        #endregion
    }
}
