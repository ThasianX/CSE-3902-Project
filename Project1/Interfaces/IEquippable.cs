using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Interfaces
{
    public interface IEquippable : IInventoryItem
    {
        public void Use(IPlayer player);

    }
}
