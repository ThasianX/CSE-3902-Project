﻿using Microsoft.Xna.Framework;
using Project1.Interfaces;

namespace Project1.Animations
{
    public class RedGloriyaUpMovingAnimation : IAnimation
    {
        public string SpritesheetFileName { get; } = "enemies";
        public int CycleLength { get; } = 30;

        public Rectangle[] Sources { get; } =
        {
            new Rectangle(181,60,13,16),
            new Rectangle(181,90,13,16)
        };
    }
}
