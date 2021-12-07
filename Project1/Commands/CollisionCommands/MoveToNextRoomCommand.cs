using Microsoft.Xna.Framework;
using Project1.Interfaces;
using Project1.Levels;

namespace Project1.Commands
{
    class MoveToNextRoomCommand : ICommand
    {
        IPlayer player;
        IExit exit;

        public MoveToNextRoomCommand(IPlayer player, IExit exit)
        {
            this.player = player;
            this.exit = exit;
        }

        private int GetNewX(Rectangle rect)
        {
            int newX;
            switch(exit.direction) {
                case Direction.Left: {
                    newX = rect.X - rect.Width / 2;
                    break;
                }
                case Direction.Right: {
                    newX = rect.X + rect.Width + 4;
                    break;
                }
                default: {
                    newX = (int)player.Position.X;
                    break;
                }
            }
            return newX;
        }

        private int GetNewY(Rectangle rect)
        {
            int newY;
            switch(exit.direction) {
                case Direction.Up: {
                    newY = rect.Y - rect.Height / 2;
                    break;
                }
                case Direction.Down: {
                    newY = rect.Y + rect.Height;
                    break;
                }
                default: {
                    newY = (int)player.Position.Y;
                    break;
                }
            }
            return newY;
        }

        public void Execute()
        {
            // Necessary coupling given current Maze implementation
            UIManager.Instance.UpdateMinimap(exit.direction);

            Game1.instance.isTransitioning = true;
            Game1.instance.nextRoomId = exit.nextRoom;

            Room nextRoom = LevelManager.Instance.ActivateNextRoom(exit.nextRoom);
            Rectangle doorRect = nextRoom.GetCorrespondingExit(exit.direction).GetRectangle();
            GameObjectManager.Instance.GetPlayer().Position = new Vector2(GetNewX(doorRect), GetNewY(doorRect));
            WindowManager.Instance.MoveCamera(exit.direction);
        }
    }
}
