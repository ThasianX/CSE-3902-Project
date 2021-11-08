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
        public PlayingGameState(Game1 game)
        {
            this.game = game;
        }
        public void Update()
        {
            GameObjectManager.Instance.UpdateObjects(game.inGameTime);

            CollisionManager.Instance.Update();

            game.UpdateInGameTime();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            GameObjectManager.Instance.DrawObjects(spriteBatch);
        }
        public void Pause()
        {
            game.gameState = new PausedGameState(game);
        }
    }
}
