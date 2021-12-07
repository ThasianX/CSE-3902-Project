using Microsoft.Xna.Framework;

namespace Project1.PlayerStates
{
    public interface IPlayerState
    {
        void FaceDirection(Direction direction);
        void SetMoveInput(Direction direction, bool isPressed);
        void SwordAttack();
        void ShootArrow();
        void ShootBullet();
        void BoomerangAttack();
        void BombAttack();
       
        void Update(GameTime gameTime);
        void ShootShotGun();
    }
}
