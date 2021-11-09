using Microsoft.Xna.Framework;
using Project1.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Project1.PlayerStates;
using System.Collections.Generic;

namespace Project1
{
    public class DamagedPlayer : IPlayer, ICollidable
    {
        public IPlayer basePlayer;
        public string CollisionType => "Player";
        public bool IsMover => true;
        public ISprite Sprite
        {
            get { return basePlayer.Sprite; }
            set { basePlayer.Sprite = value; }
        }

        public IPlayerState State
        {
            get { return basePlayer.State; }
            set { basePlayer.State = value; }
        }

        public Vector2 Position
        {
            get { return basePlayer.Position; }
            set { basePlayer.Position = value; }
        }

        public Direction FacingDirection
        {
            get { return basePlayer.FacingDirection; }
            set { basePlayer.FacingDirection = value; }
        }


        public float Speed
        {
            get { return basePlayer.Speed; }
            set { basePlayer.Speed = value; }
        }

        public Dictionary<Direction, bool> ActiveMoveInputs
        {
            get { return basePlayer.ActiveMoveInputs; }
            set { basePlayer.ActiveMoveInputs = value; }
        }

        private int immuneTime = 30;

        public DamagedPlayer(IPlayer player)
        {
            this.basePlayer = player;
        }

        public void Update(GameTime gameTime)
        {
            immuneTime--;
            if (immuneTime == 0)
            {
                RemoveDecorator();
            }

            basePlayer.Update(gameTime);
        }

        public void RemoveDecorator()
        {
            GameObjectManager.Instance.RemoveOnNextFrame(this);
            GameObjectManager.Instance.AddOnNextFrame(basePlayer);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Color color = Color.Red;
            basePlayer.Draw(spriteBatch, color);
        }

        public Rectangle GetRectangle()
        {
            return ((ICollidable) basePlayer).GetRectangle();
        }

        public void Draw(SpriteBatch spriteBatch, Color color) { }
        public void BombAttack() { basePlayer.BombAttack(); }
        public void BoomerangAttack() { basePlayer.BoomerangAttack(); }
        public void CollectItem(IInventoryItem collectible) { basePlayer.CollectItem(collectible); }
        public void FaceDirection(Direction direction) { basePlayer.FaceDirection(direction); }
        public void SetMoveInput(Direction direction, bool isPressed) { basePlayer.SetMoveInput(direction, isPressed); }
        public void ShootArrow() { basePlayer.ShootArrow(); }
        public void ShowCollection() { basePlayer.ShowCollection(); }
        public void SwordAttack() { basePlayer.SwordAttack(); }
        public void TakeDamage(int damage) { }
        public bool hasAnyMoveInput()
        {
            return basePlayer.hasAnyMoveInput();
        }

        public void Move(Vector2 delta) { basePlayer.Move(delta); }
        public void Heal(int heal) { basePlayer.Heal(heal); }
        public void InstantUseItem(IInstantUseItem collectible) { basePlayer.InstantUseItem(collectible); }
    }
}