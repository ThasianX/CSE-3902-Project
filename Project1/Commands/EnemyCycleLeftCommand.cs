﻿using Project1.Interfaces;
using System.Collections;
using Microsoft.Xna.Framework;

namespace Project1.Commands
{
    public class EnemyCycleLeftCommand : ICommand
    {
        private readonly Game1 myGame;
        public EnemyCycleLeftCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.cyclableEnemy.ResetPosition();
            myGame.cyclableEnemy.CycleLeft();
        }

    }
}