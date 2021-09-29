using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Project1.Interfaces;

namespace Project1
{
    class LinkIdleUpAnimation : IAnimation
    {
        public string SpritesheetFileName { get; } = "link_spritesheet";
        public int CycleLength { get; } = 30;

        public Rectangle[] Sources { get; } =
        {
            new Rectangle(69,11,16,16)
        };

    }
}
