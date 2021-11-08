using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Project1.Interfaces
{
    public interface IGameState
    {

        public void Update()
        { 
        }
        public void Draw(SpriteBatch spriteBatch)
        {
        }
        public void Pause()
        {
        }
    }
}
