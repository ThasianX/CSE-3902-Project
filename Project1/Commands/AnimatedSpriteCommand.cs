using Project1.Interfaces;
using Project1.Sprites;

namespace Project1.Commands
{
    class AnimatedSpriteCommand: ICommand
    {
        private readonly Game1 myGame;

        public AnimatedSpriteCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.SetSprite(new AnimatedSprite(myGame.spriteSheet));
        }
    }
}
