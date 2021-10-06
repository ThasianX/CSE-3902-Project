using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Enemy;

namespace Project1.NPC
{
    public class OldMan : IEnemy
    {
        public IEnemyState state;
        public Vector2 Position { get; set; }
        private Vector2 startPosition;
        public OldMan(Vector2 position)
        {
            this.Position = position;
            startPosition = position;
            state = new OldManStaticState(this);
        }

        public void Update()
        {
           // The old man do not update
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            state.Draw(spriteBatch);
        }

        // Only need this for Sprint 2
        public void ResetPosition()
        {
            Position = startPosition;
        }
    }
}
