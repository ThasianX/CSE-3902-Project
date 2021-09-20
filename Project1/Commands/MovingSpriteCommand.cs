using Project1.Interfaces;
using Project1.Sprites;

namespace Project1.Commands
{
    class MovingSpriteCommand: ICommand
    {
        private readonly Game1 myGame;

        public MovingSpriteCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            //myGame.SetSprite(new MovingSprite(myGame.spriteSheet, myGame.ShiftPosition));
        }
    }
}
