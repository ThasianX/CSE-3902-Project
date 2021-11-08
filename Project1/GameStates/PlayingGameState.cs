using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project1.Interfaces;

namespace Project1.GameStates
{
    class PlayingGameState : IGameState
    {
        public Game1 game;
        private SpriteBatch spriteBatch;
        public PlayingGameState(Game1 game)
        {
            this.game = game;
            spriteBatch = new SpriteBatch(game.GraphicsDevice);
        }
        public void Update(GameTime gametime)
        {
            GameObjectManager.Instance.UpdateObjects(game.inGameTime);

            CollisionManager.Instance.Update();

            game.UpdateInGameTime();
        }
        public void Draw(GameTime gametime)
        {
            spriteBatch.Begin();
            GameObjectManager.Instance.DrawObjects(spriteBatch);
            spriteBatch.End();
        }
        public void Pause()
        {
            game.gameState = new PausedGameState(game);
        }
    }
}
