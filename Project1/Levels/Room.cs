using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;
using Project1.Objects;
using System.Collections.Generic;

namespace Project1.Levels
{
    public class Room
    {
        // The position of this room in relation to other rooms
        public Vector3 Position { get; set; }

        // Whether this room keeps its state when the changing rooms or resets
        bool savesOnLeave = false;

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
            if (savesOnLeave)
            {

                
                foreach (IGameObject obj in GameObjectManager.Instance.gameObjects)
                {
                    gameObjects.Add(obj);
                    GameObjectManager.Instance.RemoveOnNextFrame(obj);
                }
            }
            else
            {
                foreach (IGameObject obj in gameObjects)
                {
                    GameObjectManager.Instance.RemoveOnNextFrame(obj);
                }
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
