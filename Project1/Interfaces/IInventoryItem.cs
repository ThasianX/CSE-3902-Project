﻿
namespace Project1.Interfaces
{
    public interface IInventoryItem : IGameObject
    {
        public string Name { get; }
        public bool IsConsumable { get; }
        public int MaxStackCount { get; }
    }
}
