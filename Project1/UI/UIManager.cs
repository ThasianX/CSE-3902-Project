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
    sealed class UIManager
    {
        public ISprite HUDFrame = SpriteFactory.Instance.CreateSprite("HUD_frame");
        public ISprite inventoryFrame = SpriteFactory.Instance.CreateSprite("inventory_frame");
        public ISprite mapFrame = SpriteFactory.Instance.CreateSprite("map_frame");

        Dictionary<Type, Counter> itemCounters = new Dictionary<Type, Counter>();

        Counter rupeeCounter = new Counter(new Vector2(112, 16));

        HealthBar healthBar = new HealthBar(new Vector2(176, 32), 3);

        PickupSlot primarySlot = new PickupSlot(new Vector2(152, 24));

        PickupSlot secondarySlot = new PickupSlot(new Vector2(128, 24));

        Minimap map = new Minimap(new Vector2(32, 12));

        // this shouldnt be public, but it needs to be for a quick hacky solution
        public DisplayInventory inventory = new DisplayInventory(new Vector2(125, 45));

        private static UIManager instance = new UIManager();
        public static UIManager Instance
        {
            get
            {
                return instance;
            }
        }

        public void Reset()
        {
            instance = new UIManager();
        }

        private UIManager()
        {
            // Create Counter objects and add to dictionary
            itemCounters.Add(typeof(BombPickup), new Counter(new Vector2(112, 40)));
            itemCounters.Add(typeof(Key), new Counter(new Vector2(112, 32)));

            // Register which items are displayed to the UI with the InventoryManager
            InventoryManager.Instance.AddCountedItem(typeof(BombPickup));
            InventoryManager.Instance.AddCountedItem(typeof(Key));
        }

        public void Draw(SpriteBatch sb)
        {
            HUDFrame.Draw(sb, Vector2.Zero);

            foreach (Counter counter in itemCounters.Values)
            {
                counter.Draw(sb);
            }

            healthBar.Draw(sb);
            rupeeCounter.Draw(sb);
            primarySlot.Draw(sb);
            secondarySlot.Draw(sb);
            map.Draw(sb);
        }

        public void UpdateCounter(Type type, int newValue)
        {
            itemCounters[type].SetValue(newValue);
        }

        public void UpdateRupees(int newValue)
        {
            rupeeCounter.SetValue(newValue);
        }

        public void UpdateHealthBar(int newValue, int HeartContainers)
        {
            healthBar.SetHeartContainerCount(HeartContainers);
            healthBar.SetValue(newValue);
        }

        public void UpdatePrimarySlot(IInventoryItem item)
        {
            primarySlot.SetDisplay(item);
        }

        public void UpdateSecondarySlot(IInventoryItem item)
        {
            secondarySlot.SetDisplay(item);
        }

        public void UpdateInventory(List<IInventoryItem> items)
        {
            inventory.UpdateItems(items);
        }

        public void UpdateSelection(int selection)
        {
            inventory.UpdateSelection(selection);
        }

        // update marker
        public void UpdateMinimap(Direction direction)
        {
            map.MoveMarker(direction);
        }

        // update to a new maze
        public void UpdateMinimap()
        {
            map.SetMap();
            map.SetMarker(0, 0);
        }
    }
}
