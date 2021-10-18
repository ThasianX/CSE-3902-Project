using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Enemy;

namespace Project1.Objects
{
    public class CyclableEnemy : IEnemy
    {
        public Vector2 Position { get; set; }

        private List<IEnemy> enemyList;
        private IEnemy enemySprite;
        private int totalCount;
        private int currentCount;

        public CyclableEnemy(List<IEnemy> enemyList)
        {
            this.enemyList = enemyList;
            totalCount = enemyList.Count;
            currentCount = 0;
            enemySprite = enemyList[currentCount];
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            enemySprite.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            enemySprite.Update(gameTime);
        }

        public void CycleLeft()
        {
            if (currentCount == 0)
            {
                currentCount = totalCount - 1;
            }
            else
            {
                currentCount--;
            }
            enemySprite = enemyList[currentCount];
        }

        public void CycleRight()
        {
            if (currentCount == totalCount - 1)
            {
                currentCount = 0;
            }
            else
            {
                currentCount++;
            }
            enemySprite = enemyList[currentCount];
        }

        public void ResetPosition()
        {
            enemySprite.ResetPosition();
        }
    }
}
