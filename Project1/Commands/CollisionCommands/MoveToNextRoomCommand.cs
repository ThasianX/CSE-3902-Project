using Microsoft.Xna.Framework;
using Project1.Interfaces;
using Project1.Levels;

namespace Project1.Commands
{
    class MoveToNextRoomCommand : ICommand
    {
        IPlayer player;
        IExit exit;
        int off = 3;

        public MoveToNextRoomCommand(IPlayer player, IExit exit)
        {
            this.player = player;
            this.exit = exit;
        }

        private int GetNewX(IExit door, Rectangle rect)
        {
            int newX;
            switch(exit.direction) {
                case Direction.Up:
                {
                    newX = rect.X - off;
                    break;
                }
                case Direction.Left: {
                    newX = rect.X - rect.Width;
                    break;
                }
                case Direction.Right: {
                    newX = rect.X + rect.Width;
                    break;
                }
                
                case Direction.Down:
                {
                    newX = rect.X - off;
                    break;
                }
                default: {
                    newX = rect.X;
                    break;
                }
            }
            return newX;
        }

        private int GetNewY(IExit door, Rectangle rect)
        {
            int newY;
            switch(exit.direction) {
                case Direction.Up: {
                    newY = rect.Y - Constants.TILE_SIZE;
                    break;
                }
                case Direction.Left:
                {
                    newY = rect.Y - off;
                    break;
                }
                case Direction.Right:
                {
                    newY = rect.Y - off;
                    break;
                }
                case Direction.Down: {
                    newY = rect.Y + rect.Height;
                    break;
                }
                default: {
                    newY = rect.Y;
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
            IExit door = nextRoom.GetCorrespondingExit(exit.direction);
            Rectangle nextRect = nextRoom.GetCorrespondingExit(exit.direction).GetRectangle();
            GameObjectManager.Instance.GetPlayer().Position = new Vector2(GetNewX(door, nextRect), GetNewY(door, nextRect));
            WindowManager.Instance.MoveCamera(exit.direction);
        }
    }
}
