using Microsoft.Xna.Framework;
using Project1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Commands
{
    class PlayerMoveRightCommand : ICommand
    {
        Player player;

        public PlayerMoveRightCommand(Player player)
        {
            this.player = player;
        }

        public void Execute()
        {
            foreach (Player player in GameObjectManager.Instance.GetObjectsOfType<Player>())
            {
                // Set the players right input as pressed
                player.SetMoveInput(Direction.Right, true);
            }
        }
    }
}
