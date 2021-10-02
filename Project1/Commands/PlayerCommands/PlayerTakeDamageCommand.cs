using Microsoft.Xna.Framework;
using Project1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Commands
{
    class PlayerTakeDamageCommand : ICommand
    {
        Game1 game;

        public PlayerTakeDamageCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.link.TakeDamage(2);
        }
    }
}
