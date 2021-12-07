using Project1.Interfaces;
using Project1.Objects;
using System.Collections.Generic;

namespace Project1.Levels
{
    public class Room
    {
        private List<IGameObject> gameObjects = new List<IGameObject>();
        public int id;

        public Room(int id)
        {
            this.id = id;
        }

        private Dictionary<Direction, Direction> directionSwap = new Dictionary<Direction, Direction>(){
            [Direction.Up] = Direction.Down,
            [Direction.Down] = Direction.Up,
            [Direction.Left] = Direction.Right,
            [Direction.Right] = Direction.Left,
        };

        // Getter;
        public List<IGameObject> GetObjects()
        {
            return gameObjects;
        }

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
                GameObjectManager.Instance.AddImmediate(gameObject);
            }
        }

        public void Deactivate() {
            foreach(IGameObject obj in gameObjects)
            {
                GameObjectManager.Instance.RemoveOnNextFrame(obj);
            }
        }

        public bool HasObject(IGameObject obj)
        {
            return gameObjects.Contains(obj);
        }

        public Door GetCorrespondingExit(Direction direction)
        {
            Direction swappedDirection = directionSwap[direction];
            return gameObjects.Find(obj => obj is Door && (obj as Door).direction == swappedDirection) as Door;
        }
    }
}
