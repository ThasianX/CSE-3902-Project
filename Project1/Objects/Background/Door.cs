using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Objects
{
    public class Door: IExit, ICollidable
    {
        public Vector2 Position { get; set; }
        public int nextRoom { get; }

        ISprite sprite;
        public bool IsMover => true;
        public string CollisionType => "Door";

        public Door(Vector2 position, Direction direction, int nextRoom)
        {
            this.Position = position;
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
            return new Rectangle((int)Position.X, (int)Position.Y, dimensions.width, dimensions.height);
        }
    }
}
