using Microsoft.Xna.Framework;
using Project1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    public enum Direction
    {
        Up, Right, Down, Left
    }

    public struct Collision
    {
        public ICollidable source, target;
        public Direction side;
        public Rectangle intersection;
    }
    public class Constants
    {
        public static int SPRITE_WIDTH => 8;
        public static int SPRITE_HEIGHT => 8;
    }
}
