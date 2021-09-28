﻿using Microsoft.Xna.Framework.Graphics;
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
                    sprite = SpriteFactory.Instance.CreateAnimatedSprite(new LinkIdleUpAnimation());
                    break;

                case Direction.Right:
                    sprite = SpriteFactory.Instance.CreateAnimatedSprite(new LinkIdleRightAnimation());
                    break;

                case Direction.Down:
                    sprite = SpriteFactory.Instance.CreateAnimatedSprite(new LinkIdleDownAnimation());
                    break;

                case Direction.Left:
                    sprite = SpriteFactory.Instance.CreateAnimatedSprite(new LinkIdleLeftAnimation());
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
            sprite.Update();
        }

        public void Draw()
        {
            sprite.Draw(player.spriteBatch, player.position);
        }

    }
}
