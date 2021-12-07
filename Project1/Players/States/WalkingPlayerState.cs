using Microsoft.Xna.Framework;

namespace Project1.PlayerStates
{
    public class WalkingPlayerState : IPlayerState
    {
        private IPlayer player;

        public WalkingPlayerState(IPlayer player)
        {
            this.player = player;

            switch (player.FacingDirection)
            {
                case Direction.Up:
                    player.Sprite = SpriteFactory.Instance.CreateSprite("player_walking_up");
                    break;

                case Direction.Right:
                    player.Sprite = SpriteFactory.Instance.CreateSprite("player_walking_right");
                    break;

                case Direction.Down:
                    player.Sprite = SpriteFactory.Instance.CreateSprite("player_walking_down");
                    break;

                case Direction.Left:
                    player.Sprite = SpriteFactory.Instance.CreateSprite("player_walking_left");
                    break;

                default:
                    break;
            }
        }

        public void  SetMoveInput(Direction direction, bool isPressed)
        {
            player.ActiveMoveInputs[direction] = isPressed;
        }

        public void FaceDirection(Direction direction)
        {
            player.FacingDirection = direction;
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
        public void ShootShotGun()
        {
            player.State = new ShootShotGunPlayerState(player);
        }

        public void BoomerangAttack()
        {
            player.State = new BoomerangAttackPlayerState(player);
        }

        public void BombAttack()
        {
            player.State = new BombAttackPlayerState(player);
        }

        public void Update(GameTime gameTime)
        {
            // Calculate the direction of the movement vector
            Vector2 movement = new Vector2(0, 0);

            if (player.ActiveMoveInputs[Direction.Up])
                movement += new Vector2(0, -1);

            if (player.ActiveMoveInputs[Direction.Right])
                movement += new Vector2(1, 0);

            if (player.ActiveMoveInputs[Direction.Down])
                movement += new Vector2(0, 1);

            if (player.ActiveMoveInputs[Direction.Left])
                movement += new Vector2(-1, 0);

            // Normalize the vector to prevent moving faster on diagnals
            //movement = Vector2.Normalize(movement);
            // ^^^ This causes the game to crash. Needs looked into...

            // Apply speed
            movement *= player.Speed;

            // Round to int (pixel space)
            movement = Vector2.Round(movement);

            player.Move(movement);

            // Switch to still state if there is no movement input
            if (!player.hasAnyMoveInput())
                player.State = new StillPlayerState(player);
        }
    }
}
