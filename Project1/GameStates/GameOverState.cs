﻿using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.GameStates
{
    class GameOverState : IGameState
    {
        public Game1 game;
        public GameOverState(Game1 game)
        {
            this.game = game;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            game.RenderGameOver();
        }

        public void Pause()
        {
        }

        public void Update(GameTime gametime, ArrayList controllerList)
        {
            foreach (IController controller in controllerList)
            {
                controller.Update();
            }
        }
    }
}
