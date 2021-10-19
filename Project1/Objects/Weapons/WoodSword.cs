using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Objects
{
    public class WoodSword : IItem, ICollidable
    {
        public int moveSpeed;
        public Vector2 Position { get; set; }
        public bool isMover => true;


        //Distance Sword travels from Link
        private int maxRange = 12;
        private Direction direction;
        private Vector2 deltaVector;

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
        }

        public void Update(GameTime gameTime)
        {
            this.Position += this.deltaVector;
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 16, 16);
        }
    }
}
