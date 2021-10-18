using Microsoft.Xna.Framework;
using Project1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Commands
{
    class PlayerMoveDownCommand : ICommand
    {
        Game1 game;

        public PlayerMoveDownCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            foreach (Player player in GameObjectManager.Instance.GetObjectsOfType<Player>())
            {
                // Set the players down input as pressed
                player.SetMoveInput(Direction.Down, true);
            }
        }
    }
}
