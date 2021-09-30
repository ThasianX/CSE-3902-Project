using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Enemy;

namespace Project1.NPC
{
    public class OldMan : IEnemy
    {
        public IEnemyState state;
        public Vector2 position;
        private Vector2 startPosition;
        public float movingSpeed;
        private int choice;
        private Random rand = new Random();
        private int timer;
        //private bool isLinkNearby;

        public OldMan(Vector2 position)
        {
            this.position = position;
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

        public void ResetPosition()
        {
            position = startPosition;
        }
    }
}
