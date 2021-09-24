using Project1.Interfaces;
using Project1.Sprites;
using System.Collections;
using Microsoft.Xna.Framework;

namespace Project1.Commands
{
    //This command will never get used. Used for testing purposes only
    class AnimatedSpriteCommand: ICommand
    {
        private readonly Game1 myGame;

        public AnimatedSpriteCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            ArrayList sources = new ArrayList()
            {
                new Rectangle(176, 118, SpriteDimensions.WIDTH, SpriteDimensions.HEIGHT),
                new Rectangle(206, 118, SpriteDimensions.WIDTH, SpriteDimensions.HEIGHT),
                new Rectangle(236, 118, SpriteDimensions.WIDTH, SpriteDimensions.HEIGHT)
            };

            //myGame.SetSprite(new AnimatedSprite(myGame.spriteSheet, sources, 60));
        }
    }
}
