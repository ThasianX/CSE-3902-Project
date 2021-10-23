using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Interfaces
{
    // ==================================== DEPRECATED! ===================================================
    interface ITileData
    {
        public string SpritesheetFileName { get; } // The file name of the sprite sheet thes animation uses
        public Rectangle Source { get; } // The rectangles on the spritesheet for each frame
        public int Height
        {
            get
            {
                return Source.Height;
            }
        }

        public int Width
        {
            get
            {
                return Source.Width;
            }
        }
    }
}
