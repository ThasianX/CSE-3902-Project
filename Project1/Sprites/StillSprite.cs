using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Sprites
{
    class StillSprite: ISprite
    {
        private readonly Rectangle source = new Rectangle(206, 118, SpriteDimensions.WIDTH, SpriteDimensions.HEIGHT);
        private readonly Texture2D spriteSheet;

        public StillSprite(Texture2D spriteSheet)
        {
            this.spriteSheet = spriteSheet;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle destination = new Rectangle((int)location.X, (int)location.Y, SpriteDimensions.WIDTH, SpriteDimensions.HEIGHT);
            spriteBatch.Draw(spriteSheet, destination, source, Color.White);
        }

        // Nothing in here since this is a static sprite
        public void Update() { }
    }
}
