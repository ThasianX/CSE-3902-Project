using System;
using System.Collections;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project1.Interfaces;
using Project1.Objects;

namespace Project1.GameStates
{
    class PlayingGameState : IGameState
    {
        public Game1 game;
        public PlayingGameState(Game1 game)
        {
            this.game = game;
        }
        public void Update(GameTime gameTime, ArrayList controllerList)
        {
            GameOverCheck(GameObjectManager.Instance.GetPlayer(), GameObjectManager.Instance.GetPlayer().HealthState);
            foreach (IController controller in controllerList)
            {
                controller.Update();
            }

            GameObjectManager.Instance.UpdateObjects(gameTime);

            CollisionManager.Instance.Update();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            GameObjectManager.Instance.DrawObjects(spriteBatch);
        }
        public void Pause()
        {
            game.gameState = new PausedGameState(game);
        }

        public void GameOverCheck(IPlayer player, IHealthState playerHealth)
        {
            if (playerHealth.health <= 0 && !(game.gameState is GameOverState))
            {
                game.gameState = new GameOverState(game);
            }
        }
        
        public void PickUp(IPlayer player, IInventoryItem item)
        {
            game.gameState = new PickUpGameState(game, player, item);
        }
    }
}
