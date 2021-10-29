using Microsoft.Xna.Framework;

namespace Project1.PlayerStates
{
    public class StillPlayerState : IPlayerState
    {
        private IPlayer player;

        public StillPlayerState(IPlayer player)
        {
            this.player = player;

            switch (player.facingDirection)
            {
                case Direction.Up:
                    player.sprite = SpriteFactory.Instance.CreateSprite("player_idle_up");
                    break;

                case Direction.Right:
                    player.sprite = SpriteFactory.Instance.CreateSprite("player_idle_right");
                    break;

                case Direction.Down:
                    player.sprite = SpriteFactory.Instance.CreateSprite("player_idle_down");
                    break;

                case Direction.Left:
                    player.sprite = SpriteFactory.Instance.CreateSprite("player_idle_left");
                    break;

                default:
                    break;
            }
        }

        public void FaceDirection(Direction direction)
        {
            player.facingDirection = direction;
            player.state = new StillPlayerState(player);
        }

        public void SetMoveInput(Direction direction, bool isPressed)
        {
            player.activeMoveInputs[direction] = isPressed;

            // switch to walking state if a movement key is pressed
            if (isPressed)
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
        }
    }
}
