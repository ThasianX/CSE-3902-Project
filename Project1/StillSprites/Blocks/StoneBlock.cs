using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Project1.Interfaces;

namespace Project1
{
    class StoneBlock : IStillSprite
    {
        public string SpritesheetFileName { get; } = "dungeon_sheet";

        public Rectangle Source { get; } = new Rectangle(421, 1009, 16, 16);
    }
}
