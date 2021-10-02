using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Project1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Project1.Objects;

namespace Project1.PlayerStates
{
    public class ShootArrowPlayerState : IPlayerState
    {
        private Player player;
        private int arrowOffset = 8;
        private ISprite sprite;
        private WoodArrow arrow;

        private int activeFrameCount = 50, counter = 0;

        public ShootArrowPlayerState(Player player)
        {
            this.player = player;

            switch (player.facingDirection)
            {
                case Direction.Up:
                    sprite = SpriteFactory.Instance.CreateAnimatedSprite(new LinkAttackUpAnimation());
                    this.arrow = new WoodArrow(player.position + new Vector2(0, -arrowOffset), player.facingDirection, activeFrameCount);
                    break;

                case Direction.Right:
                    sprite = SpriteFactory.Instance.CreateAnimatedSprite(new LinkAttackRightAnimation());
                    this.arrow = new WoodArrow(player.position + new Vector2(arrowOffset, 0), player.facingDirection, activeFrameCount);
                    break;

                case Direction.Down:
                    sprite = SpriteFactory.Instance.CreateAnimatedSprite(new LinkAttackDownAnimation());
                    this.arrow = new WoodArrow(player.position + new Vector2(0, arrowOffset), player.facingDirection, activeFrameCount);
                    break;

                case Direction.Left:
                    sprite = SpriteFactory.Instance.CreateAnimatedSprite(new LinkAttackLeftAnimation());
                    this.arrow = new WoodArrow(player.position + new Vector2(-arrowOffset, 0), player.facingDirection, activeFrameCount);
                    break;

                default:
                    this.arrow = new WoodArrow(player.position + new Vector2(0, arrowOffset), player.facingDirection, activeFrameCount);
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
        public void UseItem()
        {
            //Do nothing
        }

        public void BombAttack()
        {
        }

        public void Update()
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
            arrow.Update();
            sprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            arrow.Draw(spriteBatch, player.position);
            sprite.Draw(spriteBatch, player.position);
        }

    }
}
