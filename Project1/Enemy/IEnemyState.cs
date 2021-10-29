using Microsoft.Xna.Framework;

namespace Project1.Enemy
{
    public interface IEnemyState
    {
        // Will take the position of current IEnemy instance and the direction of current IEnemy to some class in Item
        void FireBallAttack();
        // Will take the position of current IEnemy instance and the direction of current IEnemy to some Enemy Attack State (RedGloriyaAttackState)
        void BoomerangAttack();
        // Base on current direction, randomly change to a different direction
        void ChangeDirection();

        void Update(GameTime gameTime);
    }
}
