using Microsoft.Xna.Framework;
using Project1.Interfaces;

namespace Project1.PlayerStates
{
    public class PickUpPlayerState : IPlayerState
    {
        private IPlayer player;

        public PickUpPlayerState(IPlayer player)
        {
            this.player = player;
            player.Sprite = SpriteFactory.Instance.CreateSprite("player_pickup");
        }

        public void SetMoveInput(Direction direction, bool isPressed)
        {
            player.ActiveMoveInputs[direction] = isPressed;
        }

        public void FaceDirection(Direction direction) { }
        public void SwordAttack() { }
        public void ShootArrow() { }
        public void ShootBullet() { }
        public void ShootShotGun()
        {
        }
        public void BoomerangAttack() { }
        public void BombAttack() { }
        public void Update(GameTime gameTime) { }
    }
}
