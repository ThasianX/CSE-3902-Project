using System;
using Microsoft.Xna.Framework;

namespace Project1.PlayerStates
{
    class PlayerKnockBackState : IPlayerState
    {
        private IPlayer player;
        private Direction damagedDirection;
        private Vector2 KnockBackAmount;
        private float activeTime = 0.1f, counter = 0f;
        public PlayerKnockBackState(IPlayer player, Direction damagedDirection)
        {
            this.player = player;
            this.damagedDirection = damagedDirection;
            switch (player.FacingDirection)
            {
                case Direction.Up: player.Sprite = SpriteFactory.Instance.CreateSprite("player_walking_up"); break;
                case Direction.Right: player.Sprite = SpriteFactory.Instance.CreateSprite("player_walking_right"); break;
                case Direction.Down: player.Sprite = SpriteFactory.Instance.CreateSprite("player_walking_down"); break;
                case Direction.Left: player.Sprite = SpriteFactory.Instance.CreateSprite("player_walking_left"); break;
            }
            switch (damagedDirection)
            {
                case Direction.Up: KnockBackAmount = new Vector2(0, -5); break;
                case Direction.Down: KnockBackAmount = new Vector2(0, 5); break;
                case Direction.Left: KnockBackAmount = new Vector2(-5, 0); break;
                case Direction.Right: KnockBackAmount = new Vector2(5, 0); break;
            }
        }

        public void Update(GameTime gameTime)
        {
            // End the attack after reacing its active frame count
            if (counter >= activeTime && player.Decorated)
            {
                if (player.hasAnyMoveInput())
                {
                    player.State = new WalkingPlayerState(player);
                }
                else
                {
                    player.State = new StillPlayerState(player);
                }
            }
            player.Move(KnockBackAmount);
            counter += (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void BombAttack() { }
        public void BoomerangAttack() { }
        public void FaceDirection(Direction direction) { }
        public void SetMoveInput(Direction direction, bool isPressed) { player.ActiveMoveInputs[direction] = isPressed; }
        public void ShootArrow() { }
        public void ShootBullet() { }
        public void ShootShotGun()
        {
        }
        public void SwordAttack() { }

    }
}
