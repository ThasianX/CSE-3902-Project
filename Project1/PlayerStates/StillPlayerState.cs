using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Project1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.PlayerStates
{
    public class StillPlayerState : IPlayerState
    {
        private Player player;

        private ISprite sprite;

        public StillPlayerState(Player player)
        {
            this.player = player;

            switch (player.facingDirection)
            {
                case Direction.Up:
                    sprite = SpriteFactory.Instance.CreateAnimatedSprite("sprite");
                    break;

                case Direction.Right:
                    sprite = SpriteFactory.Instance.CreateAnimatedSprite("sprite");
                    break;

                case Direction.Down:
                    sprite = SpriteFactory.Instance.CreateAnimatedSprite("sprite");
                    break;

                case Direction.Left:
                    sprite = SpriteFactory.Instance.CreateAnimatedSprite("sprite");
                    break;

                default:
                    break;
            }
        }

        public void FaceDirection(Direction direction)
        {
            player.facingDirection = direction;
            player.state = new StillPlayerState(player);
        }

        public void SetMoveInput(Direction direction, bool isPressed)
        {
            player.activeMoveInputs[direction] = isPressed;

            // switch to walking state if a movement key is pressed
            if (isPressed)
                player.state = new WalkingPlayerState(player);
        }

        public void SwordAttack()
        {
            player.state = new SwordAttackPlayerState(player);
        }
        public void ShootArrow()
        {
            player.state = new ShootArrowPlayerState(player);
        }

        public void BoomerangAttack()
        {
            player.state = new BoomerangAttackPlayerState(player);
        }

        public void BombAttack()
        {
            player.state = new BombAttackPlayerState(player);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, player.Position);
        }
    }
}
