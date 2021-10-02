using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Project1.Interfaces;

namespace Project1
{
    class BombAnimation: IAnimation
    {        
        public string SpritesheetFileName { get; } = "link_spritesheet";
        public int CycleLength { get; } = 44;
        public Rectangle[] Sources { get; } =
        {
            new Rectangle(121, 185, 16, 16),
            new Rectangle(138, 185, 16, 16),
            new Rectangle(155, 185, 16, 16),
            new Rectangle(172, 185, 16, 16),
        };

    }
}
