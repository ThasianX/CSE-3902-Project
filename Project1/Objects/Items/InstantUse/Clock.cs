using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Enemy;
using Project1.Interfaces;
using Project1.Levels;

namespace Project1.Objects
{
    public class Clock : IInstantUseItem, ICollidable
    {
        public Vector2 Position { get; set; }
        ISprite sprite;
        public bool IsMover => false;
        public string CollisionType => "InstantUseItem";
        public Clock(Vector2 position)
        {
            this.Position = position;
            sprite = SpriteFactory.Instance.CreateSprite("clock");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Position);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public void InstantUseItem(IPlayer player)
        {
            foreach (IGameObject gameObject in LevelManager.Instance.GetCurrentRoom().GetObjects())
            {
                if (gameObject is IEnemy)
                {
                   IEnemy enemy = gameObject as IEnemy;
                   enemy.Freeze(Constants.freezeTime);
                }
            }
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 15, 9);
        }
    }
}