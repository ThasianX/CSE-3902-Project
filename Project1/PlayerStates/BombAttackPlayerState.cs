using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Project1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Project1.Objects;

namespace Project1.PlayerStates
{
    public class BombAttackPlayerState : IPlayerState
    {
        private Player player;
        private ISprite sprite;
        private Bomb bomb;

        private int bombOffset = 16;
        private int activeFrameCount = 40, counter = 0;

        public BombAttackPlayerState(Player player)
        {
            this.player = player;

            switch (player.facingDirection)
            {
                case Direction.Up:
                    sprite = SpriteFactory.Instance.CreateAnimatedSprite("player_attack_up");
                    bomb = new Bomb(player.Position + new Vector2(0, -bombOffset), activeFrameCount);
                    break;

                case Direction.Right:
                    sprite = SpriteFactory.Instance.CreateAnimatedSprite("player_attack_right");
                    bomb = new Bomb(player.Position + new Vector2(bombOffset, 0), activeFrameCount);
                    break;

                case Direction.Down:
                    sprite = SpriteFactory.Instance.CreateAnimatedSprite("player_attack_down");
                    bomb = new Bomb(player.Position + new Vector2(0, bombOffset), activeFrameCount);
                    break;

                case Direction.Left:
                    sprite = SpriteFactory.Instance.CreateAnimatedSprite("player_attack_left");
                    bomb = new Bomb(player.Position + new Vector2(-bombOffset, 0), activeFrameCount);
                    break;

                default:
                    bomb = new Bomb(player.Position + new Vector2(0, bombOffset), activeFrameCount);
                    break;
            }
        }

        public void SetMoveInput(Direction direction, bool isPressed)
        {
            player.activeMoveInputs[direction] = isPressed;
        }

        public void FaceDirection(Direction direction)
        {
        }

        public void SwordAttack()
        {
        }

        public void ShootArrow()
        {
        }

        public void BoomerangAttack()
        {
        }

        public void BombAttack()
        {
        }

        public void Update(GameTime gameTime)
        {
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
            bomb.Update(gameTime);
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            bomb.Draw(spriteBatch);
            sprite.Draw(spriteBatch, player.Position);
        }

    }
}
