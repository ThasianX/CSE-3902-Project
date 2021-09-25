using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Project1.Interfaces;

namespace Project1
{
    class LadderBlock : IStillSprite
    {
        
        public string SpritesheetFileName { get; } = "dungeon_sheet";

        public Rectangle Source { get; } = new Rectangle(469,1104, 16, 16);

        public int Width { get; }  = 16;

        public int Height { get; } = 16;

    }
}
