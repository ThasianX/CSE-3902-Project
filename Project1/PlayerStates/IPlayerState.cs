using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.PlayerStates
{
    public interface IPlayerState
    {
        void FaceDirection(Direction direction);
        void SetMoveInput(Direction direction, bool isPressed);
        void SwordAttack();
        void ShootArrow();
        void BoomerangAttack();
        void BombAttack();
       
        void Update();
        void Draw();
    }
}
