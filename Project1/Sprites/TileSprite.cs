using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Sprites
{
    class TileSprite: ISprite
    {
        private readonly Rectangle source;
        private readonly Texture2D spriteSheet;

        public TileSprite(Texture2D spriteSheet, Rectangle source)
        {
            this.source = source;
            this.spriteSheet = spriteSheet;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle destination = new Rectangle((int)location.X, (int)location.Y, source.Width, source.Height);
            spriteBatch.Draw(spriteSheet, destination, source, Color.White);
        }

        // Nothing in here since this is a static sprite
        public void Update() { }
    }
}
