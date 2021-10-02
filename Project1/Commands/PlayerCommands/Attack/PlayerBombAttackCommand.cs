using Microsoft.Xna.Framework;
using Project1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Commands
{
    class PlayerBombAttackCommand : ICommand
    {
        Game1 game;

        public PlayerBombAttackCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.link.BombAttack();
        }
    }
}
