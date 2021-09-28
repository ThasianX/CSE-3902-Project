using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Project1.Interfaces;

namespace Project1
{
    class TriforceItem : IAnimation
    {
        public string SpritesheetFileName { get; } = "item_spritesheet";
        public int CycleLength { get; } = 30;
        public Rectangle[] Sources { get; } =
{
            new Rectangle(275, 3, 10, 10),
            new Rectangle(275, 19, 10, 10)
        };
    }
}
