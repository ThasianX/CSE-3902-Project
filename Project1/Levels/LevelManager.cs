using System.Collections.Generic;

namespace Project1.Levels
{
    public class LevelManager
    {
        private int currentRoomIndex;

        private LevelGenerator generator;

        public Dictionary<Maze.Direction, bool>[,] doorMatrix; // Necessary Coupling: need to expose this for minimap

        private static LevelManager instance = new LevelManager(1);

        public static LevelManager Instance
        {
            get
            {
                return instance;
            }
        }
        
        public LevelManager(int level)
        {
            currentRoomIndex = 0;
            generator = new LevelGenerator(level);
        }

        private List<Room> Rooms
        {
            get
            {
                return generator.rooms;
            }
        }

        public Room GetRoom(int roomId)
        {
            return Rooms[Rooms.FindIndex(r => r.id == roomId)];
        }

        public Room GetCurrentRoom()
        {
            return Rooms[currentRoomIndex];
        }

        public Room ActivateNextRoom(int roomId)
        {
            IPlayer player = GameObjectManager.Instance.GetObjectsOfType<IPlayer>()[0];
            GetCurrentRoom().RemoveObject(player);
            GameObjectManager.Instance.RemoveImmediate(player);

            int nextRoomIndex = Rooms.FindIndex(r => r.id == roomId);

            // =========================================================================================
            Rooms[nextRoomIndex].AddObject(player);
            // =========================================================================================
            Rooms[nextRoomIndex].Activate();

            return Rooms[nextRoomIndex];
        }

        public void DeactiveCurrentRoom(int roomId)
        {
            GetCurrentRoom().Deactivate();
            currentRoomIndex = Rooms.FindIndex(r => r.id == roomId);
        }

        public void _moveRoom(int room)
        {
            GetCurrentRoom().Deactivate();
            // BAD SOLUTION! DO NOT LEAVE IN FOR SPRINT 4! =============================================
            IPlayer player = GameObjectManager.Instance.GetObjectsOfType<IPlayer>()[0];
            GetCurrentRoom().RemoveObject(player);
            // =========================================================================================

            currentRoomIndex = room - 1;

            // =========================================================================================
            GetCurrentRoom().AddObject(player);
            // =========================================================================================
            GetCurrentRoom().Activate();
        }

        public void IncrementRoom()
        {
            _moveRoom(((currentRoomIndex + 1) % Rooms.Count) + 1);
        }

        public void DecrementRoom()
        {
            _moveRoom(((currentRoomIndex - 1 < 0 ? Rooms.Count - 1 : currentRoomIndex - 1) % Rooms.Count) + 1);
        }

        public void Reset()
        {
            instance = new LevelManager(1);
        }

        public void LoadLevel() {
            generator.LoadLevel();
            GetCurrentRoom().Activate();
        }
    }
}