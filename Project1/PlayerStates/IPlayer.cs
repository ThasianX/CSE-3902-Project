using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Project1.Interfaces;

namespace Project1.PlayerStates
{
    public interface IPlayer : IGameObject
    {
        void FaceDirection(Direction direction);
        void SetMoveInput(Direction direction, bool isPressed);
        void SwordAttack();
        void ShootArrow();
        void BoomerangAttack();
        void BombAttack();

    }
}
