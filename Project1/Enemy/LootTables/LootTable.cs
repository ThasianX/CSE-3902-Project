using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Project1.Objects;
using Project1.Interfaces;

namespace Project1.Enemy
{
    public abstract class LootTable
    {
        Random rand = new Random();

        Vector2 tempPos = new Vector2(0, 0);

        Dictionary<Rarity, List<Type>> loots = new Dictionary<Rarity, List<Type>>()
        {
            { Rarity.Common,    new List<Type>() { typeof(BlueRuby), typeof(WoodArrowPickup) } },
            { Rarity.Uncommon,  new List<Type>() { typeof(YellowRuby), typeof(Heart) } },
            { Rarity.Rare,      new List<Type>() { typeof(FlashingRuby), typeof(BombPickup) } }
        };

        public Type GetLootType()
        {
            int lootTier = rand.Next(0, 99);

            Rarity rarity = GetRarity(lootTier);

            Type item = GetItem(rarity);

            return item;
        }

        public Type GetItem(Rarity rare)
        {
            List<Type> lootTypes = loots[rare];
            int itemIndex = rand.Next(0, lootTypes.Count);
            return lootTypes[itemIndex];
        }

        //Made a simple loot tier table with 3 rarities, can be overridden to include more.
        public Rarity GetRarity(int lootTier)
        {
            Rarity rare = Rarity.Common;
            //Common -> 50%
            if (lootTier <= 49)
            {
                rare = Rarity.Common;
            }
            //Uncommon -> 35%
            else if (lootTier <= 84)
            {
                rare = Rarity.Uncommon;
            }
            //Rare -> 15%
            else if (lootTier <= 99)
            {
                rare = Rarity.Rare;
            }

            return rare;
        }
    }
    public enum Rarity
    {
        Common,
        Uncommon,
        Rare,
        Epic,
        Mythic,
        Legendary,
    }
}

