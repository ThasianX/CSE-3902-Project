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
        private IInventoryItem primary;
        private IInventoryItem secondary;

        private static InventoryManager instance = new InventoryManager();

        public IInventoryItem SelectedItem
        {
            get
            {
                return itemInv.ElementAt(selectedSlot).Key;
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
            UIManager.Instance.UpdateSelection(selectedSlot);
        }

        public void SelectPrevious()
        {
            selectedSlot = --selectedSlot % itemInv.Count;
            UIManager.Instance.UpdateSelection(selectedSlot);
        }

        public void Reset()
        {
            instance = new InventoryManager();
        }

        public bool HasTriforce()
        {
            return HasItem(new Triforce(Vector2.Zero));
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
                itemInv.Add(item, quantity);

                UIManager.Instance.UpdateInventory(GetItems());

                if (GetCount(item) > item.MaxStackCount)
                {
                    SetCount(item, item.MaxStackCount);
                }

                if (!countedItems.Contains(item.GetType())) // BAD
                { // BAD
                    if (primary == null)
                    {
                        EquipPrimary(item);
                    }
                    else if (secondary == null)
                    {
                        EquipSecondary(item);
                    }
                } // BAD
                    
            }

            Console.WriteLine(item.GetType());
            if (countedItems.Contains(item.GetType()))
            {
                UIManager.Instance.UpdateCounter(item.GetType(), GetCount(item));
            }

            //TEMP
            SelectNext();
            
        }

        public bool HasItem(IInventoryItem checkItem)
        {
            foreach (IInventoryItem item in itemInv.Keys)
            {
                if (item.GetType() == checkItem.GetType())
                    return true;
            }
            return false;
        }

        public int GetCount(IInventoryItem checkItem)
        {
            foreach (IInventoryItem item in itemInv.Keys)
            {
                if (item.GetType() == checkItem.GetType())
                    return itemInv[item];
            }
            return 0;
        }

        public void SetCount(IInventoryItem checkItem, int count)
        {
            foreach (IInventoryItem item in itemInv.Keys)
            {
                if (item.GetType() == checkItem.GetType())
                {
                    itemInv[item] = count;
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
            Type itemType = item.GetType();
            if (true)//item.IsConsumable)
            {
                itemInv[item] -= quantity;
                if (itemInv[item] <= 0)
                {
                    itemInv.Remove(item);
                }
            }
/*            else
            {
                weapons.Remove(item);
                UIManager.Instance.UpdatePrimarySlot(null);
            }
*/
            Console.WriteLine(item.GetType());
            if (countedItems.Contains(item.GetType()))
            {
                UIManager.Instance.UpdateCounter(item.GetType(), itemInv[item]);
            }
            
        }

        public void AddCountedItem(Type type)
        {
            countedItems.Add(type);
        }

        public void EquipPrimary(IInventoryItem item)
        {
            if (HasItem(item))
            {
                primary = item;
                UIManager.Instance.UpdatePrimarySlot(item);
            }
        }

        public void EquipPrimary()
        {
                primary = SelectedItem;
                UIManager.Instance.UpdatePrimarySlot(SelectedItem);
        }

        public void EquipSecondary(IInventoryItem item)
        {
            if (HasItem(item))
            {
                secondary = item;
                UIManager.Instance.UpdateSecondarySlot(item);
            }
        }

        public void EquipSecondary()
        {
            primary = SelectedItem;
            UIManager.Instance.UpdateSecondarySlot(SelectedItem);
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
    }
}