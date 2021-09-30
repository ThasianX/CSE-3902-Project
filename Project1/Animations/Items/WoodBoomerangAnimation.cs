using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Project1.Interfaces;

namespace Project1
{
    class WoodBoomerangAnimation : IAnimation
    {        
        public string SpritesheetFileName { get; } = "link_spritesheet";
        public int CycleLength { get; } = 24;
        public Rectangle[] Sources { get; } =
        {
            new Rectangle(69, 285, 16, 16),
            new Rectangle(86, 285, 16, 16),
            new Rectangle(103, 285, 16, 16),
            new Rectangle(120, 285, 16, 16),
            new Rectangle(137, 285, 16, 16),
            new Rectangle(154, 285, 16, 16),            
            new Rectangle(171, 285, 16, 16),
            new Rectangle(188, 285, 16, 16),
        };

    }
}
