using Microsoft.Xna.Framework.Graphics;

namespace Project1.Enemy
{
    public interface IEnemyState
    {
        // Get the total frame of current animation, used in IEnemy class to change direction
        public int cycleLength {get;}
        // Will take the position of current IEnemy instance and the direction of current IEnemy to some class in Item
        void FireBallAttack();
        // Will take the position of current IEnemy instance and the direction of current IEnemy to some class in Item
        void BoomerangAttack();
        // Base on current direction, randomly change to a different direction
        void ChangeDirection();
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
