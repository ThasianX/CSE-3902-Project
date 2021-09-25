using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Project1.Interfaces;

namespace Project1
{
    class PlainBlock : IStillSprite
    {
        
        public string SpritesheetFileName { get; } = "dungeon_sheet";

        public Rectangle Source { get; } = new Rectangle(339, 59, 16, 16);

        public int Width { get; }  = 16;

        public int Height { get; } = 16;

    }
}
