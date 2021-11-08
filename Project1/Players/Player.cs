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
        public InventoryManager playerInventory;

        public Player(Vector2 position)
        {
            this.Position = position;
            this.movement = new Vector2(0, 0);
            FacingDirection = Direction.Down;
            // Set entry state
            State = new StillPlayerState(this);
            healthState = new HealthState(this, 100);
            playerInventory = new InventoryManager();
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
            return (ActiveMoveInputs[Direction.Up]
                || ActiveMoveInputs[Direction.Right]
                || ActiveMoveInputs[Direction.Down]
                || ActiveMoveInputs[Direction.Left]);
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
            SoundManager.Instance.PlaySound("SwordSlash");
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
            healthState.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, Position);
            healthState.Draw(spriteBatch);
            //DrawRectangle(spriteBatch);
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            Sprite.Draw(spriteBatch, Position, color);
            healthState.Draw(spriteBatch);
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


        public void TakeDamage(int damage)
        {
            healthState.TakeDamage(damage);
            // replace basePlayer with damagedPlayer
            GameObjectManager.Instance.AddOnNextFrame(new DamagedPlayer(this));
            GameObjectManager.Instance.RemoveOnNextFrame(this);
        }

        public void Heal(int heal)
        {
            healthState.Heal(heal);
        }

        public Rectangle GetRectangle()
        {
            Dimensions dimensions = Sprite.GetDimensions();
            return new Rectangle((int)Position.X, (int)Position.Y, dimensions.width, dimensions.height);
        }

        public void CollectItem(IInventoryItem collectible)
        {
            playerInventory.AddItem(collectible);
            LevelManager.Instance.GetCurrentRoom().RemoveObject(collectible);
            GameObjectManager.Instance.RemoveOnNextFrame(collectible);
        }

        public void ShowCollection()
        {
            if (playerInventory.itemInv.Count == 0)
            {
                Console.WriteLine("Link don't have any items currently");
            }
            else
            {
                foreach (var item in playerInventory.itemInv)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }
        }
        public void InstantUseItem(IInstantUseItem collectible)
        {
            collectible.InstantUseItem(this);
            LevelManager.Instance.GetCurrentRoom().RemoveObject(collectible);
            GameObjectManager.Instance.RemoveOnNextFrame(collectible);
        }
    }
}
