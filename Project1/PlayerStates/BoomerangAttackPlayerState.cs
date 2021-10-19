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
                    sprite = SpriteFactory.Instance.CreateSprite("player_attack_up");
                    this.boomerang = new WoodBoomerang(player.Position + new Vector2(0, -boomerangOffset), player.facingDirection, activeFrameCount);
                    break;

                case Direction.Right:
                    sprite = SpriteFactory.Instance.CreateSprite("player_attack_right");
                    this.boomerang = new WoodBoomerang(player.Position + new Vector2(boomerangOffset, 0), player.facingDirection, activeFrameCount);
                    break;

                case Direction.Down:
                    sprite = SpriteFactory.Instance.CreateSprite("player_attack_down");
                    this.boomerang = new WoodBoomerang(player.Position + new Vector2(0, boomerangOffset), player.facingDirection, activeFrameCount);
                    break;

                case Direction.Left:
                    sprite = SpriteFactory.Instance.CreateSprite("player_attack_left");
                    this.boomerang = new WoodBoomerang(player.Position + new Vector2(-boomerangOffset, 0), player.facingDirection, activeFrameCount);
                    break;

                default:
                    this.boomerang = new WoodBoomerang(player.Position + new Vector2(0, boomerangOffset), player.facingDirection, activeFrameCount);
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
            boomerang.Update(gameTime);
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            boomerang.Draw(spriteBatch);
            sprite.Draw(spriteBatch, player.Position);
        }
    }
}
