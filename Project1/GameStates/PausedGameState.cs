﻿using System;
using System.Collections;
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
        public ISprite sprite;
        public PausedGameState(Game1 game)
        {
            this.game = game;
            //Obviously, don't want this image.
            sprite = SpriteFactory.Instance.CreateSprite("inventorySelect");
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
            sprite.Draw(spriteBatch, new Vector2(0,0));
        }
        public void Pause()
        {
            game.gameState = new PlayingGameState(game);
        }
    }
}
