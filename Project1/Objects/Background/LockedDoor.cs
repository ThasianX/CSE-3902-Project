﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Objects
{
    public class LockedDoor : IExit, ICollidable
    {
        public Vector2 Position { get; set; }
        public int nextRoom { get; }
        public Direction direction { get; }

        ISprite sprite;
        public bool IsMover => true;
        public string CollisionType => "LockedDoor";

        public LockedDoor(Vector2 position, Direction direction, int nextRoom)
        {
            this.Position = position;
            this.direction = direction;
            this.nextRoom = nextRoom;

            switch (direction)
            {
                case Direction.Up:
                    sprite = SpriteFactory.Instance.CreateSprite("lockedDoor_up");
                    break;
                case Direction.Left:
                    sprite = SpriteFactory.Instance.CreateSprite("lockedDoor_left");
                    break;
                case Direction.Right:
                    sprite = SpriteFactory.Instance.CreateSprite("lockedDoor_right");
                    break;
                case Direction.Down:
                    sprite = SpriteFactory.Instance.CreateSprite("lockedDoor_down");
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

