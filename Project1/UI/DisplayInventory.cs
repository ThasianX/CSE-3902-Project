using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.UI
{
    class DisplayInventory : IUIElement
    {
        public Vector2 Position { get; set; }
        public ISprite[] Sprites { get; set; }

        private ISprite selector = SpriteFactory.Instance.CreateSprite("item_selector");
        private int selectedItem = 0;

        private int rows = 2;
        private int columns = 4;
        private int maxItems = 8;

        private int spacing = 24;

        public DisplayInventory(Vector2 position)
        {
            Position = position;
            Sprites = new ISprite[maxItems];
            UpdateItems(new List<IInventoryItem>());
        }

        public void UpdateSelection(int index)
        {

        }

        public void UpdateItems(List<IInventoryItem> items)
        {
            for (int i = 0; i < maxItems; i++)
            {
                if (i < items.Count)
                {
                    Sprites[i] = items[i].Sprite;
                }
                else
                {
                    Sprites[i] = SpriteFactory.Instance.CreateSprite("UI_blank");
                }
            }
        }

        public void UpdateSelector(int index)
        {
            selectedItem = index;
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

            //TODO: Draw selector
        }
    }
}
