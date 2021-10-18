using Project1.Interfaces;
using Project1.Objects;
using System.Collections;
using Microsoft.Xna.Framework;

namespace Project1.Commands
{
    class BlockCycleLeftCommand: ICommand
    {
        private readonly Game1 myGame;

        public BlockCycleLeftCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            // tight coupling, reference is now missing
            //myGame.cyclableBlock.CycleLeft();
        }
    }
}
