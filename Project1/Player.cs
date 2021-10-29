using System;
using System.Collections.Generic;
using Project1.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.PlayerStates;
using Project1.Levels;

namespace Project1
{
    // The movement behavor of this player is not the same as in the original Legend of Zelda.
    // It is based on the movement in Binding of Isaac: you can move any direction no matter which direction you are facing.
    public class Player : IPlayer, ICollidable
    {
        public ISprite Sprite{ get; set; }
        public Vector2 Position { get; set; }
        public IPlayerState State { get; set; }
        public Direction FacingDirection { get; set; }
        public float Speed { get; set; }
        // Keeps track of which directional movement inputs are pressed
        public Dictionary<Direction, bool> ActiveMoveInputs { get; set; }
        public IHealthState healthState;
        public Vector2 movement;
        public bool IsMover => true;
        public string CollisionType => "Player";
        private int immuneTime = 60;
        private int immnueTimeCounter;
        // Temporary collection list for player
        public Dictionary<string, int> collectionList;

        public Player(Vector2 position)
        {
            this.Position = position;
            this.movement = new Vector2(0, 0);
            FacingDirection = Direction.Down;
            // Set entry state
            State = new StillPlayerState(this);
            healthState = new HealthState(this, 100);
            collectionList = new Dictionary<string, int>();
            ActiveMoveInputs = new Dictionary<Direction, bool>()
            {
                { Direction.Up, false },
                { Direction.Right, false },
                { Direction.Down, false },
                { Direction.Left, false }
            };
            Speed = 1f;
        }

        // Does not appear in IPlayerState (helper method)
        public void Move(Vector2 delta)
        {
            Position += delta * Speed;
        }

        public bool hasAnyMoveInput()
        {
            return (!ActiveMoveInputs[Direction.Up]
                && !ActiveMoveInputs[Direction.Right]
                && !ActiveMoveInputs[Direction.Down]
                && !ActiveMoveInputs[Direction.Left]);
        }

        // Redirect to state behaviors
        public void FaceDirection(Direction direction)
        {
            State.FaceDirection(direction);
        }

        public void SetMoveInput(Direction direction, bool isPressed)
        {
            State.SetMoveInput(direction, isPressed);
        }

        public void SwordAttack()
        {
            State.SwordAttack();
        }
        public void ShootArrow()
        {
            State.ShootArrow();
        }

        public void BoomerangAttack()
        {
            State.BoomerangAttack();
        }

        public void BombAttack()
        {
            State.BombAttack();
        }
        
        public void Update(GameTime gameTime)
        {
            State.Update(gameTime);
            Sprite.Update(gameTime);
            // When takeDamage is called, update once and wait for Immune to be false
            if (Immune() && immnueTimeCounter == immuneTime)
            {
                healthState.Update(gameTime);
                immnueTimeCounter--;
            }
            else if(Immune())
            {
                immnueTimeCounter --;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, Position);
            healthState.Draw(spriteBatch);
            //DrawRectangle(spriteBatch);

        }

        private void DrawRectangle(SpriteBatch spriteBatch)
        {
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

        public void CollectItem(IGameObject collectible)
        {
            var collectionName = collectible.GetType().Name;
            if (collectionList.ContainsKey(collectionName))
            {
                collectionList[collectionName]++;
            }
            else
            {
                collectionList.Add(collectionName, 1);
            }
            LevelManager.Instance.GetCurrentRoom().RemoveObject(collectible);
            GameObjectManager.Instance.RemoveOnNextFrame(collectible);
        }

        public void ShowCollection()
        {
            // Debug for collection command
            if (collectionList.Count == 0)
            {
                Console.WriteLine("Link don't have any collection currently");
            }
            else
            {
                foreach (var collection in collectionList)
                {
                    Console.WriteLine($"{collection.Key}: {collection.Value}");
                }
            }
        }
    }
}
