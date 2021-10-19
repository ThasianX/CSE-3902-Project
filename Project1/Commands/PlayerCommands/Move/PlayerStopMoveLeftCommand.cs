﻿using Microsoft.Xna.Framework;
using Project1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Commands
{
    class PlayerStopMoveLeftCommand : ICommand
    {
        Player player;

        public PlayerStopMoveLeftCommand(Player player)
        {
            this.player = player;
        }

        public void Execute()
        {
            foreach (Player player in GameObjectManager.Instance.GetObjectsOfType<Player>())
            {
                // Set the players left input as released
                player.SetMoveInput(Direction.Left, false);
            }
        }
    }
}
