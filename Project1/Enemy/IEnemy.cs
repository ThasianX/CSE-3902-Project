using Microsoft.Xna.Framework.Graphics;

namespace Project1.Enemy
{
    public interface IEnemy
    {
        void Update();
        void Draw(SpriteBatch spriteBatch);

        // Only need this for sprint2
        void ResetPosition();
    }
}
