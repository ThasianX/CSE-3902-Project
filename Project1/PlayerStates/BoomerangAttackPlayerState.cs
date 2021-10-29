using Microsoft.Xna.Framework;
using Project1.Interfaces;
using Project1.Objects;

namespace Project1.PlayerStates
{
    public class BoomerangAttackPlayerState : IPlayerState
    {
        private IPlayer player;
        private IItem boomerang;

        private int boomerangOffset = 20;
        private int activeFrameCount = 50, counter = 0;

        public BoomerangAttackPlayerState(IPlayer player)
        {
            this.player = player;

            switch (player.facingDirection)
            {
                case Direction.Up:
                    player.sprite = SpriteFactory.Instance.CreateSprite("player_attack_up");
                    this.boomerang = new WoodBoomerang(player.Position + new Vector2(0, -boomerangOffset), player.facingDirection, activeFrameCount);
                    break;

                case Direction.Right:
                    player.sprite = SpriteFactory.Instance.CreateSprite("player_attack_right");
                    this.boomerang = new WoodBoomerang(player.Position + new Vector2(boomerangOffset, 0), player.facingDirection, activeFrameCount);
                    break;

                case Direction.Down:
                    player.sprite = SpriteFactory.Instance.CreateSprite("player_attack_down");
                    this.boomerang = new WoodBoomerang(player.Position + new Vector2(0, boomerangOffset), player.facingDirection, activeFrameCount);
                    break;

                case Direction.Left:
                    player.sprite = SpriteFactory.Instance.CreateSprite("player_attack_left");
                    this.boomerang = new WoodBoomerang(player.Position + new Vector2(-boomerangOffset, 0), player.facingDirection, activeFrameCount);
                    break;

                default:
                    this.boomerang = new WoodBoomerang(player.Position + new Vector2(0, boomerangOffset), player.facingDirection, activeFrameCount);
                    break;
            }
            GameObjectManager.Instance.AddOnNextFrame(boomerang);
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
        }
    }
}
