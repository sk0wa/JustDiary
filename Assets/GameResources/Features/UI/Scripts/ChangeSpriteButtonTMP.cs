namespace JustDiary.UI
{
    using System.Collections.Generic;

    using UnityEngine;
    using UnityEngine.UI;

    using skowa.UI.AbstractView;

    /// <summary>
    /// TMP кнопка изменения спрайта имэджа
    /// </summary>
    public class ChangeSpriteButtonTMP : AbstractButton
    {
        [SerializeField] protected Image targetImage = default;

        [SerializeField] protected List<Sprite> spriteList = new List<Sprite>();
        [SerializeField, Min(0)] protected int startIdx = 1;

        [SerializeField] protected bool resetOnDisable = true;

        protected Sprite defaultSprite = default;
        protected int idx = 0;

        protected virtual void Awake()
        {
            if (targetImage != null)
            {
                defaultSprite = targetImage.sprite;
            }

            startIdx = Mathf.Clamp(startIdx, 0, spriteList.Count - 1);
            idx = startIdx;
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            if (resetOnDisable && targetImage != null)
            {
                SetDefaultSprite();
            }
        }

        /// <summary>
        /// Задать дефолтный спрайт
        /// </summary>
        public virtual void SetDefaultSprite()
        {
            targetImage.sprite = defaultSprite;
            idx = startIdx;
        }

        public override void OnButtonClicked()
        {
            if (targetImage != null)
            {
                targetImage.sprite = spriteList[idx];
                idx = (idx + 1) % spriteList.Count;
            }
        }
    }
}
