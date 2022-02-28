using System.Collections.Generic;
using Project1.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.ObjectModel;
using Project1.Objects;
using System;
using System.Linq;

namespace Project1
{
    public class InventoryManager
    {
        //Tracks consumables and weapons
        public Dictionary<IInventoryItem, int> itemInv = new Dictionary<IInventoryItem, int>();
        public List<Type> countedItems = new List<Type>();
        public int rupees = 0;

        private int selectedSlot = 0;
        private IEquippable primary;
        private IEquippable secondary;

        private static InventoryManager instance = new InventoryManager();

        public IInventoryItem SelectedItem
        {
            get
            {
                return itemInv.Count > 0 ? itemInv.ElementAt(selectedSlot).Key : null;
            }
        }
        public static InventoryManager Instance
        {
            get
            {
                return instance;
            }
        }

        public void SelectNext()
        {
            selectedSlot = ++selectedSlot % itemInv.Count;
            Console.WriteLine("selected slot: " + selectedSlot);
            UIManager.Instance.UpdateSelection(selectedSlot);
        }

        public void SelectPrevious()
        {
            selectedSlot--;
            if (selectedSlot < 0)
                selectedSlot = itemInv.Count - 1;

            UIManager.Instance.UpdateSelection(selectedSlot);
        }

        public void Reset()
        {
            instance = new InventoryManager();
        }
        
        public void AddItem(IInventoryItem item, int quantity = 1)
        {
            //If Item already in inventory
            if (HasItem(item))
            {
                SetCount(item, GetCount(item) + quantity);
                if (GetCount(item) > item.MaxStackCount)
                {
                    SetCount(item, item.MaxStackCount);
                }
            }
            //If item not in inventory
            else if (!HasItem(item))
            {
                itemInv.Add(item.StaticInstance, quantity);

                UIManager.Instance.UpdateInventory(GetItems());

                if (GetCount(item) > item.MaxStackCount)
                {
                    SetCount(item, item.MaxStackCount);
                }   
            }

            Console.WriteLine(item.GetType());
            if (countedItems.Contains(item.GetType()))
            {
                UIManager.Instance.UpdateCounter(item.GetType(), GetCount(item));
            }
        }

        public bool HasItem(IInventoryItem checkItem)
        {
            // ensure we have the static reference
            IInventoryItem staticInst = checkItem.StaticInstance;
            foreach (IInventoryItem item in itemInv.Keys)
            {
                if (item.StaticInstance == checkItem.StaticInstance)
                    return true;
            }
            return false;
        }

        public int GetCount(IInventoryItem checkItem)
        {
            // ensure we have the static reference
            IInventoryItem staticInst = checkItem.StaticInstance;
            foreach (IInventoryItem item in itemInv.Keys)
            {
                if (item.StaticInstance == staticInst)
                    return itemInv[staticInst];
            }
            return 0;
        }

        public void SetCount(IInventoryItem checkItem, int count)
        {
            // ensure we have the static reference
            IInventoryItem staticInst = checkItem.StaticInstance;
            foreach (IInventoryItem item in itemInv.Keys)
            {
                if (item.StaticInstance == staticInst)
                {
                    itemInv[staticInst] = count;
                    return;
                }
            }
        }

        public List<IInventoryItem> GetItems()
        {
            List<IInventoryItem> items = new List<IInventoryItem>();
            foreach (IInventoryItem item in itemInv.Keys)
            {
                items.Add(item);
            }
            return items;
        }

        public void AddRupees(int amount)
        {
            rupees += amount;
            if (rupees < 0)
            {
                rupees = 0;
            }
            else if (rupees > 99)
            {
                rupees = 99;
            }

            UIManager.Instance.UpdateRupees(rupees);
        }

        public void RemoveItem(IInventoryItem item, int quantity = 1)
        {
            // ensure we have the static reference
            IInventoryItem staticInst = item.StaticInstance;

            if (HasItem(staticInst))
            {
                itemInv[staticInst] -= quantity;
                if (itemInv[staticInst] <= 0)
                {
                    if (countedItems.Contains(item.GetType()) || !HasItem(staticInst))
                    {
                        UIManager.Instance.UpdateCounter(item.GetType(), itemInv[staticInst]);
                    }

                    itemInv.Remove(staticInst);
                    UIManager.Instance.UpdateInventory(GetItems());
                }
            }
        }

        public void AddCountedItem(Type type)
        {
            countedItems.Add(type);
        }

        public void EquipPrimary(IEquippable item)
        {
            // ensure we have the static reference
            IEquippable staticInst = (IEquippable) item.StaticInstance;
            if (HasItem(staticInst))
            {
                primary = staticInst;
                UIManager.Instance.UpdatePrimarySlot(staticInst);
            }
        }

        public void EquipSelectedPrimary()
        {
            if (SelectedItem is IEquippable)
            {
                EquipPrimary(SelectedItem as IEquippable);
            }
        }

        public void EquipSelectedSecondary()
        {
            if (SelectedItem is IEquippable)
            {
                EquipSecondary(SelectedItem as IEquippable);
            }
        }

        public void EquipSecondary(IEquippable item)
        {
            // ensure we have the static reference
            IEquippable staticInst = (IEquippable) item.StaticInstance;
            if (HasItem(staticInst))
            {
                secondary = staticInst;
                UIManager.Instance.UpdateSecondarySlot(staticInst);
            }
        }

        public void UnequipPrimary()
        {
            if (primary != null)
            {
                primary = null;
                UIManager.Instance.UpdatePrimarySlot(null);
            }
        }

        public void UnequipSecondary()
        {
            if (secondary != null)
            {
                secondary = null;
                UIManager.Instance.UpdatePrimarySlot(null);
            }
        }

        public void UsePrimary(IPlayer player)
        {
            if (primary != null)
                primary.Use(player);
        }

        public void UseSecondary(IPlayer player)
        {
            if (secondary != null)
                secondary.Use(player);
        }
    }
}
//Team JellyLake Autumn 2021
