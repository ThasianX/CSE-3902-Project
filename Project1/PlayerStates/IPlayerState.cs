using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.PlayerStates
{
    public interface IPlayerState
    {
        void FaceDirection(Direction direction);

        void SwordAttack();
        void ShootArrow();

        void Update();

        void Draw();



    }
}
