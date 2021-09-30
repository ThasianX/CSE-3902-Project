using Microsoft.Xna.Framework;
using Project1.Interfaces;

namespace Project1.Animations
{
    public class StalfosMovingAnimation : IAnimation
    {
        public string SpritesheetFileName { get; } = "enemies";
        public int CycleLength { get; } = 30;

        public Rectangle[] Sources { get; } =
        {
            new Rectangle(420,120,15,16),
            new Rectangle(420,150,15,16)
        };
    }
}
