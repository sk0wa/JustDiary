namespace skowa.UI.Text
{
    using UnityEngine;

    /// <summary>
    /// Ограничитель количества символов текста
    /// </summary>
    public class TextSymbolLimiter : AbstractTextChangedTMP
    {
        [SerializeField, Min(1)] protected int maxLength = 16;
        [SerializeField] protected string endline = "...";

        protected bool isUpdating = false;

        protected override void ActionOnTextChanged()
        {
            if (Text.text.Length > maxLength && !isUpdating)
            {
                isUpdating = true;

                string _text = Text.text.Substring(0, maxLength);

                if (endline.Length < maxLength)
                {
                    _text = _text.Substring(0, maxLength - endline.Length) + endline;
                }

                Text.text = _text;
                Text.ForceMeshUpdate();

                isUpdating = false;
            }
        }
    }
}
