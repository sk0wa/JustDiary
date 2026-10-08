namespace skowa.Patterns.Resettable
{
    using UnityEngine;

    using skowa.Patterns.Singleton;
    using UnityEngine.SceneManagement;

    /// <summary>
    /// Компонент-ресеттер сбрасываемых SO
    /// </summary>
    /// 
    /// NOTE: Стоит задать порядок выполнения скриптов
    public class SOResetterComponent : Singleton<SOResetterComponent>
    {
        [SerializeField] protected bool resetOnEverySceneLoaded = false;

        protected override void Awake()
        {
            base.Awake();

            ResetSO();
        }

        protected virtual void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        protected virtual void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        /// <summary>
        /// Сбросить сбрасываемые SO
        /// </summary>
        public virtual void ResetSO()
        {
            SOResetter.ResetSO();
        }

        protected virtual void OnSceneLoaded(Scene _scene, LoadSceneMode _mode)
        {
            if (resetOnEverySceneLoaded)
            {
                ResetSO();
            }
        }
    }
}
