using Project1.Interfaces;
using System.Collections.ObjectModel;

namespace Project1.Levels
{
    public class Room
    {
        private Collection<IGameObject> gameObjects = new Collection<IGameObject>();

        // MARK: Setters
        public void AddObject(IGameObject gameObject) {
            gameObjects.Add(gameObject);
        }

        // MARK: Removers
        public void RemoveObject(IGameObject gameObject)
        {
            gameObjects.Remove(gameObject);
        }

        public void Activate() {
            foreach(IGameObject gameObject in gameObjects) {
                GameObjectManager.Instance.AddOnNextFrame(gameObject);
            }
        }

        public void Deactivate() {
            foreach(IGameObject obj in gameObjects)
            {
                GameObjectManager.Instance.RemoveOnNextFrame(obj);
            }
            
        }
    }
}
