using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Objects
{
    public class WoodBoomerang : IItem
    {
        public int moveSpeed;
        public Vector2 position;

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
            this.position = position;
            this.initialPosition = position;
            this.moveSpeed = (maxRange * 2) / frames;
            switch (this.direction)
            {
                case Direction.Up:
                    boomerangSprite = SpriteFactory.Instance.CreateAnimatedSprite(new WoodBoomerangAnimation());
                    this.deltaVector = new Vector2(0, -moveSpeed);
                    break;

                case Direction.Right:
                    boomerangSprite = SpriteFactory.Instance.CreateAnimatedSprite(new WoodBoomerangAnimation());
                    this.deltaVector = new Vector2(moveSpeed, 0);
                    break;

                case Direction.Down:
                    boomerangSprite = SpriteFactory.Instance.CreateAnimatedSprite(new WoodBoomerangAnimation());
                    this.deltaVector = new Vector2(0, moveSpeed);
                    break;

                case Direction.Left:
                    boomerangSprite = SpriteFactory.Instance.CreateAnimatedSprite(new WoodBoomerangAnimation());
                    this.deltaVector = new Vector2(-moveSpeed, 0);
                    break;

                default:
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            boomerangSprite.Draw(spriteBatch, this.position);
        }

        public void Update()
        {
            //Checks if sprite has achieved max distance before returning to link
            checkRange();
            if (this.inRange)
            {
                this.position += this.deltaVector;
            }
            else
            {
                this.position -= this.deltaVector;
            }
            boomerangSprite.Update();
        }

        public void checkRange()
        {
            switch (this.direction)
            {
                case Direction.Up:
                    if (this.position.Y <= this.initialPosition.Y - maxRange)
                    {
                        this.inRange = false;
                    }
                    break;
                case Direction.Right:
                    if (this.position.X >= this.initialPosition.X + this.maxRange)
                    {
                        this.inRange = false;
                    }
                    break;
                case Direction.Down:
                    if(this.position.Y >= this.initialPosition.Y + this.maxRange)
                    {
                        this.inRange = false;
                    }
                    break;
                case Direction.Left:
                    if (this.position.X <= this.initialPosition.X - this.maxRange)
                    {
                        this.inRange = false;
                    }
                    break;

                default:
                    break;
            }
        }
    }
}
