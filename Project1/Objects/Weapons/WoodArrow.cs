using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Objects
{
    public class WoodArrow : IProjectile, ICollidable
    {
        public int moveSpeed = 10;
        public Vector2 Position { get; set; }
        public bool IsMover => true;
        public string CollisionType => "Projectile";
        public IGameObject Owner { get; set; }

        // time before the arrow deletes itself (seconds)
        private float activeTime = 5, counter = 0;
        private Direction direction;
        private Vector2 deltaVector;

        ISprite arrowSprite;

        public WoodArrow(Vector2 position, Direction direction, IGameObject owner)
        {
            this.direction = direction;
            this.Position = position;
            this.Owner = owner;
            //this.moveSpeed = maxRange / frames;
            switch (this.direction)
            {
                case Direction.Up:
                    arrowSprite = SpriteFactory.Instance.CreateSprite("woodArrow_up");
                    this.deltaVector = new Vector2(0, -moveSpeed);
                    break;

                case Direction.Right:
                    arrowSprite = SpriteFactory.Instance.CreateSprite("woodArrow_right");
                    this.deltaVector = new Vector2(moveSpeed, 0);
                    break;

                case Direction.Down:
                    arrowSprite = SpriteFactory.Instance.CreateSprite("woodArrow_down");
                    this.deltaVector = new Vector2(0, moveSpeed);
                    break;

                case Direction.Left:
                    arrowSprite = SpriteFactory.Instance.CreateSprite("woodArrow_left");
                    this.deltaVector = new Vector2(-moveSpeed, 0);
                    break;

                default:
                    break;
            }
            SoundManager.Instance.PlaySound("Arrow");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            arrowSprite.Draw(spriteBatch, this.Position);
        }

        public void Update(GameTime gameTime)
        {
            this.Position += this.deltaVector;

            if (counter >= activeTime)
            {
                GameObjectManager.Instance.RemoveOnNextFrame(this);
            }
            counter += (float) gameTime.ElapsedGameTime.TotalSeconds;
        }

        public Rectangle GetRectangle()
        {
            switch (this.direction)
            {
                case Direction.Up:
                    return new Rectangle((int)Position.X + 4, (int)Position.Y, 5, 16);

                case Direction.Right:
                    return new Rectangle((int)Position.X, (int)Position.Y + 4, 16, 5);

                case Direction.Down:
                    return new Rectangle((int)Position.X + 5, (int)Position.Y, 5, 16);

                case Direction.Left:
                    return new Rectangle((int)Position.X, (int)Position.Y + 5, 16, 5);

                default:
                    return new Rectangle((int)Position.X, (int)Position.Y, 16, 16);
            }
        }
    }
}
