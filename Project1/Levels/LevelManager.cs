using System;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Project1.Enemy;
using Project1.Objects;
using System.Collections.ObjectModel;

namespace Project1.Levels
{
    public class LevelManager
    {
        private int totalRooms;
        private int currentRoomIndex;
        private Collection<Room> rooms;
        private XDocument spriteData;
        
        public LevelManager(int level)
        {
            totalRooms = 0;
            currentRoomIndex = 0;
            rooms = new Collection<Room>();
            spriteData = XDocument.Load("Levels/LevelData/Level" + level + ".xml");
        }

        public Room GetCurrentRoom()
        {
            return rooms[currentRoomIndex];
        }

        public void IncrementRoom()
        {
            currentRoomIndex = (currentRoomIndex + 1) % totalRooms;
        }

        public void DecrementRoom()
        {
            currentRoomIndex = (currentRoomIndex - 1 < 0 ? totalRooms - 1 : currentRoomIndex - 1) % totalRooms;
        }

        public void LoadLevel() {
            foreach(XElement element in spriteData.Root.Elements()) {
                totalRooms++;
                LoadRoom(element);
            }
        }

        private void LoadRoom(XElement root) {
            Room room = new Room();
            foreach (XElement element in root.Elements()) {
                string type = element.Element("type").Value;
                string name = element.Element("name").Value;
                XElement position_ratio = element.Element("position_ratio");
                int x = (int)(float.Parse(position_ratio.Element("x").Value) * Game1.SCREEN_WIDTH);
                int y = (int)(float.Parse(position_ratio.Element("y").Value) * Game1.SCREEN_HEIGHT);
                LoadObject(room, type, name, new Vector2(x, y));
            }
            rooms.Add(room);
        }

        private void LoadObject(Room room, string type, string name, Vector2 position) {
            switch(type) {
                case "Wall":
                    room.AddWall(new Wall(position, (Direction) Enum.Parse(typeof(Direction), name)));
                    break;
                case "Floor":
                    room.SetFloor(new Floor(position, int.Parse(name)));
                    break;
                case "Door":
                    Direction direction = (Direction) Enum.Parse(typeof(Direction), name);
                    room.AddDoor(new Door(position, direction));
                    break;
                case "Player":
                    room.SetPlayer(new Player(position));
                    break;
                case "Enemy":
                    MakeEnemy(room, name, position);
                    break;
                case "Block":
                    MakeBlock(room, name, position);
                    break;
                case "Item":
                    MakeItem(room, name, position);
                    break;
                default:
                    throw new System.Exception("Object type: \"" + name + "\" doesn't exist");
            }
        }

        private void MakeEnemy(Room room, string name, Vector2 position) {
            switch(name) {
                case "Aquamentus":
                    room.AddEnemy(new Aquamentus(position));
                    break;
                case "BlueBat":
                    room.AddEnemy(new BlueBat(position));
                    break;
                case "BlueGel":
                    room.AddEnemy(new BlueGel(position));
                    break;
                case "RedGloriya":
                    room.AddEnemy(new RedGloriya(position));
                    break;
                case "Stalfos":
                    room.AddEnemy(new Stalfos(position));
                    break;
            }
        }

        private void MakeBlock(Room room, string name, Vector2 position) {
            switch(name) {
                case "Diamond":
                    room.AddBlock(new DiamondBlock(position));
                    break;
                case "Black":
                    room.AddBlock(new BlackBlock(position));
                    break;
                case "Ladder":
                    room.AddBlock(new LadderBlock(position));
                    break;
                case "Plain":
                    room.AddBlock(new PlainBlock(position));
                    break;
                case "Pyramid":
                    room.AddBlock(new PyramidBlock(position));
                    break;
                case "Stair":
                    room.AddBlock(new StairBlock(position));
                    break;
                case "Stone":
                    room.AddBlock(new StoneBlock(position));
                    break;
            }
        }
        private void MakeItem(Room room, string name, Vector2 position) {
            switch(name) {
                case "BlueRuby":
                    room.AddItem(new BlueRuby(position));
                    break;
                case "Bomb":
                    room.AddItem(new Bomb(position));
                    break;
                case "FlashingRuby":
                    room.AddItem(new FlashingRuby(position));
                    break;
                case "Heart":
                    room.AddItem(new Heart(position));
                    break;
                case "Key":
                    room.AddItem(new Key(position));
                    break;
                case "Triforce":
                    room.AddItem(new Triforce(position));
                    break;
                case "YellowRuby":
                    room.AddItem(new YellowRuby(position));
                    break;
            }
        }
    }
}