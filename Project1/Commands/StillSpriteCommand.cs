using Project1.Interfaces;
using Project1.Sprites;

namespace Project1.Commands
{
    class StillSpriteCommand: ICommand
    {
        private readonly Game1 myGame;

        public StillSpriteCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            //myGame.SetSprite(new StillSprite(myGame.spriteSheet));
        }
    }
}
