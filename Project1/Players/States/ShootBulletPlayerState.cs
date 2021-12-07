using Microsoft.Xna.Framework;
using Project1.Interfaces;
using Project1.Objects;

namespace Project1.PlayerStates
{
    public class ShootBulletPlayerState : IPlayerState
    {
        private IPlayer player;
        private IProjectile bullet;


        private int bulletOffset = 9;

        private float activeTime = 0.1f, counter = 0f;

        public ShootBulletPlayerState(IPlayer player)
        {
            this.player = player;

            switch (player.FacingDirection)
            {
                case Direction.Up:
                    player.Sprite = SpriteFactory.Instance.CreateSprite("player_attack_up");
                    
                    bullet = new Bullet(player.Position + new Vector2(0, -bulletOffset), player.FacingDirection, player);

                    break;

                case Direction.Right:
                    player.Sprite = SpriteFactory.Instance.CreateSprite("player_attack_right");

                    bullet = new Bullet(player.Position + new Vector2(bulletOffset, 0), player.FacingDirection, player);

                    break;

                case Direction.Down:
                    player.Sprite = SpriteFactory.Instance.CreateSprite("player_attack_down"); ;

                    bullet = new Bullet(player.Position + new Vector2(0, bulletOffset), player.FacingDirection, player);

                    break;

                case Direction.Left:
                    player.Sprite = SpriteFactory.Instance.CreateSprite("player_attack_left");

                    bullet = new Bullet(player.Position + new Vector2(-bulletOffset, 0), player.FacingDirection, player);
                    break;

                default:
                    bullet = new Bullet(player.Position + new Vector2(0, bulletOffset), player.FacingDirection, player);

                    break;
            }

            GameObjectManager.Instance.AddOnNextFrame(bullet);
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