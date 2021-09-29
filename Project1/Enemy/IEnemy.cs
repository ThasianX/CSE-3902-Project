using Microsoft.Xna.Framework.Graphics;

namespace Project1.Enemy
{
    public interface IEnemy
    {
        void FireBallAttack();
        void BoomerangAttack();
        void ChangeDirection();
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
