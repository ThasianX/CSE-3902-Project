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

        Dictionary<Rarity, List<IGameObject>> loots = new Dictionary<Rarity, List<IGameObject>>()
        {
            { Rarity.Common,    new List<IGameObject>() { new BlueRuby(new Vector2(0, 0)), new WoodArrowPickup(new Vector2(0, 0)) } },
            { Rarity.Uncommon,  new List<IGameObject>() { new YellowRuby(new Vector2(0, 0)), new Heart(new Vector2(0, 0))} },
            { Rarity.Epic,      new List<IGameObject>() { new FlashingRuby(new Vector2(0,0)), new BombPickup(new Vector2(0, 0))} }
        };

        public IGameObject GetLoot()
        {
            int lootTier = rand.Next(0, 99);

            Rarity rarity = GetRarity(lootTier);

            IGameObject item = GetItem(rarity);

            return item;
        }

        public IGameObject GetItem(Rarity rare)
        {
            List<IGameObject> loot = loots[rare];
            int itemIndex = rand.Next(0, loot.Count);
            return loot[itemIndex];
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

