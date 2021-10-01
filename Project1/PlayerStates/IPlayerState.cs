using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Project1.PlayerStates
{
    public interface IPlayerState
    {
        void FaceDirection(Direction direction);
        void SetMoveInput(Direction direction, bool isPressed);
        void SwordAttack();
        void ShootArrow();
        void BoomerangAttack();
       
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
