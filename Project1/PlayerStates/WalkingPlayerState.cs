using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Project1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.PlayerStates
{
    public class WalkingPlayerState : IPlayerState
    {
        private Player player;

        private ISprite sprite;

        private Vector2 movement;

        public WalkingPlayerState(Player player)
        {
            this.player = player;

            switch (player.facingDirection)
            {
                case Direction.Up:
                    sprite = SpriteFactory.Instance.CreateAnimatedSprite(new LinkWalkingUpAnimation());
                    break;

                case Direction.Right:
                    sprite = SpriteFactory.Instance.CreateAnimatedSprite(new LinkWalkingRightAnimation());
                    break;

                case Direction.Down:
                    sprite = SpriteFactory.Instance.CreateAnimatedSprite(new LinkWalkingDownAnimation());
                    break;

                case Direction.Left:
                    // spritesheet is missing left walking sprite
                    //sprite = SpriteFactory.Instance.CreateAnimatedSprite(new LinkWalkingLeftAnimation());
                    break;

                default:
                    break;
            }
        }

        public void FaceDirection(Direction direction)
        {
            player.facingDirection = direction;
            player.state = new WalkingPlayerState(player);
            


        }

        public void SwordAttack()
        {
            //TODO
        }
        public void ShootArrow()
        {
            //TODO
        }

        public void Update()
        {
            player.Move(player.moveInput);
            sprite.Update();
        }

        public void Draw()
        {
            sprite.Draw(player.spriteBatch, player.position);
        }

    }
}
