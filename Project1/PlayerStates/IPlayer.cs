using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Project1.Interfaces;

namespace Project1
{
    public interface IPlayer : IGameObject
    {
        void FaceDirection(Direction direction);
        void SetMoveInput(Direction direction, bool isPressed);
        void SwordAttack();
        void ShootArrow();
        void BoomerangAttack();
        void BombAttack();
        public void TakeDamage(int damage);
        public void CollectItem(IGameObject collectible);
        public void ShowCollection();

    }
}
