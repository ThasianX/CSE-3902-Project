using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Project1.Interfaces;

namespace Project1
{
    public class CollisionManager
    {
        // Singleton instance
        private static CollisionManager instance = new CollisionManager();
        public static CollisionManager Instance
        {
            get
            {
                return instance;
            }
        }

        public Direction GetIntersectionSide(Rectangle target, Rectangle source)
        {
            float dx = target.Center.X - source.Center.X;
            float dy = target.Center.Y - source.Center.Y;
            Direction xSide = dx > 0 ? Direction.Left : Direction.Right; // if dx < 0, which means source is on target's right side, then target must get collision from right side.
            Direction ySide = dy > 0 ? Direction.Up : Direction.Down; // if dy < 0, which means source is on target's down(button) side, then target must get collision from down side.
            Rectangle intersection = Rectangle.Intersect(target, source);

            return intersection.Height > intersection.Width ? xSide : ySide;
        }

        //private Direction GetOppositeDirection(Direction direction)
        //{
        //    switch (direction)
        //    {
        //        case Direction.Left: return Direction.Right;
        //        case Direction.Right: return Direction.Left;
        //        case Direction.Up: return Direction.Down;
        //        case Direction.Down: return Direction.Up;
        //        default: return Direction.Left;
        //    }
        //}
        

        public void GeneralCollisionDetection()
        {
            // update movers and statics each update

            // movers is a list that only contains movers
            List<ICollidable> movers = GameObjectManager.Instance.GetMoverList();
            // statics is a different list that only contains non-movers
            List<ICollidable> statics = GameObjectManager.Instance.GetStaticList();

            for (int i = 0; i < movers.Count; i++)
            {
                // In this way, when A collide with B, we don't need to check B collide with A
                for (int j = i + 1; j < movers.Count; j++)
                {
                    CheckCollision(movers[i], movers[j]);
                }
                // Check mover, non-mover collision separately
                for (int k = 0; k < statics.Count; k++)
                {
                    CheckCollision(movers[i], statics[k]);
                }
            }
        }

        public void CheckCollision(ICollidable target, ICollidable source)
        {
            Rectangle targetRec = target.GetRectangle();
            Rectangle sourceRec = source.GetRectangle();
            if (targetRec.Intersects(sourceRec))
            {
                Collision col = new Collision();

                col.target = target;
                col.source = source;

                col.side = GetIntersectionSide(targetRec, sourceRec);

                col.intersection = Rectangle.Intersect(targetRec, sourceRec);

                // CollisionHandler will handle collision resolution
                CollisionHandler.Instance.HandleCollision(col);
            }
        }
        
        public void Update()
        {
            GeneralCollisionDetection();
        }
    }
}