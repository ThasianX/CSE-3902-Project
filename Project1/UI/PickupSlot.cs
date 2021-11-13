using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.UI
{
    class PickupSlot : IUIElement
    {
        public Vector2 Position { get; set; }
        public ISprite[] Sprites { get; set; }

        public PickupSlot(Vector2 position)
        {
            Position = position;
            Sprites = new ISprite[1];
        }

        public void SetDisplay(IInventoryItem item)
        {
            Sprites[0] = item.Sprite;
        }

        public void Draw(SpriteBatch sb)
        {
            if (Sprites[0] != null)
                Sprites[0].Draw(sb, Position);
        }
    }
}
