using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Objects
{
    public class Fairy : IInstantUseItem, ICollidable
    {
        public Vector2 Position { get; set; }
        private Vector2 randomPos;
        private Vector2 direction;
        private Random rnd;
        private bool isReached;
        private float moveSpeed;

        public int heartHeal = 30;
        ISprite sprite;
        public bool IsMover => true;
        public string CollisionType => "InstantUseItem";
        public Fairy(Vector2 position)
        {
            this.Position = position;
            sprite = SpriteFactory.Instance.CreateSprite("fairy");
            rnd = new Random();
            moveSpeed = 0.5f;
            randomPos = new Vector2(rnd.Next(30,226), rnd.Next(30,146));
            isReached = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Position);
        }

        public void Update(GameTime gameTime)
        {
           
            RandomWalk();
            sprite.Update(gameTime);
        }

        private void RandomWalk()
        { 
            direction = randomPos - Position;
            direction.Normalize();
            this.Position += direction * moveSpeed;
            CheckReached();
        }

        private void CheckReached()
        {
            if (Vector2.Distance(Position, randomPos) <= 1f)
            {
                randomPos = new Vector2(rnd.Next(30, 226), rnd.Next(30, 146));
            }
        }

        public void InstantUseItem(IPlayer player)
        {
            player.Heal(heartHeal);
            SoundManager.Instance.PlaySound("GetHeart");
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 8, 15);
        }
    }
}