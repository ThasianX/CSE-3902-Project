using Microsoft.Xna.Framework;
using Project1.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Project1.Enemy;

namespace Project1
{
    public class DamagedEnemy : IEnemy, ICollidable
    {
        public IEnemy baseEnemy;
        public string CollisionType => "Enemy";
        public bool IsMover => true;
        public ISprite Sprite
        {
            get { return baseEnemy.Sprite; }
            set { baseEnemy.Sprite = value; }
        }

        public IEnemyState State
        {
            get { return baseEnemy.State; }
            set { baseEnemy.State = value; }
        }

        public bool isFreeze
        {
            get { return baseEnemy.isFreeze; }
            set { baseEnemy.isFreeze = value; }
        }

        public Vector2 Position
        {
            get { return baseEnemy.Position; }
            set { baseEnemy.Position = value; }
        }

        public float MovingSpeed
        {
            get { return baseEnemy.MovingSpeed; }
            set { baseEnemy.MovingSpeed = value; }
        }

        public LootTable LootTable
        {
            get { return baseEnemy.LootTable; }
        }

        private int immuneTime = 15;

        public DamagedEnemy(IEnemy enemy)
        {
            this.baseEnemy = enemy;
        }

        public void Freeze(float freezeTime)
        {
        }

        public void Defreeze(GameTime gameTime)
        {
        }

        public void Update(GameTime gameTime)
        {
            immuneTime--;
            if (immuneTime == 0)
            {
                RemoveDecorator();
            }

            baseEnemy.Update(gameTime);

        }

        public void RemoveDecorator()
        {
            GameObjectManager.Instance.RemoveOnNextFrame(this);
            GameObjectManager.Instance.AddOnNextFrame(baseEnemy);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Color color = Color.Red;
            baseEnemy.Draw(spriteBatch, color);

        }

        public Rectangle GetRectangle()
        {
            return ((ICollidable)baseEnemy).GetRectangle();
        }

        public void Draw(SpriteBatch spriteBatch, Color color) { }
        public void FireBallAttack() { baseEnemy.FireBallAttack(); }
        public void BoomerangAttack() { baseEnemy.BoomerangAttack(); }
        public void ChangeDirection() { baseEnemy.ChangeDirection(); }
        public void TakeDamage(int damage) { }
    }
}