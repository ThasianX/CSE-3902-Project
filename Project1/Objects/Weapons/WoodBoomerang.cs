using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Objects
{
    public class WoodBoomerang : IProjectile, ICollidable
    {
        public int moveSpeed;
        private int frames;
        public Vector2 Position { get; set; }
        public IGameObject Owner { get; set; }
        public bool IsMover => true;
        public string CollisionType => "Boomerang";
        //Distance Boomerang travels from Link
        private int maxRange = 75;
        private bool flyBack = false;
        private Direction direction;
        private Vector2 deltaVector;
        private Vector2 initialPosition;
        ISprite boomerangSprite;
        private Vector2 directionToOwner;
        private float epsilon;

        public WoodBoomerang(Vector2 position, Direction direction, IGameObject owner)
        {
            this.direction = direction; 
            this.Position = position;
            this.Owner = owner;
            this.initialPosition = position;
            this.moveSpeed = 3;
            epsilon = 1.5f;
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
            if (!flyBack)
            {
                this.Position += this.deltaVector;
            }
            else
            {
                directionToOwner = Owner.Position - Position;
                directionToOwner.Normalize();
                this.Position += directionToOwner * moveSpeed;
                CheckDeletion();
            }
            if (frames % 5 == 0)
            {
                SoundManager.Instance.PlaySound("Boomerang");
            }
            frames++;
            boomerangSprite.Update(gameTime);
        }

        private void CheckDeletion()
        {
            if (Vector2.Distance(Owner.Position, Position) <= epsilon)
            {
                GameObjectManager.Instance.RemoveOnNextFrame(this);
            }
        }

        public void checkRange()
        {
            switch (this.direction)
            {
                case Direction.Up:
                    if (Position.Y <= initialPosition.Y - maxRange)
                    {
                       flyBack = true;
                    }
                    break;
                case Direction.Right:
                    if (Position.X >= initialPosition.X + maxRange)
                    {
                        flyBack = true;
                    }
                    break;
                case Direction.Down:
                    if(Position.Y >= initialPosition.Y + maxRange)
                    {
                        flyBack = true;
                    }
                    break;
                case Direction.Left:
                    if (Position.X <= initialPosition.X - maxRange)
                    {
                        flyBack = true;
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
