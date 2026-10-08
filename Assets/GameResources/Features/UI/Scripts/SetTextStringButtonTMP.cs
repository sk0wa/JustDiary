namespace JustDiary.UI
{
    using UnityEngine;
    using TMPro;

    using skowa.UI.AbstractView;
    using skowa.Data.ValueContainer;

    /// <summary>
    /// Кнопка сеттинга строки TMP текста в контейнер
    /// </summary>
    public class SetInputFieldStringButtonTMP : AbstractButton
    {
        [SerializeField] protected TMP_Text text = default;
        [SerializeField] protected StringValueContainer container = default;

        public override void OnButtonClicked()
        {
            if (text != null && container != null)
            {
                container.SetValue(text.text.Replace("\u200B", ""));
            }
        }
    }
}
