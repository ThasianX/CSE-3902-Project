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
        private int swordOffset = 8;
        private ISprite sprite;
        private ISprite healthSprite;
        private WoodSword sword;

        private int activeFrameCount = 20, counter = 0;

        public SwordAttackPlayerState(Player player)
        {
            this.player = player;

            switch (player.facingDirection)
            {
                case Direction.Up:
                    sprite = SpriteFactory.Instance.CreateAnimatedSprite(new LinkAttackUpAnimation());
                    this.sword = new WoodSword(player.Position + new Vector2(0, -swordOffset), player.facingDirection, activeFrameCount);
                    break;

                case Direction.Right:
                    sprite = SpriteFactory.Instance.CreateAnimatedSprite(new LinkAttackRightAnimation());
                    this.sword = new WoodSword(player.Position + new Vector2(swordOffset, 0), player.facingDirection, activeFrameCount);
                    break;

                case Direction.Down:
                    sprite = SpriteFactory.Instance.CreateAnimatedSprite(new LinkAttackDownAnimation());
                    this.sword = new WoodSword(player.Position + new Vector2(0, swordOffset), player.facingDirection, activeFrameCount);
                    break;

                case Direction.Left:
                    sprite = SpriteFactory.Instance.CreateAnimatedSprite(new LinkAttackLeftAnimation());
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
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sword.Draw(spriteBatch);
            sprite.Draw(spriteBatch, player.Position);
        }
    }
}
