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
            LevelManager.Instance.MoveRoom(exit.nextRoom);
            Rectangle doorRect = LevelManager.Instance.GetCurrentRoom().GetCorrespondingExit(exit.direction).GetRectangle();
            int newX = exit.direction == Direction.Left ? doorRect.X - doorRect.Width / 2 : exit.direction == Direction.Right ? doorRect.X + doorRect.Width + 4 : doorRect.X;
            int newY = exit.direction == Direction.Up ? doorRect.Y - doorRect.Height / 2 : exit.direction == Direction.Down ? doorRect.Y + doorRect.Height + 4 : doorRect.Y;
            GameObjectManager.Instance.GetPlayer().Position = new Vector2(newX, newY);
        }
    }
}
