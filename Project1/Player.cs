using System;
using System.Collections.Generic;
using System.Text;
using Project1.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.PlayerStates;

namespace Project1
{
    public class Player
    {
        public IPlayerState state;

        public SpriteBatch spriteBatch;

        public Direction facingDirection;

        public Vector2 position;

        public Vector2 moveInput;

        public float speed = 1f;

        public Player(Vector2 position, SpriteBatch spriteBatch)
        {
            this.spriteBatch = spriteBatch;
            this.position = position;

            facingDirection = Direction.Down;

            state = new StillPlayerState(this);

        }

        public void Move(Vector2 delta)
        {
            position += delta * speed;
        }



        public void FaceDirection(Direction direction)
        {
            state.FaceDirection(direction);
        }

        public void SwordAttack()
        {
            state.SwordAttack();
        }
        public void ShootArrow()
        {
            state.ShootArrow();
        }

        public void Update()
        {
            state.Update();
        }

        public void Draw()
        {
            state.Draw();
        }

    }
}
