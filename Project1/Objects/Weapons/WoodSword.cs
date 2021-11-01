using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Objects
{
    public class WoodSword : IItem, ICollidable
    {
        public int moveSpeed;
        public Vector2 Position { get; set; }
        public bool IsMover => true;
        public string CollisionType => "Weapon";

        //Distance Sword travels from Link
        private int maxRange = 12;
        private Direction direction;
        private Vector2 deltaVector;
        private double timeCounter = 0;

        ISprite swordSprite;

        public WoodSword(Vector2 position, Direction direction, int frames)
        {
            this.direction = direction;
            this.Position = position;
            this.moveSpeed = maxRange / frames;
            switch (this.direction)
            {
                case Direction.Up:
                    swordSprite = SpriteFactory.Instance.CreateSprite("woodSword_up");
                    this.deltaVector = new Vector2(0, -moveSpeed);
                    break;

                case Direction.Right:
                    swordSprite = SpriteFactory.Instance.CreateSprite("woodSword_right");
                    this.deltaVector = new Vector2(moveSpeed, 0);
                    break;

                case Direction.Down:
                    swordSprite = SpriteFactory.Instance.CreateSprite("woodSword_down");
                    this.deltaVector = new Vector2(0, moveSpeed);
                    break;

                case Direction.Left:
                    swordSprite = SpriteFactory.Instance.CreateSprite("woodSword_left");
                    this.deltaVector = new Vector2(-moveSpeed, 0);
                    break;

                default:
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            swordSprite.Draw(spriteBatch, this.Position);

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
            if (timeCounter > .75)
            {
                GameObjectManager.Instance.RemoveOnNextFrame(this);
            }
            timeCounter += gameTime.ElapsedGameTime.TotalSeconds;
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 16, 16);
        }
    }
}
