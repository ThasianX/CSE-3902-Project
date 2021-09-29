using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Project1.Interfaces;

namespace Project1
{
    class VerticalWoodArrow : ITileData
    {        
        public string SpritesheetFileName { get; } = "link_spritesheet";

        public Rectangle Source { get; } = new Rectangle(2, 185, 7, 16);
    }
}
