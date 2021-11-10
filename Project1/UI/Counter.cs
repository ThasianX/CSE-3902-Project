using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.UI
{
    class Counter : IUIElement
    {
        int maxValue = 99;
        int[] digits = new int[2];
        int spacing = 8;
        private int displayValue;
        public ISprite[] Sprites { get; set; }
        public Vector2 Position { get; set; }
        public Counter(Vector2 position)
        {
            Position = position;
            Sprites = new ISprite[digits.Length];
            SetValue(0);
        }

        public void SetValue(int newValue)
        {
            displayValue = Math.Clamp(newValue, 0, maxValue);

            int remainder = displayValue;
            for (int i = 0; i < digits.Length; i++)
            {
                digits[i] = remainder % 10;
                remainder /= 10;
            }

            for (int i = 0; i < digits.Length; i++)
            {
                Sprites[i] = SpriteFactory.Instance.CreateSprite("digit_" + digits[i]);
            }

        }

        public void Draw(SpriteBatch sb)
        {
            for (int i = 0; i < Sprites.Length; i++)
            {
                Sprites[i].Draw(sb, Position - new Vector2((i * spacing), 0));
            }
        }
    }
}
