using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Objects
{
    public class Bullet : IProjectile, ICollidable
    {

        public int moveSpeed = 20;

        public Vector2 Position { get; set; }
        public bool IsMover => true;
        public string CollisionType => "Projectile";
        public IGameObject Owner { get; set; }

        // time before the arrow deletes itself (seconds)
        private float activeTime = 5, counter = 0;
        private Direction direction;
        private Vector2 deltaVector;

        ISprite bulletSprite;

        public Bullet(Vector2 position, Direction direction, IGameObject owner)
        {
            this.direction = direction;
            this.Position = position;
            this.Owner = owner;
            //this.moveSpeed = maxRange / frames;
            switch (this.direction)
            {
                case Direction.Up:
                    bulletSprite = SpriteFactory.Instance.CreateSprite("bullet_up");
                    this.deltaVector = new Vector2(0, -moveSpeed);
                    break;

                case Direction.Right:
                    bulletSprite = SpriteFactory.Instance.CreateSprite("bullet_right");
                    this.deltaVector = new Vector2(moveSpeed, 0);
                    break;

                case Direction.Down:
                    bulletSprite = SpriteFactory.Instance.CreateSprite("bullet_down");
                    this.deltaVector = new Vector2(0, moveSpeed);
                    break;

                case Direction.Left:
                    bulletSprite = SpriteFactory.Instance.CreateSprite("bullet_left");
                    this.deltaVector = new Vector2(-moveSpeed, 0);
                    break;

                default:
                    break;
            }
            SoundManager.Instance.PlaySound("bullet");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            bulletSprite.Draw(spriteBatch, this.Position);
        }

        public void Update(GameTime gameTime)
        {
            this.Position += this.deltaVector;

            if (counter >= activeTime)
            {
                GameObjectManager.Instance.RemoveOnNextFrame(this);
            }
            counter += (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public Rectangle GetRectangle()
        {
            switch (this.direction)
            {
                case Direction.Up:
                    return new Rectangle((int)Position.X + 4, (int)Position.Y, 5, 16);

                case Direction.Right:
                    return new Rectangle((int)Position.X - 4, (int)Position.Y, 16, 5);

                case Direction.Down:
                    return new Rectangle((int)Position.X + 5, (int)Position.Y + 10, 5, 16);

                case Direction.Left:
                    return new Rectangle((int)Position.X + 4, (int)Position.Y, 16, 5);

                default:
                    return new Rectangle((int)Position.X, (int)Position.Y, 16, 16);
            }
        }
    }
}