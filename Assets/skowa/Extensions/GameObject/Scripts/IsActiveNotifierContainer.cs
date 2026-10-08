namespace skowa.Extensions.GameObject
{
    using UnityEngine;

    using skowa.Data.Container;

    /// <summary>
    /// Контейнер уведомителя изменения статуса активности объекта
    /// </summary>
    [CreateAssetMenu(fileName = nameof(IsActiveNotifierContainer), menuName = "skowa/Extensions/GameObject/" + nameof(IsActiveNotifierContainer))]
    public class IsActiveNotifierContainer : AbstractGenericContainer<IsActiveNotifier>
    {

    }
}
