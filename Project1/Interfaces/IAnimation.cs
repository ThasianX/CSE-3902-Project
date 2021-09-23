using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Interfaces
{

    // This works but there has to be a better way to store animation data.
    // instancing the same data multiple times is wasteful
    interface IAnimation
    {
        public string SpritesheetFileName { get; } // The file name of the sprite sheet thes animation uses
        public int CycleLength { get; } // How many game loop iterations long the animation is
        public Rectangle[] Sources { get; } // The rectangles on the spritesheet for each frame

        public int Height 
        { 
            get 
            {
                return Sources[0].Height;
            }
        }

        public int Width 
        { 
            get 
            {
                return Sources[0].Width;
            } 
        }

        public int FrameCount
        {
            get
            {
                return Sources.Length;
            }
        }
    }
}
