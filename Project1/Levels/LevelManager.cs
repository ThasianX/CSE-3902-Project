using System;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Project1.Enemy;
using Project1.Objects;
using System.Collections.ObjectModel;
using System.Xml;

namespace Project1.Levels
{
    public class LevelManager
    {
        private int totalRooms;
        private int currentRoomIndex;
        private Collection<Room> rooms;
        private XDocument spriteData;

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
            totalRooms = 0;
            currentRoomIndex = 0;
            rooms = new Collection<Room>();
            //spriteData = XDocument.Load("Levels/LevelData/Level" + level + ".xml");
            spriteData = XDocument.Load("Levels/LevelData/Level1_NEW.xml");
        }

        public Room GetCurrentRoom()
        {
            return rooms[currentRoomIndex];
        }

        public void IncrementRoom()
        {
            GetCurrentRoom().Deactivate();
            // BAD SOLUTION! DO NOT LEAVE IN FOR SPRINT 4! =============================================
            IPlayer player = GameObjectManager.Instance.GetObjectsOfType<IPlayer>()[0];
            GetCurrentRoom().RemoveObject(player);
            // =========================================================================================

            currentRoomIndex = (currentRoomIndex + 1) % totalRooms;

            // =========================================================================================
            GetCurrentRoom().AddObject(player);
            // =========================================================================================
            GetCurrentRoom().Activate();
        }

        public void DecrementRoom()
        {
            GetCurrentRoom().Deactivate();

            // BAD SOLUTION! DO NOT LEAVE IN FOR SPRINT 4! =============================================
            IPlayer player = GameObjectManager.Instance.GetObjectsOfType<IPlayer>()[0];
            GetCurrentRoom().RemoveObject(player);
            // =========================================================================================

            currentRoomIndex = (currentRoomIndex - 1 < 0 ? totalRooms - 1 : currentRoomIndex - 1) % totalRooms;

            // =========================================================================================
            GetCurrentRoom().AddObject(player);
            // =========================================================================================
            GetCurrentRoom().Activate();
        }

        public void LoadLevel() {
            foreach(XElement element in spriteData.Root.Elements()) {
                totalRooms++;
                LoadRoom(element);
            }
            GetCurrentRoom().Activate();
        }

        private void LoadRoom(XElement root) {
            Room room = new Room();
            foreach (XElement element in root.Elements("object")) {
                string type = element.Element("type").Value;
                string name = element.Element("name").Value;
                XElement position = element.Element("position");
                /*
               int x = (int) MathF.Round(float.Parse(position_ratio.Element("x").Value) * 256);
               int y = (int) MathF.Round(float.Parse(position_ratio.Element("y").Value) * 176);*/
                float x = float.Parse(position.Element("x").Value) * Constants.TILE_SIZE;
                float y = float.Parse(position.Element("y").Value) * Constants.TILE_SIZE;

                System.Console.WriteLine(element.Element("type").Value + ": " + x + ", " + y);

                LoadObject(room, type, name, new Vector2(x, y));

                /*x = (int) MathF.Round(x / 16);
                y = (int) MathF.Round(y / 16);

                position_ratio.Element("x").Value = x.ToString();
                position_ratio.Element("y").Value = y.ToString();*/

            }
            //spriteData.Save("new_level_1_data.xml");

            rooms.Add(room);
        }

        private void LoadObject(Room room, string type, string name, Vector2 position) {
            switch(type) {
                case "Wall":
                    room.AddObject(new Wall(position, (Direction) Enum.Parse(typeof(Direction), name)));
                    break;
                case "Floor":
                    room.AddObject(new Floor(position, int.Parse(name)));
                    break;
                case "Door":
                    room.AddObject(new Door(position, (Direction) Enum.Parse(typeof(Direction), name)));
                    break;
                case "LockedDoor":
                    room.AddObject(new LockedDoor(position, (Direction)Enum.Parse(typeof(Direction), name)));
                    break;
                case "NoDoor":
                    room.AddObject(new NoDoor(position, (Direction)Enum.Parse(typeof(Direction), name)));
                    break;
                case "Hole":
                    room.AddObject(new Hole(position, (Direction)Enum.Parse(typeof(Direction), name)));
                    break;
                case "Player":
                    room.AddObject(new Player(position));
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
                    room.AddObject(new Aquamentus(position));
                    break;
                case "BlueBat":
                    room.AddObject(new BlueBat(position));
                    break;
                case "BlueGel":
                    room.AddObject(new BlueGel(position));
                    break;
                case "RedGloriya":
                    room.AddObject(new RedGloriya(position));
                    break;
                case "Stalfos":
                    room.AddObject(new Stalfos(position));
                    break;
            }
        }

        private void MakeBlock(Room room, string name, Vector2 position) {
            switch(name) {
                case "Diamond":
                    room.AddObject(new DiamondBlock(position));
                    break;
                case "Black":
                    room.AddObject(new BlackBlock(position));
                    break;
                case "Ladder":
                    room.AddObject(new LadderBlock(position));
                    break;
                case "Plain":
                    room.AddObject(new PlainBlock(position));
                    break;
                case "Pyramid":
                    room.AddObject(new PyramidBlock(position));
                    break;
                case "Stair":
                    room.AddObject(new StairBlock(position));
                    break;
                case "Stone":
                    room.AddObject(new StoneBlock(position));
                    break;
                case "LeftFacingStatue":
                    room.AddObject(new LeftFacingStatueBlock(position));
                    break;
                case "RightFacingStatue":
                    room.AddObject(new RightFacingStatueBlock(position));
                    break;
            }
        }
        private void MakeItem(Room room, string name, Vector2 position) {
            switch(name) {
                case "BlueRuby":
                    room.AddObject(new BlueRuby(position));
                    break;
                case "Bomb":
                    room.AddObject(new Bomb(position));
                    break;
                case "FlashingRuby":
                    room.AddObject(new FlashingRuby(position));
                    break;
                case "Heart":
                    room.AddObject(new Heart(position));
                    break;
                case "Key":
                    room.AddObject(new Key(position));
                    break;
                case "Triforce":
                    room.AddObject(new Triforce(position));
                    break;
                case "YellowRuby":
                    room.AddObject(new YellowRuby(position));
                    break;
            }
        }
    }
}