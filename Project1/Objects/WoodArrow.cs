using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Objects
{
    public class WoodArrow : IItem
    {
        public int moveSpeed;
        public Vector2 Position { get; set; }

        //Distance Arrow travels from Link
        private int maxRange = 250;
        private Direction direction;
        private Vector2 deltaVector;

        ISprite arrowSprite;

        public WoodArrow(Vector2 position, Direction direction, int frames)
        {
            this.direction = direction;
            this.Position = position;
            this.moveSpeed = maxRange / frames;
            switch (this.direction)
            {
                case Direction.Up:
                    arrowSprite = SpriteFactory.Instance.CreateTileSprite(new WoodArrowUp());
                    this.deltaVector = new Vector2(0, -moveSpeed);
                    break;

                case Direction.Right:
                    arrowSprite = SpriteFactory.Instance.CreateTileSprite(new WoodArrowRight());
                    this.deltaVector = new Vector2(moveSpeed, 0);
                    break;

                case Direction.Down:
                    arrowSprite = SpriteFactory.Instance.CreateTileSprite(new WoodArrowDown());
                    this.deltaVector = new Vector2(0, moveSpeed);
                    break;

                case Direction.Left:
                    arrowSprite = SpriteFactory.Instance.CreateTileSprite(new WoodArrowLeft());
                    this.deltaVector = new Vector2(-moveSpeed, 0);
                    break;

                default:
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            arrowSprite.Draw(spriteBatch, this.Position);
        }

        public void Update()
        {
            this.Position += this.deltaVector;
        }
    }
}
