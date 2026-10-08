namespace skowa.Extensions.CursorManager
{
    using System;
    using System.Collections.Generic;

    using UnityEngine;

    /// <summary>
    /// Дата анимированного курсора
    /// </summary>
    [Serializable]
    public class AnimatedCursorData : CursorData
    {
        /// <summary>
        /// Время кадра в миллисекундах
        /// </summary>
        public int FrameTime = 50;

        /// <summary>
        /// Кадры анимации
        /// </summary>
        public List<Sprite> Sprites = new List<Sprite>();

        /// <summary>
        /// Преобразовать спрайт в текстуру
        /// </summary>
        /// <param name="_sprite">Спрайт</param>
        /// <returns>Текстура</returns>
        public virtual Texture2D SpriteToTexture(Sprite _sprite)
        {
            Rect _rect = _sprite.rect;
            Texture2D _tex = new Texture2D((int)_rect.width, (int)_rect.height, TextureFormat.RGBA32, false);

            _tex.SetPixels(_sprite.texture.GetPixels((int)_rect.x, (int)_rect.y, (int)_rect.width, (int)_rect.height));
            _tex.Apply();

            return _tex;
        }
    }
}
