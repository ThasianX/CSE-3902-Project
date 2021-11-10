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
        public Dictionary<IInventoryItem, int> itemInv = new Dictionary<IInventoryItem, int>();
        public List<IInventoryItem> weapons = new List<IInventoryItem>();
        public List<Type> UIItems = new List<Type>();

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
            if (item.IsConsumable)
            {
                //If Item already in inventory
                if (itemInv.ContainsKey(item) && (itemInv[item] + quantity) < item.MaxStackCount)
                {
                    itemInv[item] += quantity;
                    //May need refactored if we want to partially add a stack of items or could return the difference.
                    if (itemInv[item] >= item.MaxStackCount)
                    {
                        itemInv[item] = item.MaxStackCount;
                    }
                }
                //If item not in inventory
                else if (!itemInv.ContainsKey(item))
                {
                    itemInv.Add(item, quantity);
                    if (itemInv[item] >= item.MaxStackCount)
                    {
                        itemInv[item] = item.MaxStackCount;
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

                UIManager.Instance.UpdateCounter(item.GetType(), itemInv[item]);
            }
        }

        public void Remove(IInventoryItem item, int quantity = 1)
        {
            if (item.IsConsumable)
            {
                itemInv[item] -= quantity;
                if (itemInv[item] <= 0)
                {
                    itemInv.Remove(item);
                }
            }
            else
            {
                weapons.Remove(item);
            }

            Console.WriteLine(item.GetType());
            if (UIItems.Contains(item.GetType()))
            {
                
                UIManager.Instance.UpdateCounter(item.GetType(), itemInv[item]);
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