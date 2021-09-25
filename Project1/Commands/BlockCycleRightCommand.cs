using Project1.Interfaces;
using Project1.Objects;
using System.Collections;
using Microsoft.Xna.Framework;

namespace Project1.Commands
{
    class BlockCycleRightCommand: ICommand
    {
        private readonly Game1 myGame;

        public BlockCycleRightCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.cyclableBlock.CycleRight();
        }
    }
}
