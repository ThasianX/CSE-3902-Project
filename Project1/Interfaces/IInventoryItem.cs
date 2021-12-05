
namespace Project1.Interfaces
{
    public interface IInventoryItem : IGameObject
    {
        public string Name { get; }
        public IInventoryItem StaticInstance { get; } // This is the instance used in inventory stacks
        public bool IsConsumable { get; }
        public int MaxStackCount { get; }
        public ISprite Sprite { get; }
    }
}
