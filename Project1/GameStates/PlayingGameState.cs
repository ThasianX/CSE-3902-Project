﻿using System;
using System.Collections;
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
        public void Update(GameTime gameTime, ArrayList controllerList)
        {
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

        public void PickUp(IPlayer player, IInventoryItem item)
        {
            game.gameState = new PickUpGameState(game, player, item);
        }
    }
}
