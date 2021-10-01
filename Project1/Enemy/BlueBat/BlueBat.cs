﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project1.Enemy
{
    public class BlueBat : IEnemy
    {
        public IEnemyState state;
        public Vector2 position;
        private Vector2 startPosition;
        public float movingSpeed;
        private int choice;
        private Random rand = new Random();
        //private bool isLinkNearby;

        public BlueBat(Vector2 position)
        {
            this.position = position;
            startPosition = position;
            // When initialize, choose a random direction
            choice = rand.Next(4);
            switch (choice)
            {
                case 0:
                    state = new BlueBatUpMovingState(this);
                    break;
                case 1:
                    state = new BlueBatDownMovingState(this);
                    break;
                case 2:
                    state = new BlueBatRightMovingState(this);
                    break;
                case 3:
                    state = new BlueBatLeftMovingState(this);
                    break;
            }

            movingSpeed = 1f;
        }

        public void Update()
        {
            // Update the current state
            // Possible state: direction
            state.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            state.Draw(spriteBatch);
        }

        // Only need this for Sprint 2
        public void ResetPosition()
        {
            position = startPosition;
        }
    }
}