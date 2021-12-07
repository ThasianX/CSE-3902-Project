using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Project1.Interfaces;
using Project1.Objects;

namespace Project1.PlayerStates
{
    public class BombAttackPlayerState : IPlayerState
    {
        private IPlayer player;
        private IGameObject bomb;

        private int bombOffset = 16;
        private int activeFrameCount = 5, counter = 0;

        public BombAttackPlayerState(IPlayer player)
        {
            this.player = player;

            switch (player.FacingDirection)
            {
                case Direction.Up:
                    player.Sprite = SpriteFactory.Instance.CreateSprite("player_attack_up");
                    bomb = new Bomb(player.Position + new Vector2(0, -bombOffset));
                    break;

                case Direction.Right:
                    player.Sprite = SpriteFactory.Instance.CreateSprite("player_attack_right");
                    bomb = new Bomb(player.Position + new Vector2(bombOffset, 0));
                    break;

                case Direction.Down:
                    player.Sprite = SpriteFactory.Instance.CreateSprite("player_attack_down");
                    bomb = new Bomb(player.Position + new Vector2(0, bombOffset));
                    break;

                case Direction.Left:
                    player.Sprite = SpriteFactory.Instance.CreateSprite("player_attack_left");
                    bomb = new Bomb(player.Position + new Vector2(-bombOffset, 0));
                    break;

                default:
                    bomb = new Bomb(player.Position + new Vector2(0, bombOffset));
                    break;
            }
            GameObjectManager.Instance.AddOnNextFrame(bomb);
        }

        public void SetMoveInput(Direction direction, bool isPressed)
        {
            player.ActiveMoveInputs[direction] = isPressed;
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
        public void ShootBullet()
        {
        }

        public void ShootShotGun()
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
                    player.State = new WalkingPlayerState(player);
                }
                else
                {
                    player.State = new StillPlayerState(player);
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
