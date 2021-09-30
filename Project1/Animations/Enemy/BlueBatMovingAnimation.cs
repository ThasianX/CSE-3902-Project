using Microsoft.Xna.Framework;
using Project1.Interfaces;

namespace Project1.Animations
{
    public class BlueBatMovingAnimation : IAnimation
    {
        public string SpritesheetFileName { get; } = "enemies";
        public int CycleLength { get; } = 30;

        public Rectangle[] Sources { get; } =
        {
            new Rectangle(235,274,16,8),
            new Rectangle(263,273,10,10)
        };
    }
}

