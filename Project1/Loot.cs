using System;
using System.Collections;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Project1.Controllers;
using Project1.Interfaces;
using Project1.GameStates;
using Project1.Levels;
using Project1.Objects;

namespace Project1
{
    public class Loot
    {
        //Single piece of loot that drops on random rates
        //This function generates random numbers to create random items from a Loot Table
        private void RandomLoot(ILootTable lootTable)
        {
            //0 to 99
            int lootTier = Mathf.FloorToInt(Random.Range(0, 100));
            //Just placeholder names to visualize rarity
            //Common -> 49%
            if (lootTier <= 48)
            {
                //GetItem from Loot Table
                IItem item = lootTable.GetCommonItem();
                //Create
                GameObjectManager.Instance.AddOnNextFrame(item);
            }
            //Uncommon -> 30%
            else if (lootTier <= 78)
            {
                IItem item = lootTable.GetUncommonItem();
                GameObjectManager.Instance.AddOnNextFrame(item);
            }
            //Rare -> 15%
            else if (lootTier <= 93)
            {
                IItem item = lootTable.GetRareItem();
                GameObjectManager.Instance.AddOnNextFrame(item);
            }
            //Epic -> 5%
            else if (lootTier <= 98)
            {
                IItem item = lootTable.GetEpicItem();
                GameObjectManager.Instance.AddOnNextFrame(item);
            }
            //Mythic -> 1% 
            else if (lootTier <= 99)
            {
                IItem item = lootTable.GetMythicItem();
                GameObjectManager.Instance.AddOnNextFrame(item);
            }
        }
    }
}
