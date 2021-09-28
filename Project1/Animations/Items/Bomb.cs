using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Project1.Interfaces;

namespace Project1
{
    class Smoke : IAnimation
    {        
        public string SpritesheetFileName { get; } = "link_spritesheet";
        public int CycleLength { get; } = 30;

        public Rectangle[] Sources { get; } =
        {
            new Rectangle(138, 185, 16, 16),
            new Rectangle(155, 185, 16, 16),
            new Rectangle(175, 185, 16, 16),
        };

    }
}
