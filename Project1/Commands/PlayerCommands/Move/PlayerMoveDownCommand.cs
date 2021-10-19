using Microsoft.Xna.Framework;
using Project1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Commands
{
    class PlayerMoveDownCommand : ICommand
    {
        Player player;

        public PlayerMoveDownCommand(Player player)
        {
            this.player = player;
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
