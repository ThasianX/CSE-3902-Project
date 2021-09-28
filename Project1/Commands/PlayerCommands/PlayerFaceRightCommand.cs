using Project1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Commands
{
    class PlayerFaceRightCommand : ICommand
    {
        Game1 game;

        public PlayerFaceRightCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            // COUPLING !!!!!!!!!!!!!!!!!!!!!!!!!
            Player player = game.link;
            player.FaceDirection(Direction.Right);
        }
    }
}
