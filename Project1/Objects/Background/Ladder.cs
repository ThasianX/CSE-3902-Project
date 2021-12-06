using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Objects
{
    public class Ladder: IPortal, ICollidable
    {
        public Vector2 NewRoomPosition { get; set; }
        public Vector2 Position { get; set; }
        public int NextRoom { get; }
        public Direction Direction { get; }

        ISprite sprite;
        public bool IsMover => true;
        public string CollisionType => "Portal";

        public Ladder(Vector2 position, Direction direction, int nextRoom)
        {
            this.NewRoomPosition = new Vector2(112, 80);
            this.Position = position;
            this.Direction = direction;
            this.NextRoom = nextRoom;
            sprite = SpriteFactory.Instance.CreateSprite("ladder_block");
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
