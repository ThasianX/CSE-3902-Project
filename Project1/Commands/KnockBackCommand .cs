using System;
using Microsoft.Xna.Framework;
using Project1.Enemy;
using Project1.Interfaces;

namespace Project1.Commands
{
    class KnockBackCommand : ICommand
    {
        private IGameObject target;
        private Direction damagedSide;
        private Vector2 KnockBackAmount;

        public KnockBackCommand(Collision col)
        {
            this.target = col.target as IGameObject;
            damagedSide = col.side;
            switch (damagedSide)
            {
                case Direction.Up: KnockBackAmount = new Vector2(0, -8); break;
                case Direction.Down: KnockBackAmount = new Vector2(0, 8); break;
                case Direction.Left: KnockBackAmount = new Vector2(-8, 0); break;
                case Direction.Right: KnockBackAmount = new Vector2(8, 0); break;
            }
        }

        public void Execute()
        {
            target.Position += KnockBackAmount;
        }
    }
}