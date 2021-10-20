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
        private static GameObjectManager instance = new GameObjectManager();
        public static GameObjectManager Instance
        {
            get
            {
                return instance;
            }
        }

        //We can add more specific lists if needed e.g. Item, Block, Enemy
        public List<IGameObject> gameObjects;

        private SpriteBatch spriteBatch;
        public GameObjectManager()
        {
            this.gameObjects = new List<IGameObject>();
        }

        public void DrawObjects(SpriteBatch sb)
        {
            foreach (IGameObject obj in gameObjects)
            {
                obj.Draw(sb);
            }
        }

        public void UpdateObjects(GameTime gameTime)
        {
            foreach (IGameObject obj in gameObjects)
            {
                obj.Update(gameTime);
            }
        }

        public void Add(IGameObject obj)
        {
            gameObjects.Add(obj);
        }

        public void Destroy(IGameObject obj)
        {
            // The garbage collector disposes the object once the reference is lost
            gameObjects.Remove(obj);
        }

        public List<T> GetObjectsOfType<T>()
        {
            List<T> list = new List<T>();

            foreach (IGameObject obj in gameObjects)
            {
                if (obj is T)
                {
                    list.Add((T)obj);
                }
            }

            return list;
        }

        // return a list of ICollidable that is also a mover
        public List<ICollidable> GetMoverList()
        {
            List<ICollidable> movers = new List<ICollidable>();
            foreach (ICollidable obj in gameObjects)
            {
                if (obj.isMover)
                {
                    movers.Add(obj);
                }
            }

            return movers;
        }

        // return a list of ICollidable that is not a mover
        public List<ICollidable> GetStaticList()
        {
            List<ICollidable> statics = new List<ICollidable>();
            foreach (ICollidable obj in gameObjects)
            {
                if (!obj.isMover)
                {
                    statics.Add(obj);
                }
            }

            return statics;
        }
    }
}
