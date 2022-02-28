using Microsoft.Xna.Framework;
using Project1.Interfaces;
using Project1.Levels;

namespace Project1.Commands
{
    class MoveDownStairsCommand : ICommand
    {
        IPortal portal;

        public MoveDownStairsCommand(IPortal portal)
        {
            this.portal = portal;
        }

        public void Execute()
        {
            Game1.instance.isTransitioning = true;
            Game1.instance.nextRoomId = portal.NextRoom;
            Room nextRoom = LevelManager.Instance.ActivateNextRoom(portal.NextRoom);
            GameObjectManager.Instance.GetPlayer().Position = new Vector2(portal.NewRoomPosition.X, portal.NewRoomPosition.Y);
            WindowManager.Instance.MoveCamera(portal.Direction);
        }
    }
}
//Team JellyLake Autumn 2021
