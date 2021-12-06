using Microsoft.Xna.Framework;
using Project1.GameStates;
using Project1.Interfaces;

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

    public struct Dimensions
    {
        public int width;
        public int height;
    }

    public class Constants
    {
        public static int SPRITE_WIDTH => 8;
        public static int SPRITE_HEIGHT => 8;

        public static int TILE_SIZE = 16;

        public static int HP_PER_HEART = 2;

        public static float stunTime = .25f;

        public static float freezeTime = 3f;

        public static int maxHearts = 16;
    }

}
