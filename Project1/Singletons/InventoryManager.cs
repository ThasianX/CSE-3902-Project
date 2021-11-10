using System.Collections.Generic;
using Project1.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.ObjectModel;
using Project1.Objects;
using System;

namespace Project1
{
    public class InventoryManager
    {
        //Tracks consumables and weapons
        public Dictionary<Type, int> itemInv = new Dictionary<Type, int>();
        public List<IInventoryItem> weapons = new List<IInventoryItem>();
        public List<Type> UIItems = new List<Type>();
        public int rupees = 0;

        private static InventoryManager instance = new InventoryManager();
        public static InventoryManager Instance
        {
            get
            {
                return instance;
            }
        }
        
        public void AddItem(IInventoryItem item, int quantity = 1)
        {
            Type itemType = item.GetType();
            if (item.IsConsumable)
            {
                //If Item already in inventory
                if (itemInv.ContainsKey(itemType) && (itemInv[itemType] + quantity) < item.MaxStackCount)
                {
                    itemInv[itemType] += quantity;
                    //May need refactored if we want to partially add a stack of items or could return the difference.
                    if (itemInv[itemType] >= item.MaxStackCount)
                    {
                        itemInv[itemType] = item.MaxStackCount;
                    }
                }
                //If item not in inventory
                else if (!itemInv.ContainsKey(itemType))
                {
                    itemInv.Add(itemType, quantity);
                    if (itemInv[itemType] >= item.MaxStackCount)
                    {
                        itemInv[itemType] = item.MaxStackCount;
                    }
                }
                //If inventory is at max quantity for item
                //Do nothing
                //Could remove iteminv[item] + quantity) < item.MaxStackCount from first if and return full value
            }
            //Non-consumable
            else
            {
                weapons.Add(item);
            }

            Console.WriteLine(item.GetType());
            if (UIItems.Contains(item.GetType()))
            {

                UIManager.Instance.UpdateCounter(item.GetType(), itemInv[itemType]);
            }
        }

        public void AddRupees(int amount)
        {
            rupees += amount;
            if (rupees < 0)
            {
                rupees = 0;
            }
            else if (rupees > 999)
            {
                rupees = 999;
            }
        }

        public void Remove(IInventoryItem item, int quantity = 1)
        {
            Type itemType = item.GetType();
            if (item.IsConsumable)
            {
                itemInv[itemType] -= quantity;
                if (itemInv[itemType] <= 0)
                {
                    itemInv.Remove(itemType);
                }
            }
            else
            {
                weapons.Remove(item);
            }

            Console.WriteLine(item.GetType());
            if (UIItems.Contains(item.GetType()))
            {
                
                UIManager.Instance.UpdateCounter(item.GetType(), itemInv[itemType]);
            }
            
        }

        public void AddUIItem(Type type)
        {
            UIItems.Add(type);
        }

        public void RemoveAll()
        {
            itemInv.Clear();
        }
    }
}