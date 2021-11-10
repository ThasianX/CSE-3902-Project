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
        public ISprite background = SpriteFactory.Instance.CreateSprite("HUD_frame");

        Dictionary<Type, Counter> itemCounters = new Dictionary<Type, Counter>();

        HealthBar healthBar = new HealthBar(new Vector2(176, 32), 16);

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
            itemCounters.Add(typeof(BombPickup), new Counter(new Vector2(112, 40)));
            itemCounters.Add(typeof(BlueRuby), new Counter(new Vector2(112, 16)));
            itemCounters.Add(typeof(Key), new Counter(new Vector2(112, 32)));

            // Register which items are displayed to the UI with the InventoryManager
            InventoryManager.Instance.AddUIItem(typeof(BombPickup));
            InventoryManager.Instance.AddUIItem(typeof(BlueRuby));
            InventoryManager.Instance.AddUIItem(typeof(Key));
        }

        public void Draw(SpriteBatch sb)
        {
            background.Draw(sb, Vector2.Zero);

            foreach (Counter counter in itemCounters.Values)
            {
                counter.Draw(sb);
            }

            healthBar.Draw(sb);
        }

        public void UpdateCounter(Type type, int newValue)
        {
            itemCounters[type].SetValue(newValue);
        }
    }
}
