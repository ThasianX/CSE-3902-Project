using Microsoft.Xna.Framework;
using Project1.Interfaces;

namespace Project1.Animations
{
    public class AquamentusMovingAnimation : IAnimation
    {
        public string SpritesheetFileName { get; } = "bosses";
        public int CycleLength { get; } = 30;

        public Rectangle[] Sources { get; } =
        {
            new Rectangle(4,0,24,32),
            new Rectangle(49,0,24,32),
            
        };
    }
}
