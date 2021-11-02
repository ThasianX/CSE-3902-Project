using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Objects
{
    public class Hole : IGameObject, ICollidable
    {
        public Vector2 Position { get; set; }

        ISprite sprite;
        public bool IsMover => false;
        public string CollisionType => "Block";

        public Hole(Vector2 position, Direction direction)
        {
            this.Position = position;
            switch (direction)
            {
                case Direction.Up:
                    sprite = SpriteFactory.Instance.CreateSprite("hole_up");
                    break;
                case Direction.Left:
                    sprite = SpriteFactory.Instance.CreateSprite("hole_left");
                    break;
                case Direction.Right:
                    sprite = SpriteFactory.Instance.CreateSprite("hole_right");
                    break;
                case Direction.Down:
                    sprite = SpriteFactory.Instance.CreateSprite("hole_down");
                    break;
                default:
                    throw new System.Exception("Invalid direction");
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Position);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public Rectangle GetRectangle()
        {
            Dimensions dimensions = sprite.GetDimensions();
            return new Rectangle((int)Position.X, (int)Position.Y, dimensions.width, dimensions.height);
        }
    }
}
