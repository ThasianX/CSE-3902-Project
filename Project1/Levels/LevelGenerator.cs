using System;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Project1.Enemy;
using Project1.Objects;
using Project1.NPC;
using System.Collections.Generic;
using Project1.Maze;
using System.Linq;

namespace Project1.Levels
{
    public class LevelGenerator
    {
        public readonly List<Room> rooms;
        private readonly XDocument spriteData;
        
        public LevelGenerator(int level)
        {
            rooms = new List<Room>();
            spriteData = XDocument.Load("Levels/LevelData/Level" + level + ".xml");
        }

        private List<XElement> GetShuffledElements()
        {
            List<XElement> elements = spriteData.Root.Elements().ToList();
            elements.ShuffleAllExceptFirst();
            return elements;
        }

        public void LoadLevel() {
            List<XElement> elements = GetShuffledElements();

            GridGraph<Maze.Direction> directionGridGraph = MazeGenerator.Instance.BuildMaze(4);
            DirectionDictionaryMaze dictionaryMaze = new DirectionDictionaryMaze(directionGridGraph);
            Dictionary<Maze.Direction, bool>[,] doorExists = dictionaryMaze.Dictionarify();

            LevelManager.Instance.doorMatrix = doorExists; // Necessary Coupling: need to expose this for minimap

            for (int row = 0; row < dictionaryMaze.rows; row++)
            {
                for (int col = 0; col < dictionaryMaze.columns; col++)
                {
                    LoadRoom(row, col, elements[dictionaryMaze.columns * row + col], doorExists[row, col]);
                    Console.WriteLine("Room " + row + ", " + col);
                    foreach (KeyValuePair<Maze.Direction, bool> pair in doorExists[row, col])
                    {
                        Console.WriteLine(pair.Key + ": " + pair.Value);
                    }
                    
                }
            }
        }

        private void LoadRoom(int row, int col, XElement current, Dictionary<Maze.Direction, bool> doors)
        {
            Room room = new Room(GetRoomId(row, col));
            foreach (XElement element in current.Elements("object"))
            {
                string type = element.Element("type").Value;
                string name = element.Element("name").Value;
                XElement position = element.Element("position");

                float x = float.Parse(position.Element("x").Value) * Constants.TILE_SIZE;
                float y = float.Parse(position.Element("y").Value) * Constants.TILE_SIZE;

                LoadObject(room, type, name, new Vector2(x, y));
            }

            foreach (var key in doors.Keys)
            {
                if (doors[key])
                {
                    MakeDoor(room, key, GetNextRoomId(row, col, key));
                }
                else
                {
                    MakeDoor(room, key, -1);
                }
            }

            rooms.Add(room);
        }

        // Returns a unique id through an aribtrary calcalation
        private int GetRoomId(int row, int col)
        {
            return row * 10 + col * 3;
        }

        // Returns the room id for the next room in the given direction
        private int GetNextRoomId(int row, int col, Maze.Direction direction)
        {
            switch (direction)
            {
                case Maze.Direction.North:
                    {
                        return GetRoomId(row - 1, col);
                    }
                case Maze.Direction.East:
                    {
                        return GetRoomId(row, col + 1);
                    }
                case Maze.Direction.West:
                    {
                        return GetRoomId(row, col - 1);
                    }
                case Maze.Direction.South:
                    {
                        return GetRoomId(row + 1, col);
                    }
                default:
                    {
                        return GetRoomId(row, col);
                    }
            }
        }

        private void MakeDoor(Room room, Maze.Direction direction, int nextRoom)
        {
            Vector2 position;
            Direction d;
            switch(direction) {
                case Maze.Direction.North: {
                    position = new Vector2(7*Constants.TILE_SIZE, 0);
                    d = Direction.Up;
                    break;
                }
                case Maze.Direction.East: {
                    position = new Vector2(14 * Constants.TILE_SIZE, 4.5f * Constants.TILE_SIZE);
                    d = Direction.Right;
                    break;
                }
                case Maze.Direction.West: {
                    position = new Vector2(0, 4.5f*Constants.TILE_SIZE);
                    d = Direction.Left;
                    break;
                }
                case Maze.Direction.South: {
                    position = new Vector2(7 * Constants.TILE_SIZE, 9 * Constants.TILE_SIZE);
                    d = Direction.Down;
                    break;
                }
                default: {
                    position = new Vector2(0, 0);
                    d = Direction.Up;
                    break;
                }
            }

            if(nextRoom == -1)
            {
                room.AddObject(new NoDoor(position, d));
            } else
            {
                room.AddObject(new Door(position, d, nextRoom));
            }
        }

        private void LoadObject(Room room, string type, string name, Vector2 position) {
            switch(type) {
                case "Wall":
                    room.AddObject(new Wall(position, (Direction) Enum.Parse(typeof(Direction), name)));
                    break;
                case "Floor":
                    room.AddObject(new Floor(position, int.Parse(name)));
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
                case "OldMan":
                    room.AddObject(new OldMan(position));
                    break;
                case "WallMaster":
                    room.AddObject(new WallMaster(position));
                    break;
                case "Snake":
                    room.AddObject(new Snake(position));
                    break;
                case "Spike":
                    room.AddObject(new Spike(position));
                    break;
                case "Flame":
                    room.AddObject(new Flame(position));
                    break;
                case "Dodongo":
                    room.AddObject(new Dodongo(position));
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
                case "Water":
                    room.AddObject(new WaterBlock(position));
                    break;
                case "Half":
                    room.AddObject(new HalfBlock(position));
                    break;
                case "Sand":
                    room.AddObject(new SandBlock(position));
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
                case "Fairy":
                    room.AddObject(new Fairy(position));
                    break;
                case "Clock":
                    room.AddObject(new Clock(position));
                    break;
                case "Triforce":
                    room.AddObject(new Triforce(position));
                    break;
                case "YellowRuby":
                    room.AddObject(new YellowRuby(position));
                    break;
                case "Compass":
                    room.AddObject(new Compass(position));
                    break;
                case "Map":
                    room.AddObject(new Map(position));
                    break;
                case "Bow":
                    room.AddObject(new BowPickup(position));
                    break;
                case "Boomerang":
                    room.AddObject(new WoodBoomerangPickup(position));
                    break;
            }
        }
    }
}

static class ExtensionsClass
{
    private static Random rng = new Random();

    public static void ShuffleAllExceptFirst<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n) + 1;
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}