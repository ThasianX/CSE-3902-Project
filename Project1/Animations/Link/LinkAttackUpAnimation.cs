using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Project1.Interfaces;

namespace Project1
{
    class LinkAttackUpAnimation : IAnimation
    {

        public string SpritesheetFileName { get; } = "link_spritesheet";
        public int CycleLength { get; } = 60;

        public Rectangle[] Sources { get; } =
        {
            new Rectangle(1,109,16,16),
            new Rectangle(18,109,16,16),
            new Rectangle(35,109,16,16),
            new Rectangle(52,109,16,16),

        };

    }
}
