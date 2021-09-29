using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Project1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.PlayerStates
{
    public class SwordAttackPlayerState : IPlayerState
    {
        private Player player;

        private ISprite sprite;

        private int activeFrameCount = 15, counter = 0;

        public SwordAttackPlayerState(Player player)
        {
            this.player = player;

            switch (player.facingDirection)
            {
                case Direction.Up:
                    sprite = SpriteFactory.Instance.CreateAnimatedSprite(new LinkAttackUpAnimation());
                    break;

                case Direction.Right:
                    sprite = SpriteFactory.Instance.CreateAnimatedSprite(new LinkAttackRightAnimation());
                    break;

                case Direction.Down:
                    sprite = SpriteFactory.Instance.CreateAnimatedSprite(new LinkAttackDownAnimation());
                    break;

                case Direction.Left:
                    sprite = SpriteFactory.Instance.CreateAnimatedSprite(new LinkAttackLeftAnimation());
                    break;

                default:
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
            // Do nothing

        }
        public void ShootArrow()
        {
            //TODO
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

            sprite.Update();

        }

        public void Draw()
        {
            sprite.Draw(player.spriteBatch, player.position);
        }

    }
}
