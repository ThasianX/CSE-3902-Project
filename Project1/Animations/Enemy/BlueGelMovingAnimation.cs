using Microsoft.Xna.Framework;
using Project1.Interfaces;

namespace Project1.Animations
{
    public class BlueGelMovingAnimation : IAnimation
    {
        public string SpritesheetFileName { get; } = "enemies";
        public int CycleLength { get; } = 30;

        public Rectangle[] Sources { get; } =
        {
            new Rectangle(404,184,8,8),
            new Rectangle(405,213,6,9)
        };
    }
}
