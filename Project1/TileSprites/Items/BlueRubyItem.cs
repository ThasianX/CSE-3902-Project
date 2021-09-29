using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Project1.Interfaces;

namespace Project1
{
    class BlueRubyItem : ITileData
    {        
        public string SpritesheetFileName { get; } = "item_spritesheet";

        public Rectangle Source { get; } = new Rectangle(72, 16, 8, 16);
    }
}
