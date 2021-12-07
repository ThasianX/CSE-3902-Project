using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Objects
{
    public class Door: IExit, ICollidable
    {
        public Vector2 Position { get; set; }
        public int nextRoom { get; }
        public Direction direction { get; }

        ISprite sprite;
        public bool IsMover => true;
        public string CollisionType => "Door";
        public Vector2 Dimensions = new Vector2(32, 32);

        public Door(Vector2 position, Direction direction, int nextRoom)
        {
            this.Position = position;
            this.direction = direction;
            this.nextRoom = nextRoom;
            switch(direction) {
                case Direction.Up:
                    sprite = SpriteFactory.Instance.CreateSprite("openDoor_up");
                    break;
                case Direction.Left:
                    sprite = SpriteFactory.Instance.CreateSprite("openDoor_left");
                    break;
                case Direction.Right:
                    sprite = SpriteFactory.Instance.CreateSprite("openDoor_right");
                    break;
                case Direction.Down:
                    sprite = SpriteFactory.Instance.CreateSprite("openDoor_down");
                    break;
                default:
                    throw new System.Exception("Invalid direction");
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Position);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public Rectangle GetRectangle()
        {
            Dimensions dimensions = sprite.GetDimensions();
            Rectangle rect;
            //Direction
            switch (this.direction)
            {
                case Direction.Up:
                    rect = new Rectangle((int)Position.X + 11, (int)Position.Y + 22, 10, 10);
                    break;
                case Direction.Left:
                    rect = new Rectangle((int)Position.X + 22, (int)Position.Y + 11, 10, 10);
                    break;
                case Direction.Right:
                    rect = new Rectangle((int)Position.X, (int)Position.Y + 11, 10, 10);
                    break;
                case Direction.Down:
                    rect = new Rectangle((int)Position.X + 11, (int)Position.Y, 10, 10);
                    break;
                default: 
                    rect = new Rectangle((int)Position.X, (int)Position.Y, dimensions.width, dimensions.height);
                    break;
            }
            return rect;
        }
    }
}
