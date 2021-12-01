using Microsoft.Xna.Framework;
using Project1.Interfaces;
using Project1.Enemy;


namespace Project1
{
    public static class Loot
    {
        //This function gets and instances an item from the enemies loot table.
        public static void RandomLoot(LootTable lootTable, Vector2 position)
        {
            IGameObject item = lootTable.GetLoot();

            //Sets the position of the object to presumably the enemies location before defeat
            item.Position = position;

            if (item != null)
            {
                GameObjectManager.Instance.AddOnNextFrame(item);
            }
        }
    }
}
