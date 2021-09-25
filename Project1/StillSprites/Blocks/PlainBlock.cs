using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Project1.Interfaces;

namespace Project1
{
    class HorizontalWoodArrow : IStillSprite
    {        
        public string SpritesheetFileName { get; } = "dungeon_sheet";

        public Rectangle Source { get; } = new Rectangle(339, 59, 16, 16);
    }
}
