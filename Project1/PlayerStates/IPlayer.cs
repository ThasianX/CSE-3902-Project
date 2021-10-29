using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Project1.Interfaces;
using Project1.PlayerStates;

namespace Project1
{
    public interface IPlayer : IGameObject
    {
        public ISprite Sprite { get; set; }
        public IPlayerState State { get; set; }
        public Direction FacingDirection { get; set; }
        public float Speed { get; set; }
        public Dictionary<Direction, bool> ActiveMoveInputs { get; set; }
        public bool hasAnyMoveInput();
        public void Move(Vector2 delta);
        void FaceDirection(Direction direction);
        void SetMoveInput(Direction direction, bool isPressed);
        void SwordAttack();
        void ShootArrow();
        void BoomerangAttack();
        void BombAttack();
        public void TakeDamage(int damage);
        public void CollectItem(IGameObject collectible);
        public void ShowCollection();

    }
}
