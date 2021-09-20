using Project1.Interfaces;
using Project1.Sprites;

namespace Project1.Commands
{
    class MovingAnimatedSpriteCommand: ICommand
    {
        private readonly Game1 myGame;

        public MovingAnimatedSpriteCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            //myGame.SetSprite(new MovingAnimatedSprite(myGame.spriteSheet, myGame.ShiftPosition));
        }
    }
}
