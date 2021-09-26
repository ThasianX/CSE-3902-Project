using System;
using System.Collections.Generic;
using System.Text;
using Project1.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project1.Player
{
    public class Player
    {
        public IPlayerState state;

        public SpriteBatch spriteBatch;

        public Direction facingDirection;

        public Vector2 position;

        public Vector2 moveInput;

        public float speed = 1f;

        public void Move(Vector2 delta)
        {
            position += delta * speed;
        }



        void FaceDirection(Direction direction)
        {
            state.FaceDirection(direction);
        }

        void SwordAttack()
        {
            state.SwordAttack();
        }
        void ShootArrow()
        {
            state.ShootArrow();
        }

        void Update()
        {
            state.Update();
        }

        void Draw()
        {
            state.Update();
        }

    }
}
