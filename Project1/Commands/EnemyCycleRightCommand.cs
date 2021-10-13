using Project1.Interfaces;
using System.Collections;
using Microsoft.Xna.Framework;

namespace Project1.Commands
{
    public class EnemyCycleRightCommand : ICommand
    {
        private readonly Game1 myGame;
        public EnemyCycleRightCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            // tight coupling, reference is now missing
            //myGame.cyclableEnemy.ResetPosition();
            //myGame.cyclableEnemy.CycleRight();
        }

    }
}