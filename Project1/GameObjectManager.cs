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
        public List<IObject> gameObjects;

        private SpriteBatch spriteBatch;

        public GameObjectManager(SpriteBatch sb)
        {
            this.spriteBatch = sb;
        }
        
        public void DrawObjects()
        {
            foreach (IObject obj in gameObjects)
            {
                obj.Draw(spriteBatch);
            }
        }

        public void UpdateObjects()
        {
            foreach (IObject obj in gameObjects) {
                obj.Update();
            }
        }

        public void addObject(IObject gameObject)
        {
            gameObjects.Add(gameObject);
        }

        public void removeObject(IObject gameObject)
        {
            gameObjects.Remove(gameObject);
        }
    }
}
