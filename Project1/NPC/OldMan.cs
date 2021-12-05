using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Enemy;
using Project1.Interfaces;

namespace Project1.NPC
{
    public class OldMan : IGameObject, ICollidable
    {
        public ISprite Sprite { get; set; }
        public Vector2 Position { get; set; }
        public bool IsMover => false;
        public string CollisionType => "Block";
        public OldMan(Vector2 position)
        {
            this.Position = position;
            this.Sprite = SpriteFactory.Instance.CreateSprite("OldMan_standing");
        }

        public void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, Position);
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 16, 16);
        }
    }
}
