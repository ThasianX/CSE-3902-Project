using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.UI
{
    class MinimapRoom
    {
        public Vector2 Position { get; set; }

        private bool hidden = false;

        public List<ISprite> sprites;

        public MinimapRoom(Vector2 position, Dictionary<Maze.Direction, bool> doors)
        {
            Position = position;
            sprites = new List<ISprite>();

            SetDoors(doors);
        }

        public void SetDoors(Dictionary<Maze.Direction, bool> doors)
        {
            sprites.Clear();
            sprites.Add(SpriteFactory.Instance.CreateSprite("minimap_room"));

            Console.WriteLine("NEW ROOM:");
            foreach (KeyValuePair<Maze.Direction, bool> pair in doors)
            {
                if (pair.Value)
                {
                    switch (pair.Key)
                    {
                        case Maze.Direction.North:
                            Console.WriteLine("north");
                            sprites.Add(SpriteFactory.Instance.CreateSprite("minimap_door_up"));
                            break;
                        case Maze.Direction.East:
                            Console.WriteLine("east");
                            sprites.Add(SpriteFactory.Instance.CreateSprite("minimap_door_right"));
                            break;
                        case Maze.Direction.South:
                            Console.WriteLine("south");
                            sprites.Add(SpriteFactory.Instance.CreateSprite("minimap_door_down"));
                            break;
                        case Maze.Direction.West:
                            Console.WriteLine("west");
                            sprites.Add(SpriteFactory.Instance.CreateSprite("minimap_door_left"));
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public void Discover()
        {
            hidden = false;
        }

        public void Draw(SpriteBatch sb)
        {
            if (hidden)
                return;

            foreach (ISprite sprite in sprites)
            {
                sprite.Draw(sb, Position);
            }
        }
    }
}
