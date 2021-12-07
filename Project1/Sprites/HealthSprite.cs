using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Sprites
{
    class HealthSprite: ISprite
    {
        private readonly SpriteFont font;
        private readonly IHealthState healthState;
        
        private int health;

        public HealthSprite(SpriteFont font, IHealthState healthState)
        {
            this.font = font;
            this.healthState = healthState;
            health = healthState.health;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            // Dont want to show this
            //spriteBatch.DrawString(font, "Health: " + health, location, Color.Black);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color) { }

        public void Update(GameTime gameTime)
        {
            health = healthState.health;
        }

        public Dimensions GetDimensions() {
            return new Dimensions();
        }
    }
}
