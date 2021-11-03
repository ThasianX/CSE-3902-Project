using System;
using Microsoft.Xna.Framework;
using Project1.Enemy;
using Project1.Interfaces;

namespace Project1.Commands
{
    class PlayerKnockedBackCommand : ICommand
    {
        private IPlayer player;
        private Direction damagedSide;
        private Vector2 KnockBackAmount;

        public PlayerKnockedBackCommand(Collision col)
        {
            // TODO: player here is Player but later is DamagedPlayer
            this.player = col.target as IPlayer;
            damagedSide = col.side;
            switch (damagedSide)
            {
                case Direction.Up: KnockBackAmount = new Vector2(0, 10); break;
                case Direction.Down: KnockBackAmount = new Vector2(0, -10); break;
                case Direction.Left: KnockBackAmount = new Vector2(10, 0); break;
                case Direction.Right: KnockBackAmount = new Vector2(-10, 0); break;
            }
        }

        public void Execute()
        {
            player.Position += KnockBackAmount;
            player.FacingDirection = damagedSide;
        }
    }
}