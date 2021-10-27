using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Project1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Project1.Objects;

namespace Project1.PlayerStates
{
    public class ShootArrowPlayerState : IPlayerState
    {
        private Player player;
        private int arrowOffset = 8;
        private ISprite sprite;
        private WoodArrow arrow;

        private float activeTime = 0.1f, counter = 0f;

        public ShootArrowPlayerState(Player player)
        {
            this.player = player;
            WoodArrow arrow;

            switch (player.facingDirection)
            {
                case Direction.Up:
                    sprite = SpriteFactory.Instance.CreateSprite("player_attack_up");
                    arrow = new WoodArrow(player.Position + new Vector2(0, -arrowOffset), player.facingDirection);
                    break;

                case Direction.Right:
                    sprite = SpriteFactory.Instance.CreateSprite("player_attack_right");
                    arrow = new WoodArrow(player.Position + new Vector2(arrowOffset, 0), player.facingDirection);
                    break;

                case Direction.Down:
                    sprite = SpriteFactory.Instance.CreateSprite("player_attack_down"); ;
                    arrow = new WoodArrow(player.Position + new Vector2(0, arrowOffset), player.facingDirection);
                    break;

                case Direction.Left:
                    sprite = SpriteFactory.Instance.CreateSprite("player_attack_left");
                    arrow = new WoodArrow(player.Position + new Vector2(-arrowOffset, 0), player.facingDirection);
                    break;

                default:
                    arrow = new WoodArrow(player.Position + new Vector2(0, arrowOffset), player.facingDirection);
                    break;
            }

            GameObjectManager.Instance.AddOnNextFrame(arrow);
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
        public void UseItem()
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
            if (counter >= activeTime)
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
            sprite.Update(gameTime);
            counter += (float) gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, player.Position);
        }

    }
}
