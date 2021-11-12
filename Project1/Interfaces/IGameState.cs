using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;

namespace Project1.Interfaces
{
    public interface IGameState
    {
        public void Update(GameTime gametime, ArrayList controllerList) {}
        public void Draw(SpriteBatch spriteBatch) {}
        public void Pause() {}
        public void PickUp(IPlayer player, IInventoryItem item) {}
    }
}
