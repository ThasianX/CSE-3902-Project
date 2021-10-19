using Microsoft.Xna.Framework;
using Project1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Commands
{
    class PlayerStopMoveUpCommand : ICommand
    {
        Player player;

        public PlayerStopMoveUpCommand(Player player)
        {
            this.player = player;
        }

        public void Execute()
        {
            foreach (Player player in GameObjectManager.Instance.GetObjectsOfType<Player>())
            {
                // Set the players up input as released
                player.SetMoveInput(Direction.Up, false);
            }
        }
    }
}
