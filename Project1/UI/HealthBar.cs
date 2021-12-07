using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.UI
{
    class HealthBar : IUIElement
    {
        int maxValue;
        int maxContainers;
        int heartContainers;
        int rows = 2;
        int columns = 8;
        int spacing = 8;
        int displayValue;

        public ISprite[] Sprites { get; set; }
        public Vector2 Position { get; set; }
        public HealthBar(Vector2 position, int initHeartContainers)
        {
            maxContainers = Constants.maxHearts;
            SetHeartContainerCount(initHeartContainers);
            maxValue = heartContainers * Constants.HP_PER_HEART;
            Position = position;
            Sprites = new ISprite[maxContainers];
            SetValue(Constants.maxHearts);
        }

        public void SetValue(int newValue)
        {
            displayValue = Math.Clamp(newValue, 0, maxValue);

            bool isHalf = (displayValue % 2) == 1;
            int heartIndex = displayValue / 2;

            // Fill the leading hearts
            for (int i = 0; i < heartIndex; i++)
            {
                Sprites[i] = SpriteFactory.Instance.CreateSprite("full_heart");
            }

            // Set the tail heart
            if (isHalf)
            {
                Sprites[heartIndex] = SpriteFactory.Instance.CreateSprite("half_heart");
            }
            else
            {
                Sprites[heartIndex] = SpriteFactory.Instance.CreateSprite("empty_heart");
            }

            // Fill in the empty hearts
            for (int i = heartIndex + 1; i < heartContainers; i++)
            {
                Sprites[i] = SpriteFactory.Instance.CreateSprite("empty_heart");
            }
            // Fill in the blanks
            for (int i = heartContainers; i < Constants.maxHearts; i++)
            {
                Sprites[i] = SpriteFactory.Instance.CreateSprite("UI_blank");
            }

        }
        public void AddHeartContainer()
        {
            if (heartContainers < Constants.maxHearts)
                heartContainers++;
        }

        public void SetHeartContainerCount(int count)
        {
            heartContainers = Math.Clamp(count, 0, Constants.maxHearts - 1); // " - 1 " is a quick hacky fix
            maxValue = heartContainers * Constants.HP_PER_HEART;
        }

        public void Draw(SpriteBatch sb)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    Sprites[column + (row * columns)].Draw(sb, Position + new Vector2((column * spacing), row * spacing));
                }
            }
            
        }
    }
}
