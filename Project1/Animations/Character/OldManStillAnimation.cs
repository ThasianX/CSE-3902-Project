using Microsoft.Xna.Framework;
using Project1.Interfaces;

namespace Project1.Animations
{
    public class OldManStillAnimation : IAnimation
    {
        public string SpritesheetFileName { get; } = "characters";
        public int CycleLength { get; } = 30;

        public Rectangle[] Sources { get; } =
        {
            new Rectangle(0,5,16,16)
           
            
        };
    }
}