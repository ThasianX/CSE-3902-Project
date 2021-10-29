using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Project1.Interfaces;
using Project1.Objects;

namespace Project1.PlayerStates
{
    public class SwordAttackPlayerState : IPlayerState
    {
        private IPlayer player;
        private int swordOffset = 8;
        private IItem sword;

        private int activeFrameCount = 20, counter = 0;

        public SwordAttackPlayerState(IPlayer player)
        {
            this.player = player;

            switch (player.facingDirection)
            {
                case Direction.Up:
                    player.sprite = SpriteFactory.Instance.CreateSprite("player_attack_up");
                    this.sword = new WoodSword(player.Position + new Vector2(0, -swordOffset), player.facingDirection, activeFrameCount);
                    break;

                case Direction.Right:
                    player.sprite = SpriteFactory.Instance.CreateSprite("player_attack_right");
                    this.sword = new WoodSword(player.Position + new Vector2(swordOffset, 0), player.facingDirection, activeFrameCount);
                    break;

                case Direction.Down:
                    player.sprite = SpriteFactory.Instance.CreateSprite("player_attack_down");
                    this.sword = new WoodSword(player.Position + new Vector2(0, swordOffset), player.facingDirection, activeFrameCount);
                    break;

                case Direction.Left:
                    player.sprite = SpriteFactory.Instance.CreateSprite("player_attack_left");
                    this.sword = new WoodSword(player.Position + new Vector2(-swordOffset, 0), player.facingDirection, activeFrameCount);
                    break;

                default:
                    this.sword = new WoodSword(player.Position + new Vector2(0, swordOffset), player.facingDirection, activeFrameCount);
                    break;
            }
        }

        public void SetMoveInput(Direction direction, bool isPressed)
        {
            player.activeMoveInputs[direction] = isPressed;
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
        public void BoomerangAttack()
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
            sword.Update(gameTime);
        }

        // TODO: Add sword to GameObjectManager
        public void Draw(SpriteBatch spriteBatch)
        {
            sword.Draw(spriteBatch);
        }
    }
}
