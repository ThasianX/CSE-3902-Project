using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Project1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Project1.Objects;

namespace Project1.PlayerStates
{
    public class SwordAttackPlayerState : IPlayerState
    {
        private Player player;

        private ISprite sprite;
        private IItem item;

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
            this.item = new WoodSword(player.position, player.facingDirection);

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
            //This will crash game when SwordAttack is called because item is null
            if (this.item)
            {
                item.Update();
            }
            sprite.Update();
        }

        public void Draw()
        {
            if (this.item)
            {
                item.Draw(player.spriteBatch);
            }
            sprite.Draw(player.spriteBatch, player.position);
        }

    }
}
