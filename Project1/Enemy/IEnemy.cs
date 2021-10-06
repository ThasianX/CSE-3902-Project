using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Enemy
{
    public interface IEnemy : IObject
    {
        // Only need this for sprint2, reset the position of IEnemy object to the start position
        void ResetPosition();
    }
}
