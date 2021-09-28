using Microsoft.Xna.Framework;
using Project1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Commands
{
    class PlayerMoveUpCommand : ICommand
    {
        Game1 game;

        public PlayerMoveUpCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            // COUPLING !!!!!!!!!!!!!!!!!!!!!!!!!
            game.link.SetMoveInput(Direction.Up, true);
        }
    }
}
