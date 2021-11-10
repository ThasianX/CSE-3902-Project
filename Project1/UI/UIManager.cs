using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;
using Project1.Objects;
using Project1.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    class UIManager
    {
        private static UIManager instance = new UIManager();
        public static UIManager Instance
        {
            get
            {
                return instance;
            }
        }

        private UIManager()
        {
            // Create Counter objects and add to dictionary
            itemCounters.Add(typeof(BombPickup), new Counter(Vector2.Zero));
            itemCounters.Add(typeof(BlueRuby), new Counter(new Vector2(50, 0)));
            itemCounters.Add(typeof(Key), new Counter(new Vector2(100, 0)));

            // Register which items are displayed to the UI with the InventoryManager
            InventoryManager.Instance.AddUIItem(typeof(BombPickup));
            InventoryManager.Instance.AddUIItem(typeof(BlueRuby));
            InventoryManager.Instance.AddUIItem(typeof(Key));
        }

        public ISprite background = SpriteFactory.Instance.CreateSprite("HUD_frame");

        Dictionary<Type, Counter> itemCounters = new Dictionary<Type, Counter>();

        public void Draw(SpriteBatch sb)
        {
            background.Draw(sb, Vector2.Zero);

            foreach (Counter counter in itemCounters.Values)
            {
                counter.Draw(sb);
            }
        }

        public void UpdateCounter(Type type, int newValue)
        {
            itemCounters[type].SetValue(newValue);
        }

    }
}
