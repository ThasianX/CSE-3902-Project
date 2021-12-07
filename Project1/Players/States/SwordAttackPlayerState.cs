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
        private IGameObject sword;

        private double activeTime = .25, counter = 0;

        public SwordAttackPlayerState(IPlayer player)
        {
            this.player = player;

            switch (player.FacingDirection)
            {
                case Direction.Up:
                    player.Sprite = SpriteFactory.Instance.CreateSprite("player_attack_up");
                    this.sword = new WoodSword(player.Position + new Vector2(0, -swordOffset), player.FacingDirection, activeTime);
                    break;

                case Direction.Right:
                    player.Sprite = SpriteFactory.Instance.CreateSprite("player_attack_right");
                    this.sword = new WoodSword(player.Position + new Vector2(swordOffset, 0), player.FacingDirection, activeTime);
                    break;

                case Direction.Down:
                    player.Sprite = SpriteFactory.Instance.CreateSprite("player_attack_down");
                    this.sword = new WoodSword(player.Position + new Vector2(0, swordOffset), player.FacingDirection, activeTime);
                    break;

                case Direction.Left:
                    player.Sprite = SpriteFactory.Instance.CreateSprite("player_attack_left");
                    this.sword = new WoodSword(player.Position + new Vector2(-swordOffset, 0), player.FacingDirection, activeTime);
                    break;

                default:
                    this.sword = new WoodSword(player.Position + new Vector2(0, swordOffset), player.FacingDirection, activeTime);
                    break;
            }
            GameObjectManager.Instance.AddOnNextFrame(sword);
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

        public void BombAttack()
        {
        }

        public void Update(GameTime gameTime)
        {
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
            counter += gameTime.ElapsedGameTime.TotalSeconds;
        }

    }
}
