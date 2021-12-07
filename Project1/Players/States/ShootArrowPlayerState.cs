using Microsoft.Xna.Framework;
using Project1.Interfaces;
using Project1.Objects;

namespace Project1.PlayerStates
{
    public class ShootArrowPlayerState : IPlayerState
    {
        private IPlayer player;
        private IProjectile arrow;

        private int arrowOffset = 8;
        private float activeTime = 0.1f, counter = 0f;

        public ShootArrowPlayerState(IPlayer player)
        {
            this.player = player;

            switch (player.FacingDirection)
            {
                case Direction.Up:
                    player.Sprite = SpriteFactory.Instance.CreateSprite("player_attack_up");
                    arrow = new WoodArrow(player.Position + new Vector2(0, -arrowOffset), player.FacingDirection, player);
                    break;

                case Direction.Right:
                    player.Sprite = SpriteFactory.Instance.CreateSprite("player_attack_right");
                    arrow = new WoodArrow(player.Position + new Vector2(arrowOffset, 0), player.FacingDirection, player);
                    break;

                case Direction.Down:
                    player.Sprite = SpriteFactory.Instance.CreateSprite("player_attack_down"); ;
                    arrow = new WoodArrow(player.Position + new Vector2(0, arrowOffset), player.FacingDirection, player);
                    break;

                case Direction.Left:
                    player.Sprite = SpriteFactory.Instance.CreateSprite("player_attack_left");
                    arrow = new WoodArrow(player.Position + new Vector2(-arrowOffset, 0), player.FacingDirection, player);
                    break;

                default:
                    arrow = new WoodArrow(player.Position + new Vector2(0, arrowOffset), player.FacingDirection, player);
                    break;
            }

            GameObjectManager.Instance.AddOnNextFrame(arrow);
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

        public void ShootShotGun()
        {
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
            counter += (float) gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
