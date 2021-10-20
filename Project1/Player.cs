
using System.Collections.Generic;
using Project1.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.PlayerStates;

namespace Project1
{
    // The movement behavor of this player is not the same as in the original Legend of Zelda.
    // It is based on the movement in Binding of Isaac: you can move any direction no matter which direction you are facing.
    public class Player : IPlayer, ICollidable
    {
        public Vector2 Position { get; set; }

        public IPlayerState state;
        public IHealthState healthState;

        public SpriteBatch spriteBatch;

        public Direction facingDirection;

        public Vector2 movement;
        public bool isMover => true;
        private int immuneTime = 30;
        private int immnueTimeCounter;

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
            // Update immnueTimeCounter
            if (Immune())
            {
                immnueTimeCounter--;
            }
            else
            {
                healthState.Update(gameTime);
            }
           
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            state.Draw(spriteBatch);
            healthState.Draw(spriteBatch);

            // Visualize rectangle for testing
            Rectangle rectangle = GetRectangle();
            int lineWidth = 1;
            spriteBatch.Draw(Game1.whiteRectangle, new Rectangle(rectangle.X, rectangle.Y, lineWidth, rectangle.Height + lineWidth), Color.White);
            spriteBatch.Draw(Game1.whiteRectangle, new Rectangle(rectangle.X, rectangle.Y, rectangle.Width + lineWidth, lineWidth), Color.White);
            spriteBatch.Draw(Game1.whiteRectangle, new Rectangle(rectangle.X + rectangle.Width, rectangle.Y, lineWidth, rectangle.Height + lineWidth), Color.White);
            spriteBatch.Draw(Game1.whiteRectangle, new Rectangle(rectangle.X, rectangle.Y + rectangle.Height, rectangle.Width + lineWidth, lineWidth), Color.White);
        }

        // determine if player can take damage
        public bool Immune()
        {
            return immnueTimeCounter > 0;
        }

        public void TakeDamage(int damage)
        {
            // player can take damage only not immune
            if (!Immune())
            {
                immnueTimeCounter = immuneTime;
                healthState.TakeDamage(damage);
            }
            
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 16, 16);
        }
    }
}
