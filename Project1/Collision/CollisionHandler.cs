using System;
using Project1.Enemy;
using Project1.Interfaces;
using Project1.PlayerStates;

namespace Project1.Collision
{
    public class CollisionHandler
    {
        public CollisionHandler()
        {

        }

        public void HandleCollision(ICollidable target, ICollidable source, Direction CollisionSide)
        {
            CollisionDebug(target, source, CollisionSide); // display debug message to check collision
        }

        public void CollisionDebug(ICollidable target, ICollidable source, Direction targetCollisionSide)
        {
            if (target is IPlayer)
            {
                IPlayer player = target as IPlayer;
                player.TakeDamage(5);
            }
            // Might be helpful for handler to determine the Collider type
            CheckTargetType(target);
            CheckSourceType(source);
            // target will always be a mover
            if (source.isMover)
            {
                Console.WriteLine($"Collision happened between mover and mover, mover get collision from {targetCollisionSide}");
            }
            else
            {
                Console.WriteLine($"Collision happened between mover and non-mover, mover get collision from {targetCollisionSide}");
            }
        }

        private void CheckTargetType(ICollidable obj)
        {
            IEnemy enemy = obj as IEnemy;
            IPlayer link = obj as IPlayer;
            IItem weapon = obj as IItem;
            if (enemy != null)
            {
                Console.WriteLine("Mover is enemy");
            }

            if (link != null)
            {
                Console.WriteLine("Mover is link");
            }

            if (weapon != null)
            {
                Console.WriteLine("Mover is weapon or projectile");
            }
        }

        private void CheckSourceType(ICollidable obj)
        {
            IEnemy enemy = obj as IEnemy;
            IBlock block = obj as IBlock;
            IPlayer link = obj as IPlayer;
            IItem item = obj as IItem;

            if (enemy != null)
            {
                Console.WriteLine("Collider is enemy");
            }

            if (link != null)
            {
                Console.WriteLine("Collider is link");
            }

            if (block != null)
            {
                Console.WriteLine("Collider is block");
            }

            if (item != null)
            {
                Console.WriteLine("Collider is item");
            }
        }

    }
}
