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
                    sprite = SpriteFactory.Instance.CreateAnimatedSprite(new LinkWalkingLeftAnimation());
                    break;

                default:
                    break;
            }
        }

        public void  SetMoveInput(Direction direction, bool isPressed)
        {
            /*switch (direction)
            {
                case Direction.Up:
                    player.movement += new Vector2(0, -1);
                    break;

                case Direction.Right:
                    player.movement += new Vector2(1, 0);
                    break;

                case Direction.Down:
                    player.movement += new Vector2(0, 1);
                    break;

                case Direction.Left:
                    player.movement += new Vector2(-1, 0);
                    break;

                default:
                    break;
            }*/

            player.activeMoveInputs[direction] = isPressed;
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
            // Calculate the direction of the movement vector
            Vector2 movement = new Vector2(0, 0);

            if (player.activeMoveInputs[Direction.Up])
                movement += new Vector2(0, -1);

            if (player.activeMoveInputs[Direction.Right])
                movement += new Vector2(1, 0);

            if (player.activeMoveInputs[Direction.Down])
                movement += new Vector2(0, 1);

            if (player.activeMoveInputs[Direction.Left])
                movement += new Vector2(-1, 0);

            // Normalize the vector to prevent moving faster on diagnals
            //movement = Vector2.Normalize(movement);

            // Apply speed
            movement *= player.speed;

            // Round to int (pixel space)
            movement = Vector2.Round(movement);

            player.Move(movement);

            sprite.Update();

            // Switch to still state if there is no movement input
            if (!player.activeMoveInputs[Direction.Up] && !player.activeMoveInputs[Direction.Right] && !player.activeMoveInputs[Direction.Down] && !player.activeMoveInputs[Direction.Left])
                player.state = new StillPlayerState(player);
        }

        public void Draw()
        {
            sprite.Draw(player.spriteBatch, player.position);
        }

    }
}
