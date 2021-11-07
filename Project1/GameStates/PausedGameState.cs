using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project1.Interfaces;

namespace Project1.GameStates
{
    class PausedGameState : IGameState
    {
        public Game1 game;
        private SpriteBatch spriteBatch;
        public PausedGameState(Game1 game)
        {
            this.game = game;
            spriteBatch = new SpriteBatch(game.GraphicsDevice);
        }
        public void Update()
        {

        }
        public void Draw(GameTime gametime)
        {

        }

        public void Pause()
        {
            game.gameState = new PlayingGameState(game);
        }
    }
}
