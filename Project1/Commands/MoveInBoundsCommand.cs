using Microsoft.Xna.Framework;
using Project1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Commands
{
    class MoveInBoundsCommand : ICommand
    {
        Collision col;

        public MoveInBoundsCommand(Collision col)
        {

            this.col = col;
        }

        public void Execute()
        {
            IGameObject target = col.target as IGameObject;
            switch (col.side)
            {
                case Direction.Up:
                    target.Position += new Vector2(0, col.intersection.Height);
                    break;
                case Direction.Right:
                    target.Position += new Vector2(-col.intersection.Width, 0);
                    break;
                case Direction.Down:
                    target.Position += new Vector2(0, -col.intersection.Height);
                    break;
                case Direction.Left:
                    target.Position += new Vector2(col.intersection.Width, 0);
                    break;
                default:
                    break;
            }
        }
    }
}
