using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Project1.Interfaces;
using Project1.PlayerStates;

namespace Project1
{
    public interface IPlayer : IGameObject
    {
        public ISprite sprite { get; set; }
        public IPlayerState state { get; set; }
        public Direction facingDirection { get; set; }
        public float speed { get; set; }
        public Dictionary<Direction, bool> activeMoveInputs { get; set; }
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
