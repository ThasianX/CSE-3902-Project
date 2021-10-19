using Microsoft.Xna.Framework;
using Project1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Commands
{
    class PlayerMoveUpCommand : ICommand
    {
        Player player;

        public PlayerMoveUpCommand(Player player)
        {
            this.player = player;
        }

        public void Execute()
        {
            foreach (Player player in GameObjectManager.Instance.GetObjectsOfType<Player>())
            {
                // Set the players up input as pressed
                player.SetMoveInput(Direction.Up, true);
            }
        }
    }
}
