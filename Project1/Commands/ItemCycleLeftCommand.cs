using Project1.Interfaces;
using Project1.Objects;
using System.Collections;
using Microsoft.Xna.Framework;

namespace Project1.Commands
{
    class ItemCycleLeftCommand: ICommand
    {
        private readonly Game1 myGame;

        public ItemCycleLeftCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.cyclableItem.CycleLeft();
        }
    }
}
