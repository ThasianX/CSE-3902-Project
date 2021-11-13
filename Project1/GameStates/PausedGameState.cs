using System;
using System.Collections;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project1.Interfaces;
using Project1.UI;

namespace Project1.GameStates
{
    class PausedGameState : IGameState
    {
        public Game1 game;

        public PausedGameState(Game1 game)
        {
            this.game = game;
        }
        public void Update(GameTime gameTime, ArrayList controllerList)
        {
            foreach (IController controller in controllerList)
            {
                controller.UpdateOnRelease();
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            GameObjectManager.Instance.DrawObjects(spriteBatch);

            // BAD ===========================================================
            UIManager.Instance.inventoryFrame.Draw(spriteBatch, Vector2.Zero);
            UIManager.Instance.mapFrame.Draw(spriteBatch, new Vector2(0, 88));
            UIManager.Instance.inventory.Draw(spriteBatch);
            // BAD ===========================================================
        }
        public void Pause()
        {
            game.gameState = new PlayingGameState(game);
        }
        public void PickUp(IPlayer player, IInventoryItem item)
        {
        }
    }
}
