using Project1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Commands
{
    class PlayerFaceDownCommand : ICommand
    {
        Game1 game;

        public PlayerFaceDownCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            // COUPLING !!!!!!!!!!!!!!!!!!!!!!!!!
            Player player = game.link;
            player.FaceDirection(Direction.Down);
        }
    }
}
