using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Project1.Interfaces;
using Project1.Objects;

namespace Project1.PlayerStates
{
    public class BombAttackPlayerState : IPlayerState
    {
        private IPlayer player;
        private IItem bomb;

        private int bombOffset = 16;
        private int activeFrameCount = 40, counter = 0;

        public BombAttackPlayerState(IPlayer player)
        {
            this.player = player;

            switch (player.facingDirection)
            {
                case Direction.Up:
                    player.sprite = SpriteFactory.Instance.CreateSprite("player_attack_up");
                    bomb = new Bomb(player.Position + new Vector2(0, -bombOffset));
                    break;

                case Direction.Right:
                    player.sprite = SpriteFactory.Instance.CreateSprite("player_attack_right");
                    bomb = new Bomb(player.Position + new Vector2(bombOffset, 0));
                    break;

                case Direction.Down:
                    player.sprite = SpriteFactory.Instance.CreateSprite("player_attack_down");
                    bomb = new Bomb(player.Position + new Vector2(0, bombOffset));
                    break;

                case Direction.Left:
                    player.sprite = SpriteFactory.Instance.CreateSprite("player_attack_left");
                    bomb = new Bomb(player.Position + new Vector2(-bombOffset, 0));
                    break;

                default:
                    bomb = new Bomb(player.Position + new Vector2(0, bombOffset));
                    break;
            }
        }

        public void SetMoveInput(Direction direction, bool isPressed)
        {
            player.activeMoveInputs[direction] = isPressed;
        }

        public void FaceDirection(Direction direction)
        {
        }

        public void SwordAttack()
        {
        }

        public void ShootArrow()
        {
        }

        public void BoomerangAttack()
        {
        }

        public void BombAttack()
        {
        }

        public void Update(GameTime gameTime)
        {
            if (counter++ >= activeFrameCount)
            {
                if (player.hasAnyMoveInput())
                {
                    player.state = new WalkingPlayerState(player);
                }
                else
                {
                    player.state = new StillPlayerState(player);
                }
            }
            bomb.Update(gameTime);
        }
        // TODO: Add bomb to GameObjectManager
        public void Draw(SpriteBatch spriteBatch)
        {
            bomb.Draw(spriteBatch);
        }

    }
}
