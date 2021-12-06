using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project1.Interfaces
{
    public interface IHealthState
    {
        public int health { get; set; }

        void Draw(SpriteBatch spriteBatch);
        void Update(GameTime gameTime);
        void TakeDamage(int damage);
        void Heal(int heal);

        public void AddHeartContainer();
    }
}