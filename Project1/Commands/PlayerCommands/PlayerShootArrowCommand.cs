using Microsoft.Xna.Framework;
using Project1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Commands
{
    class PlayerShootArrowCommand : ICommand
    {
        Game1 game;

        public PlayerShootArrowCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.link.ShootArrow();
        }
    }
}
