using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Interfaces
{
    interface IStillSprite
    {
        public string SpritesheetFileName { get; } // The file name of the sprite sheet thes animation uses
        public Rectangle Source { get; } // The rectangles on the spritesheet for each frame

        public int Width { get; }

        public int Height { get; }
    }
}
