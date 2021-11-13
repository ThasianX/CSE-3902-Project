using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Objects
{
    public class WoodSword : IGameObject, ICollidable
    {
        public int moveSpeed;
        public Vector2 Position { get; set; }
        public bool IsMover => true;
        public string CollisionType => "Weapon";

        //Distance Sword travels from Link
        private int maxRange = 12;
        private Direction direction;
        private Vector2 deltaVector;
        private double activeTime;
        private double timeCounter = 0;

        ISprite swordSprite;

        public WoodSword(Vector2 position, Direction direction, double activeTime)
        {
            this.activeTime = activeTime;
            this.direction = direction;
            this.Position = position;
            this.moveSpeed = 2;
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
            SoundManager.Instance.PlaySound("SwordSlash");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            swordSprite.Draw(spriteBatch, this.Position);
        }

        public void Update(GameTime gameTime)
        {
            if (Position.Length() <= maxRange)
                Position += this.deltaVector;
            if (timeCounter > activeTime)
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
