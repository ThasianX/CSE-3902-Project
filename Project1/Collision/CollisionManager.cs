using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Project1.Interfaces;

namespace Project1.Collision
{
    public class CollisionManager
    {
        private List<ICollidable> movers;
        private List<ICollidable> colliders;
        private GameObjectManager manager;

        public CollisionManager(GameObjectManager manager)
        {
            this.manager = manager;
            colliders = manager.GetObjectsOfType<ICollidable>();
            movers = GetMovers(colliders);
        }

        // return the ICollidable that is also a mover
        public List<ICollidable> GetMovers(List<ICollidable> colliders)
        {
            List<ICollidable> movers = new List<ICollidable>();
            foreach (var collider in colliders)
            {
                if (collider.isMover)
                {
                    movers.Add(collider);
                }
            }

            return movers;
        }

        public Direction GetMoverCollisionSide(Rectangle target, Rectangle source)
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
        

        public void CollisionDetection()
        {
            foreach (ICollidable mover in movers)
            {
                foreach (ICollidable collider in colliders)
                {
                    if (!mover.Equals(collider))
                    {
                        Rectangle target = mover.GetRectangle();
                        Rectangle source = collider.GetRectangle();
                        if (target.Intersects(source))
                        {
                            Direction moverCollisionSide = GetMoverCollisionSide(target, source);
                            CheckCollision(mover, collider, moverCollisionSide); // display debug message to check collision
                            HandleCollision(mover, collider, moverCollisionSide);
                        }
                    }
                }
            }
        }

        public void CheckCollision(ICollidable mover, ICollidable collider, Direction moverCollisionSide)
        {
            if (collider.isMover)
            {
                Console.WriteLine($"Collision happened between mover and mover, mover get collision from {moverCollisionSide}");
            }
            else
            {
                Console.WriteLine($"Collision happened between mover and non-mover, mover get collision from {moverCollisionSide}");
            }
        }

        public void HandleCollision(ICollidable mover, ICollidable collider, Direction moverCollisionSide)
        {

        }

        public void Update()
        {
            CollisionDetection();
        }
    }
}