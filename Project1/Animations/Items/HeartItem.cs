using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Project1.Interfaces;

namespace Project1
{
    class HeartItem : IAnimation
    {        
        public string SpritesheetFileName { get; } = "item_spritesheet";
        public int CycleLength { get; } = 30;
        public Rectangle[] Sources { get; } =
{
            new Rectangle(0, 0, 7, 8),
            new Rectangle(0, 8, 7, 8)
        };
    }
}
