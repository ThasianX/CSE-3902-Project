using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Objects
{
    public class WoodBoomerang : IProjectile, ICollidable
    {
        public int moveSpeed;
        public Vector2 Position { get; set; }
        public IGameObject Owner { get; set; }
        public bool IsMover => true;
        public string CollisionType => "Projectile";
        //Distance Boomerang travels from Link
        private int maxRange = 75;
        private bool inRange = true;
        private Direction direction;
        private Vector2 deltaVector;
        private Vector2 initialPosition;
        ISprite boomerangSprite;

        public WoodBoomerang(Vector2 position, Direction direction, int frames, IGameObject owner)
        {
            this.direction = direction; 
            this.Position = position; // position here is link/enemy position + boomerang offset.
            this.Owner = owner;
            this.initialPosition = position;
            this.moveSpeed = (maxRange * 2) / frames;
            boomerangSprite = SpriteFactory.Instance.CreateSprite("woodBoomerang");

            switch (this.direction)
            {
                case Direction.Up:
                    this.deltaVector = new Vector2(0, -moveSpeed);
                    break;

                case Direction.Right:
                    this.deltaVector = new Vector2(moveSpeed, 0);
                    break;

                case Direction.Down:
                    this.deltaVector = new Vector2(0, moveSpeed);
                    break;

                case Direction.Left:
                    this.deltaVector = new Vector2(-moveSpeed, 0);
                    break;

                default:
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            boomerangSprite.Draw(spriteBatch, this.Position);
        }

        public void Update(GameTime gameTime)
        {
            //Checks if sprite has achieved max distance before returning to link
            checkRange();
            if (this.inRange)
            {
                this.Position += this.deltaVector;
            }
            else
            {
                this.Position -= this.deltaVector;
            }
            boomerangSprite.Update(gameTime);
        }

        public void checkRange()
        {
            switch (this.direction)
            {
                case Direction.Up:
                    if (this.Position.Y <= this.initialPosition.Y - maxRange)
                    {
                        this.inRange = false;
                    }
                    break;
                case Direction.Right:
                    if (this.Position.X >= this.initialPosition.X + this.maxRange)
                    {
                        this.inRange = false;
                    }
                    break;
                case Direction.Down:
                    if(this.Position.Y >= this.initialPosition.Y + this.maxRange)
                    {
                        this.inRange = false;
                    }
                    break;
                case Direction.Left:
                    if (this.Position.X <= this.initialPosition.X - this.maxRange)
                    {
                        this.inRange = false;
                    }
                    break;
                default:
                    break;
            }
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 16, 16);
        }
    }
}
