namespace skowa.Extensions.CursorManager
{
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;

    using UnityEngine;
    using Unity.VisualScripting;

    using skowa.EDebug;
    using skowa.Extensions.Coroutine;

    /// <summary>
    /// Менеджер курсора
    /// </summary>
    public sealed class CursorManager : skowa.Patterns.Singleton.Singleton<CursorManager>
    {
        /// <summary>
        /// Дефолтный курсор
        /// </summary>
        public CursorType DefaultCursor => _defaultCursor == null ? CursorType.Arrow : _defaultCursor.CursorType;

        /// <summary>
        /// Текущий курсор
        /// </summary>
        public CursorType CurrentCursor
        {
            get => _currentCursor;
            private set
            {
                if (value != _currentCursor)
                {
                    PreviousCursor = _currentCursor;
                    _currentCursor = value;
                }
            }
        }
        private CursorType _currentCursor = CursorType.Arrow;

        /// <summary>
        /// Предыдущий курсор
        /// </summary>
        public CursorType PreviousCursor { get; private set; } = CursorType.Arrow;

        [SerializeField] private CursorData _defaultCursor = default;

        [SerializeField] private List<CursorData> _staticCursors = new List<CursorData>();
        [SerializeField] private List<AnimatedCursorData> _animatedCursors = new List<AnimatedCursorData>();

        private CoroutineExtension coroutine = default;
        private WaitForExtension wait = default;

        protected override void Awake()
        {
            base.Awake();

            coroutine = new CoroutineExtension(this);

            wait = new WaitForExtension();
            wait.WaitType = WaitForType.SecondsRealtime;

            _staticCursors.Insert(0, _defaultCursor);
            _staticCursors = _staticCursors.DistinctBy(_x => _x.CursorType).ToList();

            _animatedCursors = _animatedCursors.DistinctBy(_x => _x.CursorType).ToList();

            SetCursor(DefaultCursor);
        }

        private void OnDisable()
        {
            SetDefaultCursor();
            coroutine.Coroutine = null;
        }

        /// <summary>
        /// Задать курсор
        /// </summary>
        /// <param name="_cursor">Тип курсора</param>
        public void SetCursor(CursorType _cursor)
        {
            if (CurrentCursor == _cursor)
            {
                return;
            }

            if (!HandleStaticCursors(_cursor))
            {
                if (!HandleAnimatedCursors(_cursor))
                {
                    EDebug.LogError(this.GetType().Name, $"Не было найдено заданного курсора {_cursor}.", this);
                }
            }
            else
            {
                coroutine.Coroutine = null;
            }
        }

        /// <summary>
        /// Задать дефолтный курсор
        /// </summary>
        public void SetDefaultCursor()
        {
            SetCursor(DefaultCursor);
        }

        /// <summary>
        /// Задать предыдущий курсор
        /// </summary>
        public void SetPreviousCursor()
        {
            SetCursor(PreviousCursor);
        }

        private bool HandleStaticCursors(CursorType _cursor)
        {
            CursorData _data = _staticCursors.Find(_x => _x.CursorType == _cursor);

            if (_data == null)
            {
                return false;
            }

            if (_data.CursorTexture == null)
            {
                EDebug.LogError(this.GetType().Name, $"Для курсора {_cursor} не была задана текстура.", this);

                return false;
            }

            Cursor.SetCursor(_data.CursorTexture, _data.HotSpot, CursorMode.Auto);
            CurrentCursor = _cursor;

            return true;
        }

        private bool HandleAnimatedCursors(CursorType _cursor)
        {
            AnimatedCursorData _data = _animatedCursors.Find(_x => _x.CursorType == _cursor);

            if (_data == null)
            {
                return false;
            }

            if (_data.Sprites.Count == 0)
            {
                EDebug.LogError(this.GetType().Name, $"Для курсора {_cursor} не были заданы кадры анимации.", this);

                return false;
            }

            coroutine.Coroutine = StartCoroutine(AnimatedCursorCoroutine(_data));
            CurrentCursor = _cursor;

            return true;
        }

        private IEnumerator AnimatedCursorCoroutine(AnimatedCursorData _data)
        {
            int _idx = 0;

            wait.WaitSeconds = _data.FrameTime / 1000f;
            wait.Init();

            while (isActiveAndEnabled)
            {
                Cursor.SetCursor(_data.SpriteToTexture(_data.Sprites[_idx]), _data.HotSpot, CursorMode.Auto);
                _idx = (_idx + 1) % _data.Sprites.Count;

                yield return wait.Wait();
            }
        }
    }
}
