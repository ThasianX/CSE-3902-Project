using System;
using System.Collections.Generic;
using System.Text;
using Project1.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.PlayerStates;

namespace Project1
{
    // The movement behavor of this player is not the same as in the original Legend of Zelda.
    // It is based on the movement in Binding of Isaac: you can move any direction no matter which direction you are facing.
    public class Player : IGameObject
    {
        public Vector2 Position { get; set; }

        public IPlayerState state;
        public IHealthState healthState;

        public SpriteBatch spriteBatch;

        public Direction facingDirection;

        public Vector2 movement;

        // Keeps track of which directional movement inputs are pressed
        public Dictionary<Direction, bool> activeMoveInputs = new Dictionary<Direction, bool>()
        {
            { Direction.Up, false },
            { Direction.Right, false },
            { Direction.Down, false },
            { Direction.Left, false }
        };

        public float speed = 1f;

        public Player(Vector2 position)
        {
            this.Position = position;
            this.movement = new Vector2(0, 0);


            facingDirection = Direction.Down;


            // Set entry state
            state = new StillPlayerState(this);
            healthState = new HealthState(this, 100);
        }

        // Does not appear in IPlayerState (helper method)
        public void Move(Vector2 delta)
        {
            Position += delta * speed;
        }

        public bool hasAnyMoveInput()
        {
            return (!activeMoveInputs[Direction.Up]
                && !activeMoveInputs[Direction.Right]
                && !activeMoveInputs[Direction.Down]
                && !activeMoveInputs[Direction.Left]);
        }


        // Redirect to state behaviors
        public void FaceDirection(Direction direction)
        {
            state.FaceDirection(direction);
        }

        public void SetMoveInput(Direction direction, bool isPressed)
        {
            state.SetMoveInput(direction, isPressed);
        }

        public void SwordAttack()
        {
            state.SwordAttack();
        }
        public void ShootArrow()
        {
            state.ShootArrow();
        }

        public void BoomerangAttack()
        {
            state.BoomerangAttack();
        }

        public void BombAttack()
        {
            state.BombAttack();
        }
        
        public void Update(GameTime gameTime)
        {
            state.Update(gameTime);
            healthState.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            state.Draw(spriteBatch);
            healthState.Draw(spriteBatch);
        }

        public void TakeDamage(int damage)
        {
            healthState.TakeDamage(damage);
        }
    }
}
