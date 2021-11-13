using Microsoft.Xna.Framework;
using Project1.Interfaces;
using Project1.Levels;

namespace Project1.Commands
{
    class MoveToNextRoomCommand : ICommand
    {
        IExit exit;

        public MoveToNextRoomCommand(IExit exit)
        {
            this.exit = exit;
        }

        public void Execute()
        {
            Game1.instance.isTransitioning = true;
            Game1.instance.nextRoomId = exit.nextRoom;
            Room nextRoom = LevelManager.Instance.ActivateNextRoom(exit.nextRoom);
            Rectangle doorRect = nextRoom.GetCorrespondingExit(exit.direction).GetRectangle();
            int newX = exit.direction == Direction.Left ? doorRect.X - doorRect.Width / 2 : exit.direction == Direction.Right ? doorRect.X + doorRect.Width + 4 : doorRect.X;
            int newY = exit.direction == Direction.Up ? doorRect.Y - doorRect.Height / 2 : exit.direction == Direction.Down ? doorRect.Y + doorRect.Height + 4 : doorRect.Y;
            GameObjectManager.Instance.GetPlayer().Position = new Vector2(newX, newY);
            WindowManager.Instance.MoveCamera(exit.direction);
        }
    }
}
