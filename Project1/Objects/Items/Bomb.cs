﻿using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Objects
{
    public class Bomb : IItem, ICollidable
    {
        public Vector2 Position { get; set; }

        ISprite sprite;
        public bool isMover => false;

        public Bomb(Vector2 position, int frames)
        {
            this.Position = position;
            sprite = SpriteFactory.Instance.CreateSprite("bomb");
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
            return new Rectangle((int)Position.X, (int)Position.Y, 16, 16);
        }
    }
}
