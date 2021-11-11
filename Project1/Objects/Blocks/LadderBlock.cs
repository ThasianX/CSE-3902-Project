using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Objects
{
    public class LadderBlock : IBlock
    {
        public Vector2 Position { get; set; }

        ISprite sprite;
        public bool IsMover => false;
        

        public LadderBlock(Vector2 position)
        {
            this.Position = position;
            sprite = SpriteFactory.Instance.CreateSprite("ladder_block");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Position);

            // Visualize rectangle for testing
            Rectangle rectangle = GetRectangle();
            int lineWidth = 1;
            spriteBatch.Draw(Game1.whiteRectangle, new Rectangle(rectangle.X, rectangle.Y, lineWidth, rectangle.Height + lineWidth), Color.Blue);
            spriteBatch.Draw(Game1.whiteRectangle, new Rectangle(rectangle.X, rectangle.Y, rectangle.Width + lineWidth, lineWidth), Color.Blue);
            spriteBatch.Draw(Game1.whiteRectangle, new Rectangle(rectangle.X + rectangle.Width, rectangle.Y, lineWidth, rectangle.Height + lineWidth), Color.Blue);
            spriteBatch.Draw(Game1.whiteRectangle, new Rectangle(rectangle.X, rectangle.Y + rectangle.Height, rectangle.Width + lineWidth, lineWidth), Color.Blue);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 16, 16);
        }
    }
}
