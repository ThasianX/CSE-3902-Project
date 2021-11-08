using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Objects
{
    public class WoodBoomerang : IGameObject, ICollidable
    {
        public int moveSpeed;
        private int frames;
        public Vector2 Position { get; set; }
        public bool IsMover => true;
        public string CollisionType => "Weapon";

        //Distance Boomerang travels from Link
        private int maxRange = 150;
        private bool inRange = true;
        private Direction direction;
        private Vector2 deltaVector;
        private Vector2 initialPosition;

        ISprite boomerangSprite;

        public WoodBoomerang(Vector2 position, Direction direction, int frames)
        {
            this.direction = direction; 
            this.Position = position; // position here is link/enemy position + boomerang offset.
            this.initialPosition = position;
            this.frames = frames;
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

            // Visualize rectangle for testing
            Rectangle rectangle = GetRectangle();
            int lineWidth = 1;
            spriteBatch.Draw(Game1.whiteRectangle, new Rectangle(rectangle.X, rectangle.Y, lineWidth, rectangle.Height + lineWidth), Color.Black);
            spriteBatch.Draw(Game1.whiteRectangle, new Rectangle(rectangle.X, rectangle.Y, rectangle.Width + lineWidth, lineWidth), Color.Black);
            spriteBatch.Draw(Game1.whiteRectangle, new Rectangle(rectangle.X + rectangle.Width, rectangle.Y, lineWidth, rectangle.Height + lineWidth), Color.Black);
            spriteBatch.Draw(Game1.whiteRectangle, new Rectangle(rectangle.X, rectangle.Y + rectangle.Height, rectangle.Width + lineWidth, lineWidth), Color.Black);
        }

        public void Update(GameTime gameTime)
        {
            //Checks if sprite has achieved max distance before returning to link
            checkRange();
            CheckPosition();
            if (this.inRange)
            {
                this.Position += this.deltaVector;
            }
            else
            {
                this.Position -= this.deltaVector;
            }
            if (frames % 5 == 0)
            {
                SoundManager.Instance.PlaySound("Boomerang");
            }
            frames++;
            boomerangSprite.Update(gameTime);
        }
        // Check Boomerang position, if it surpass player position + boomerang offset (initialPosition), delete it.
        public void CheckPosition()
        {
            switch (this.direction)
            {
                case Direction.Up:
                    if (this.Position.Y > initialPosition.Y)
                    {
                        GameObjectManager.Instance.RemoveOnNextFrame(this);
                    } 
                    break;
                case Direction.Down:
                    if (this.Position.Y < initialPosition.Y)
                    {
                        GameObjectManager.Instance.RemoveOnNextFrame(this);
                    }
                    break;
                case Direction.Left:
                    if (this.Position.X > initialPosition.X)
                    {
                        GameObjectManager.Instance.RemoveOnNextFrame(this);
                    }
                    break;
                case Direction.Right:
                    if (this.Position.X < initialPosition.X)
                    {
                        GameObjectManager.Instance.RemoveOnNextFrame(this);
                    }
                    break;
                default: break;
            }
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
