﻿using Microsoft.Xna.Framework;
using Project1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Commands
{
    class PlayerAttackCommand : ICommand
    {
        Game1 game;

        public PlayerAttackCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            // COUPLING !!!!!!!!!!!!!!!!!!!!!!!!!
            game.link.SwordAttack();
        }
    }
}
