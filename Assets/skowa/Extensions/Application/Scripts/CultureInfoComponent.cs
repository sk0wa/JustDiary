namespace skowa.Extensions.Application
{
    using System.Globalization;

    using UnityEngine;

    using skowa.Patterns.Singleton;

    /// <summary>
    /// Компонент задания культуры для приложения
    /// </summary>
    /// 
    /// NOTE: Стоит задать порядок выполнения скриптов
    public sealed class CultureInfoComponent : Singleton<CultureInfoComponent>
    {
        public CultureInfo CurrentCulture => _currentCulture;
        private CultureInfo _currentCulture = CultureInfo.CurrentCulture;

        [SerializeField] private string _cultureName = "ru-RU";

        protected override void Awake()
        {
            base.Awake();

            _currentCulture = new CultureInfo(_cultureName);

            CultureInfo.DefaultThreadCurrentCulture = _currentCulture;
            CultureInfo.DefaultThreadCurrentUICulture = _currentCulture;
        }
    }
}
