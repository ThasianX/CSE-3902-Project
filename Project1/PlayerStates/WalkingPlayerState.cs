using Microsoft.Xna.Framework;

namespace Project1.PlayerStates
{
    public class WalkingPlayerState : IPlayerState
    {
        private IPlayer player;

        public WalkingPlayerState(IPlayer player)
        {
            this.player = player;

            switch (player.facingDirection)
            {
                case Direction.Up:
                    player.sprite = SpriteFactory.Instance.CreateSprite("player_walking_up");
                    break;

                case Direction.Right:
                    player.sprite = SpriteFactory.Instance.CreateSprite("player_walking_right");
                    break;

                case Direction.Down:
                    player.sprite = SpriteFactory.Instance.CreateSprite("player_walking_down");
                    break;

                case Direction.Left:
                    player.sprite = SpriteFactory.Instance.CreateSprite("player_walking_left");
                    break;

                default:
                    break;
            }
        }

        public void  SetMoveInput(Direction direction, bool isPressed)
        {
            player.activeMoveInputs[direction] = isPressed;
        }

        public void FaceDirection(Direction direction)
        {
            player.facingDirection = direction;
            player.state = new WalkingPlayerState(player);
        }

        public void SwordAttack()
        {
            player.state = new SwordAttackPlayerState(player);
        }
        public void ShootArrow()
        {
            player.state = new ShootArrowPlayerState(player);
        }

        public void BoomerangAttack()
        {
            player.state = new BoomerangAttackPlayerState(player);
        }

        public void BombAttack()
        {
            player.state = new BombAttackPlayerState(player);
        }

        public void Update(GameTime gameTime)
        {
            // Calculate the direction of the movement vector
            Vector2 movement = new Vector2(0, 0);

            if (player.activeMoveInputs[Direction.Up])
                movement += new Vector2(0, -1);

            if (player.activeMoveInputs[Direction.Right])
                movement += new Vector2(1, 0);

            if (player.activeMoveInputs[Direction.Down])
                movement += new Vector2(0, 1);

            if (player.activeMoveInputs[Direction.Left])
                movement += new Vector2(-1, 0);

            // Normalize the vector to prevent moving faster on diagnals
            //movement = Vector2.Normalize(movement);
            // ^^^ This causes the game to crash. Needs looked into...

            // Apply speed
            movement *= player.speed;

            // Round to int (pixel space)
            movement = Vector2.Round(movement);

            player.Move(movement);

            // Switch to still state if there is no movement input
            if (player.hasAnyMoveInput())
                player.state = new StillPlayerState(player);
        }
    }
}
