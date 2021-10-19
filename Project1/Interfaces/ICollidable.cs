using Microsoft.Xna.Framework;

namespace Project1.Interfaces
{
    public interface ICollidable
    {
        Rectangle GetRectangle();
        bool isMover { get; }
    }
}
