using Microsoft.Xna.Framework;

namespace Project1.Interfaces
{
    public interface ICollidable
    {
        Rectangle GetRectangle();
        bool IsMover { get; }
        string CollisionType { get; }
    }
}
