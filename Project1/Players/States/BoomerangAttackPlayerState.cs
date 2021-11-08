using Microsoft.Xna.Framework;
using Project1.Interfaces;
using Project1.Objects;

namespace Project1.PlayerStates
{
    public class BoomerangAttackPlayerState : IPlayerState
    {
        private IPlayer player;
        private IGameObject boomerang;

        private int boomerangOffset = 20;
        private int activeFrameCount = 50, counter = 0;

        public BoomerangAttackPlayerState(IPlayer player)
        {
            this.player = player;

            switch (player.FacingDirection)
            {
                case Direction.Up:
                    player.Sprite = SpriteFactory.Instance.CreateSprite("player_attack_up");
                    this.boomerang = new WoodBoomerang(player.Position + new Vector2(0, -boomerangOffset), player.FacingDirection, activeFrameCount);
                    break;

                case Direction.Right:
                    player.Sprite = SpriteFactory.Instance.CreateSprite("player_attack_right");
                    this.boomerang = new WoodBoomerang(player.Position + new Vector2(boomerangOffset, 0), player.FacingDirection, activeFrameCount);
                    break;

                case Direction.Down:
                    player.Sprite = SpriteFactory.Instance.CreateSprite("player_attack_down");
                    this.boomerang = new WoodBoomerang(player.Position + new Vector2(0, boomerangOffset), player.FacingDirection, activeFrameCount);
                    break;

                case Direction.Left:
                    player.Sprite = SpriteFactory.Instance.CreateSprite("player_attack_left");
                    this.boomerang = new WoodBoomerang(player.Position + new Vector2(-boomerangOffset, 0), player.FacingDirection, activeFrameCount);
                    break;

                default:
                    this.boomerang = new WoodBoomerang(player.Position + new Vector2(0, boomerangOffset), player.FacingDirection, activeFrameCount);
                    break;
            }
            GameObjectManager.Instance.AddOnNextFrame(boomerang);
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
        public void BoomerangAttack()
        {
            //Do nothing
        }

        public void BombAttack()
        {
        }

        public void Update(GameTime gameTime)
        {
            // End the attack after reaching its active frame count
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
        }
    }
}
