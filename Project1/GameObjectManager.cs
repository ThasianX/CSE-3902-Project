using System;
using System.Collections.Generic;
using System.Text;
using Project1.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Project1
{
    public class GameObjectManager
    {
        //We can add more specific lists if needed e.g. Item, Block, Enemy
        public List<IGameObject> gameObjects;

        private SpriteBatch spriteBatch;
        public GameObjectManager(SpriteBatch sb)
        {
            this.spriteBatch = sb;
            this.gameObjects = new List<IGameObject>();
        }

        public void DrawObjects()
        {
            foreach (IGameObject obj in gameObjects)
            {
                obj.Draw(spriteBatch);
            }
        }

        public void UpdateObjects()
        {
            foreach (IGameObject obj in gameObjects)
            {
                obj.Update();
            }
        }
    }
}
