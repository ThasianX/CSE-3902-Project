using Microsoft.Xna.Framework;

namespace Project1.PlayerStates
{
    public class StillPlayerState : IPlayerState
    {
        private IPlayer player;

        public StillPlayerState(IPlayer player)
        {
            this.player = player;

            switch (player.FacingDirection)
            {
                case Direction.Up:
                    player.Sprite = SpriteFactory.Instance.CreateSprite("player_idle_up");
                    break;

                case Direction.Right:
                    player.Sprite = SpriteFactory.Instance.CreateSprite("player_idle_right");
                    break;

                case Direction.Down:
                    player.Sprite = SpriteFactory.Instance.CreateSprite("player_idle_down");
                    break;

                case Direction.Left:
                    player.Sprite = SpriteFactory.Instance.CreateSprite("player_idle_left");
                    break;

                default:
                    break;
            }
        }

        public void FaceDirection(Direction direction)
        {
            player.FacingDirection = direction;
            player.State = new StillPlayerState(player);
        }

        public void SetMoveInput(Direction direction, bool isPressed)
        {
            player.ActiveMoveInputs[direction] = isPressed;

            // switch to walking state if a movement key is pressed
            if (isPressed)
                player.State = new WalkingPlayerState(player);
        }

        public void SwordAttack()
        {
            player.State = new SwordAttackPlayerState(player);
        }
        public void ShootArrow()
        {
            player.State = new ShootArrowPlayerState(player);
        }
        public void ShootBullet()
        {
            player.State = new ShootBulletPlayerState(player);
        }

        public void BoomerangAttack()
        {
            player.State = new BoomerangAttackPlayerState(player);
        }

        public void BombAttack()
        {
            player.State = new BombAttackPlayerState(player);
        }
        public void ShootShotGun()
        {
            player.State = new ShootShotGunPlayerState(player);
        }

        public void Update(GameTime gameTime)
        {
        }
    }
}
