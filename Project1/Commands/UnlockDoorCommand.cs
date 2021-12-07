using Project1.Interfaces;
using Project1.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Commands
{
    class UnlockDoorCommand : ICommand
    {

        private LockedDoor door;

        public UnlockDoorCommand(LockedDoor LockedDoor)
        {
            this.door = LockedDoor;
        }

        public void Execute()
        {
            if (InventoryManager.Instance.HasItem(Key.staticInstance))
            {
                Door newDoor = new Door(door.Position, ((IExit)door).direction, ((IExit)door).nextRoom);
                GameObjectManager.Instance.RemoveOnNextFrame(door);
                GameObjectManager.Instance.AddOnNextFrame(newDoor);
            }
        }
    }
}
