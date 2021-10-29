using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Objects
{
    public class WoodArrow : IItem, ICollidable
    {
        public int moveSpeed = 10;
        public Vector2 Position { get; set; }
        public bool IsMover => true;
        public string CollisionType => "Projectile";

        // time before the arrow deletes itself (seconds)
        private float activeTime = 5, counter = 0;
        private Direction direction;
        private Vector2 deltaVector;

        ISprite arrowSprite;

        public WoodArrow(Vector2 position, Direction direction)
        {
            this.direction = direction;
            this.Position = position;
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
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            arrowSprite.Draw(spriteBatch, this.Position);

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
            
            this.Position += this.deltaVector;

            if (counter >= activeTime)
            {
                GameObjectManager.Instance.RemoveOnNextFrame(this);
            }
            counter += (float) gameTime.ElapsedGameTime.TotalSeconds;
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 16, 16);
        }
    }
}
