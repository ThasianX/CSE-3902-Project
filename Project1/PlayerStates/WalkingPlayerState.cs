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
            player.activeMoveInputs[direction] = isPressed;
        }

        public void FaceDirection(Direction direction)
        {
            player.facingDirection = direction;
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
            // ^^^ This causes the game to crash. Needs looked into...

            // Apply speed
            movement *= player.speed;

            // Round to int (pixel space)
            movement = Vector2.Round(movement);

            player.Move(movement);

            sprite.Update();

            // Switch to still state if there is no movement input
            if (player.hasAnyMoveInput())
                player.state = new StillPlayerState(player);
        }

        public void Draw()
        {
            sprite.Draw(player.spriteBatch, player.position);
        }

    }
}
