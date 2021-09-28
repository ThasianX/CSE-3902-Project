﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Project1.Interfaces;

namespace Project1
{
    class LinkWalkingLeftAnimation : IAnimation
    {

        public string SpritesheetFileName { get; } = "link_spritesheet";
        public int CycleLength { get; } = 30;

        public Rectangle[] Sources { get; } =
        {
            new Rectangle(120,11,16,16),
            new Rectangle(103,11,16,16)

        };

    }
}
