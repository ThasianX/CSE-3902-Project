using Microsoft.Xna.Framework;
using Project1.Interfaces;
using Project1.Objects;

namespace Project1.PlayerStates
{
    public class ShootShotGunPlayerState : IPlayerState
    {
        private IPlayer player;
        private IProjectile bullet1, bullet2, bullet3, bullet4, bullet5;
        private int bulletOffset = 8;
        private float activeTime = 0.1f, counter = 0f;
        private float cosAmount = 0.3f;

        public ShootShotGunPlayerState(IPlayer player)
        {
            this.player = player;

            switch (player.FacingDirection)
            {
                case Direction.Up:
                    player.Sprite = SpriteFactory.Instance.CreateSprite("player_attack_up");
                    bullet1 = new ShootGunBullet(player.Position + new Vector2(0, -bulletOffset), player.FacingDirection, new Vector2(-2 * cosAmount, 0), player);
                    bullet2 = new ShootGunBullet(player.Position + new Vector2(0, -bulletOffset), player.FacingDirection, new Vector2(-cosAmount, 0), player);
                    bullet3 = new ShootGunBullet(player.Position + new Vector2(0, -bulletOffset), player.FacingDirection, new Vector2(0, 0), player);
                    bullet4 = new ShootGunBullet(player.Position + new Vector2(0, -bulletOffset), player.FacingDirection, new Vector2(cosAmount, 0), player);
                    bullet5 = new ShootGunBullet(player.Position + new Vector2(0, -bulletOffset), player.FacingDirection, new Vector2(2 * cosAmount, 0), player);
                    break;

                case Direction.Right:
                    player.Sprite = SpriteFactory.Instance.CreateSprite("player_attack_right");
                    bullet1 = new ShootGunBullet(player.Position + new Vector2(bulletOffset, 0), player.FacingDirection, new Vector2(0, -3 * cosAmount), player);
                    bullet2 = new ShootGunBullet(player.Position + new Vector2(bulletOffset, 0), player.FacingDirection, new Vector2(0, -cosAmount), player);
                    bullet3 = new ShootGunBullet(player.Position + new Vector2(bulletOffset, 0), player.FacingDirection, new Vector2(0, 0), player);
                    bullet4 = new ShootGunBullet(player.Position + new Vector2(bulletOffset, 0), player.FacingDirection, new Vector2(0, cosAmount), player);
                    bullet5 = new ShootGunBullet(player.Position + new Vector2(bulletOffset, 0), player.FacingDirection, new Vector2(0, 3 * cosAmount), player);
                    break;

                case Direction.Down:
                    player.Sprite = SpriteFactory.Instance.CreateSprite("player_attack_down"); ;
                    bullet1 = new ShootGunBullet(player.Position + new Vector2(0, bulletOffset), player.FacingDirection, new Vector2(-2 * cosAmount, 0), player);
                    bullet2 = new ShootGunBullet(player.Position + new Vector2(0, bulletOffset), player.FacingDirection, new Vector2(-cosAmount, 0), player);
                    bullet3 = new ShootGunBullet(player.Position + new Vector2(0, bulletOffset), player.FacingDirection, new Vector2(0, 0), player);
                    bullet4 = new ShootGunBullet(player.Position + new Vector2(0, bulletOffset), player.FacingDirection, new Vector2(cosAmount, 0), player);
                    bullet5 = new ShootGunBullet(player.Position + new Vector2(0, bulletOffset), player.FacingDirection, new Vector2(2 * cosAmount, 0), player);
                    break;

                case Direction.Left:
                    player.Sprite = SpriteFactory.Instance.CreateSprite("player_attack_left");
                    bullet1 = new ShootGunBullet(player.Position + new Vector2(-bulletOffset, 0), player.FacingDirection, new Vector2(0, -2 * cosAmount), player);
                    bullet2 = new ShootGunBullet(player.Position + new Vector2(-bulletOffset, 0), player.FacingDirection, new Vector2(0, -cosAmount), player);
                    bullet3 = new ShootGunBullet(player.Position + new Vector2(-bulletOffset, 0), player.FacingDirection, new Vector2(0, 0), player);
                    bullet4 = new ShootGunBullet(player.Position + new Vector2(-bulletOffset, 0), player.FacingDirection, new Vector2(0, cosAmount), player);
                    bullet5 = new ShootGunBullet(player.Position + new Vector2(-bulletOffset, 0), player.FacingDirection, new Vector2(0, 2 * cosAmount), player);
                    break;

                default:
                    break;
            }

            GameObjectManager.Instance.AddOnNextFrame(bullet1);
            GameObjectManager.Instance.AddOnNextFrame(bullet2);
            GameObjectManager.Instance.AddOnNextFrame(bullet3);
            GameObjectManager.Instance.AddOnNextFrame(bullet4);
            GameObjectManager.Instance.AddOnNextFrame(bullet5);
        }


        public void SetMoveInput(Direction direction, bool isPressed)
        {
            player.ActiveMoveInputs[direction] = isPressed;
        }

        public void FaceDirection(Direction direction)
        {
            // Do nothing
        }

        public void SwordAttack()
        {
            //Do nothing

        }
        public void ShootArrow()
        {
            //Do nothing
        }
        public void ShootBullet()
        {
            //Do nothing
        }
        public void BoomerangAttack()
        {
            //Do nothing
        }
        public void UseItem()
        {
            //Do nothing
        }

        public void BombAttack()
        {
        }

        public void Update(GameTime gameTime)
        {
            // TODO: Deal damage here

            // End the attack after reacing its active frame count
            if (counter >= activeTime)
            {
                if (player.hasAnyMoveInput())
                {
                    player.State = new WalkingPlayerState(player);
                }
                else
                {
                    player.State = new StillPlayerState(player);
                }
            }
            counter += (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void ShootShotGun()
        {
        }
    }
}
