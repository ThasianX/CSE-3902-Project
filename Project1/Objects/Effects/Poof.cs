using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Objects.Effects
{
    class Poof : IGameObject
    {
        public Vector2 Position { get; set; }

        private ISprite sprite = SpriteFactory.Instance.CreateSprite("explosion");

        private double activeTime = 0.25;
        private double counter = 0f;

        public Poof(Vector2 position)
        {
            Position = position;
        }

        public void Remove()
        {
            GameObjectManager.Instance.RemoveOnNextFrame(this);
        }

        public void Update(GameTime time)
        {
            if (counter >= activeTime)
            {
                Remove();
            }
            sprite.Update(time);
            counter += time.ElapsedGameTime.TotalSeconds;
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, Position);
        }

    }
}
