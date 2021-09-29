using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Objects
{
    public class WoodSword : IItem
    {
        public int ActiveFrames;
        public int moveSpeed;
        public Vector2 position;

        private int maxRange = 15;
        private Direction direction;
        private Vector2 deltaVector;

        //Need to find actual offset values
        private Vector2 upSpriteOffset = new Vector2(0, 0);
        private Vector2 rightSpriteOffset = new Vector2(0, 0);
        private Vector2 downSpriteOffset = new Vector2(0, 0);
        private Vector2 leftSpriteOffset = new Vector2(0, 0);

        ISprite swordSprite;

        public WoodSword(Vector2 position, Direction direction)
        {
            this.direction = direction;
            this.ActiveFrames = 4;
            switch (this.direction)
            {
                case Direction.Up:
                    swordSprite = SpriteFactory.Instance.CreateTileSprite(new WoodSwordUp());
                    this.position = position + upSpriteOffset;
                    this.deltaVector = new Vector2(0, moveSpeed);
                    break;

                case Direction.Right:
                    swordSprite = SpriteFactory.Instance.CreateTileSprite(new WoodSwordRight());
                    this.position = position + rightSpriteOffset;
                    this.deltaVector = new Vector2(moveSpeed, 0);
                    break;

                case Direction.Down:
                    swordSprite = SpriteFactory.Instance.CreateTileSprite(new WoodSwordDown());
                    this.position = position + downSpriteOffset;
                    this.deltaVector = new Vector2(0, -moveSpeed);
                    break;

                case Direction.Left:
                    swordSprite = SpriteFactory.Instance.CreateTileSprite(new WoodSwordLeft());
                    this.position = position + leftSpriteOffset;
                    this.deltaVector = new Vector2(-moveSpeed, 0);
                    break;

                default:
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            swordSprite.Draw(spriteBatch, this.position);
        }

        public void Update()
        {
            //Moves Sprite out and back in
            if (checkRange())
            {
                this.position += this.deltaVector;
            }
            else if (this.position.X != 0 && this.position.Y != 0)
            {
                this.position -= this.deltaVector;
            }
            else {
                //Not sure what to do after finished executing
            }
        }

        public bool checkRange()
        {
            bool inRange = true;
            switch (this.direction)
            {
                case Direction.Up:
                    inRange = (this.position.Y < this.maxRange);
                    break;
                case Direction.Right:
                    inRange = (this.position.X < this.maxRange);
                    break;
                case Direction.Down:
                    inRange = (this.position.Y < -this.maxRange);
                    break;
                case Direction.Left:
                    inRange = (this.position.X < -this.maxRange);
                    break;

                default:
                    break;
            }
            return inRange;
        }
    }
}
