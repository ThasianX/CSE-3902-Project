using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Objects
{
    public class Fireball : IItem
    {
        public int moveSpeed;
        public Vector2 Position { get; set; }

        // Distance Fireball travels from Aquamentus
        private int maxRange = 250;
        private Vector2 deltaVector;
        private Vector2 fireBalOffset;

        private ISprite fireBallSprite;

        public Fireball(Vector2 position, Vector2 fireBalOffset, int frames)
        {
            this.Position = position;
            // The direction for Aquamentus will always be left, so the delta vector will be the same
            deltaVector = new Vector2(-1, 0);
            this.fireBalOffset = fireBalOffset;
            moveSpeed = (maxRange * 2) / frames;
            fireBallSprite = SpriteFactory.Instance.CreateAnimatedSprite(new FireballAnimation());
        }

        public void Update()
        {
            Position += deltaVector + fireBalOffset;
            fireBallSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            fireBallSprite.Draw(spriteBatch, Position);
        }
    }
}
