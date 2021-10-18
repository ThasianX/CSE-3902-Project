using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Objects
{
    public class Bomb: IItem
    {
        public Vector2 Position { get; set; }

        ISprite sprite;

        public Bomb(Vector2 position, int frames)
        {
            this.Position = position;
            sprite = SpriteFactory.Instance.CreateAnimatedSprite(new BombAnimation());
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Position);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }
    }
}
