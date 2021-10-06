using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Project1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Project1.Objects;

namespace Project1.PlayerStates
{
    public class BoomerangAttackPlayerState : IPlayerState
    {
        private Player player;
        private int boomerangOffset = 8;
        private ISprite sprite;
        private WoodBoomerang boomerang;

        private int activeFrameCount = 50, counter = 0;

        public BoomerangAttackPlayerState(Player player)
        {
            this.player = player;

            switch (player.facingDirection)
            {
                case Direction.Up:
                    sprite = SpriteFactory.Instance.CreateAnimatedSprite(new LinkAttackUpAnimation());
                    this.boomerang = new WoodBoomerang(player.position + new Vector2(0, -boomerangOffset), player.facingDirection, activeFrameCount);
                    break;

                case Direction.Right:
                    sprite = SpriteFactory.Instance.CreateAnimatedSprite(new LinkAttackRightAnimation());
                    this.boomerang = new WoodBoomerang(player.position + new Vector2(boomerangOffset, 0), player.facingDirection, activeFrameCount);
                    break;

                case Direction.Down:
                    sprite = SpriteFactory.Instance.CreateAnimatedSprite(new LinkAttackDownAnimation());
                    this.boomerang = new WoodBoomerang(player.position + new Vector2(0, boomerangOffset), player.facingDirection, activeFrameCount);
                    break;

                case Direction.Left:
                    sprite = SpriteFactory.Instance.CreateAnimatedSprite(new LinkAttackLeftAnimation());
                    this.boomerang = new WoodBoomerang(player.position + new Vector2(-boomerangOffset, 0), player.facingDirection, activeFrameCount);
                    break;

                default:
                    this.boomerang = new WoodBoomerang(player.position + new Vector2(0, boomerangOffset), player.facingDirection, activeFrameCount);
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
            boomerang.Update();
            sprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            boomerang.Draw(spriteBatch);
            sprite.Draw(spriteBatch, player.position);
        }
    }
}
