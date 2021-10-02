using Microsoft.Xna.Framework;
using Project1.Interfaces;

namespace Project1
{
    public class FireballAnimation : IAnimation
    {
        public string SpritesheetFileName { get; } = "Enemy and Projectile";
        public int CycleLength { get; } = 30;
        public Rectangle[] Sources { get; } =
        {
            new Rectangle(249, 62, 8, 10),
            new Rectangle(231, 62, 8, 10),
            new Rectangle(240, 62, 8, 10)
        };
    }
}