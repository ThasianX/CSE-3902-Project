using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Project1.Interfaces;

namespace Project1
{
    class WoodBoomerang : IAnimation
    {        
        public string SpritesheetFileName { get; } = "link_spritesheet";
        public int CycleLength { get; } = 30;
        public Rectangle[] Sources { get; } =
        {
            new Rectangle(64, 185, 8, 16),
            new Rectangle(73, 185, 8, 16),
            new Rectangle(82, 185,8, 16),
        };

    }
}
