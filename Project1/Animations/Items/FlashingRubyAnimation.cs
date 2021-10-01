using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Project1.Interfaces;

namespace Project1
{
    class FlashingRubyAnimation : IAnimation
    {
        public string SpritesheetFileName { get; } = "item_spritesheet";
        public int CycleLength { get; } = 30;
        public Rectangle[] Sources { get; } =
{
            new Rectangle(72, 16, 8, 16),
            new Rectangle(72, 0, 8, 16)
        };
    }
}
