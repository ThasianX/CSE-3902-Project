using System.Collections.Generic;
using Project1.Interfaces;
using Project1.PlayerStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.ObjectModel;

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
        public Collection<IGameObject> gameObjects;
        private Collection<IGameObject> removeList = new Collection<IGameObject>();

        public GameObjectManager()
        {
            this.gameObjects = new Collection<IGameObject>();
        }

        public bool HasPlayer() {
            return Instance.GetObjectsOfType<IPlayer>().Count == 1;
        }

        public IPlayer GetPlayer() {
            return Instance.GetObjectsOfType<IPlayer>()[0];
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
            DeleteQueuedObjects();
            foreach (IGameObject obj in gameObjects)
            {
                obj.Update(gameTime);
            }
        }

        private void DeleteQueuedObjects()
        {
           foreach(IGameObject gameObject in removeList)
           {
               gameObjects.Remove(gameObject);
           }
            removeList.Clear();
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

        public void DestroyAll()
        {
            foreach(IGameObject gameObject in gameObjects) {
                removeList.Add(gameObject);
            }
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
                if (obj.IsMover)
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
                if (!obj.IsMover)
                {
                    statics.Add(obj);
                }
            }

            return statics;
        }
    }
}