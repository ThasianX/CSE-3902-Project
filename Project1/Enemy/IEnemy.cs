using Microsoft.Xna.Framework.Graphics;

namespace Project1.Enemy
{
    public interface IEnemy
    {
        // Will be called in Game1 and used to call IEnemyState to Update() current state
        void Update();
        // Will be called in Game1 and used to call IEnemyState to Draw() current state
        void Draw(SpriteBatch spriteBatch);
        // Only need this for sprint2, reset the position of IEnemy object to the start position
        void ResetPosition();
    }
}
