﻿using Project1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Commands
{
    class PlayerFaceLeftCommand : ICommand
    {
        Player player;

        public PlayerFaceLeftCommand(Player player)
        {
            this.player = player;
        }

        public void Execute()
        {
            foreach (Player player in GameObjectManager.Instance.GetObjectsOfType<Player>())
            {
                player.FaceDirection(Direction.Left);
            }
        }
    }
}
