using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Project1.Interfaces;

namespace Project1
{
    class BombSprite : ITileData
    {        
        public string SpritesheetFileName { get; } = "item_spritesheet";

        public Rectangle Source { get; } = new Rectangle(121, 185, 16, 16);
    }
}
