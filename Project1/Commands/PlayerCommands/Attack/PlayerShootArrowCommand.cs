﻿using Microsoft.Xna.Framework;
using Project1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Commands
{
    class PlayerShootArrowCommand : ICommand
    {
        Player player;

        public PlayerShootArrowCommand(Player player)
        {
            this.player = player;
        }

        public void Execute()
        {
            foreach (Player player in GameObjectManager.Instance.GetObjectsOfType<Player>())
            {
                player.ShootArrow();
            }
        }
    }
}