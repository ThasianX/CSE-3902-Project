using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Project1.Interfaces;

namespace Project1
{
    class KeyItem : ITileData
    {        
        public string SpritesheetFileName { get; } = "item_spritesheet";

        public Rectangle Source { get; } = new Rectangle(485, 1104, 16, 16);
    }
}
