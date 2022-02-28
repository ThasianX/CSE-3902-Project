using System.Collections.Generic;
using Project1.Interfaces;
using Project1.Levels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.ObjectModel;
using System.Linq;

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
        private Collection<IGameObject> removeBuffer = new Collection<IGameObject>();
        private Collection<IGameObject> addBuffer = new Collection<IGameObject>();

        public GameObjectManager()
        {
            this.gameObjects = new Collection<IGameObject>();
        }

        public void Reset()
        {
            instance = new GameObjectManager();
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
                // BAD COUPLING
                if(!Game1.instance.isTransitioning) {
                    obj.Draw(sb);
                } else {
                    bool hasObject = LevelManager.Instance.GetRoom(Game1.instance.nextRoomId).HasObject(obj);
                    if((Game1.instance.animatingSecond && hasObject) || (!Game1.instance.animatingSecond && !hasObject)) {
                        obj.Draw(sb);
                    }
                }
            }
        }

        public void UpdateObjects(GameTime gameTime)
        {
            RemoveObjectsInBuffer();
            AddObjectsInBuffer();
            foreach (IGameObject obj in gameObjects)
            {
                obj.Update(gameTime);
            }  
        }

        private void AddObjectsInBuffer()
        {
            foreach (IGameObject gameObject in addBuffer)
            {
                if (!gameObjects.Contains(gameObject))
                {
                    gameObjects.Add(gameObject);
                }
            }
            addBuffer.Clear();
        }

        private void RemoveObjectsInBuffer()
        {
           foreach(IGameObject gameObject in removeBuffer)
           {
               gameObjects.Remove(gameObject);
           }
           removeBuffer.Clear();
        }

        public void AddImmediate(IGameObject obj)
        {
            gameObjects.Add(obj);
        }

        public void RemoveImmediate(IGameObject obj)
        {
            gameObjects.Remove(obj);
        }

        public void AddOnNextFrame(IGameObject obj)
        {
            if (!addBuffer.Contains(obj))
            {
                addBuffer.Add(obj);
            }
        }

        public void RemoveOnNextFrame(IGameObject obj)
        {
            // add the object to the list of objects to be removed on the next frame
            removeBuffer.Add(obj);
        }

        public void RemoveAll()
        {
            foreach(IGameObject gameObject in gameObjects) {
                removeBuffer.Add(gameObject);
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

        private List<ICollidable> GetCollidables() {
            return GetObjectsOfType<ICollidable>();
        }

        // return a list of ICollidable that is also a mover
        public List<ICollidable> GetMoverList()
        {
            return GetCollidables().Where(x => x.IsMover).ToList();
        }

        // return a list of ICollidable that is not a mover
        public List<ICollidable> GetStaticList()
        {
            return GetCollidables().Where(x => !x.IsMover).ToList();
        }
    }
}
//Team JellyLake Autumn 2021
