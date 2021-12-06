using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Project1.Levels;

namespace Project1.UI
{
    class Minimap
    {
        public Vector2 Position { get; set; }
        public MinimapRoom[,] rooms;

        int spacing = 8;

        private int currentX = 0, currentY = 0;

        private int rows = 4, columns = 4;

       ISprite marker = SpriteFactory.Instance.CreateSprite("minimap_marker");

        public Minimap(Vector2 position)
        {
            Position = position;

            SetMap();
        }

        public void SetMap()
        {
            rooms = new MinimapRoom[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Vector2 roomPos = Position + new Vector2(j * spacing, i * spacing);
                    rooms[i, j] = new MinimapRoom(roomPos, LevelManager.Instance.doorMatrix[i, j]);
                }
            }
        }

        public void SetMarker(int x, int y)
        {
            currentX = x;
            currentY = y;
        }

        public void MoveMarker(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    currentY--;
                    break;
                case Direction.Right:
                    currentX++;
                    break;
                case Direction.Down:
                    currentY++;
                    break;
                case Direction.Left:
                    currentX--;
                    break;
                default:
                    break;
            }
        }

        public void Draw(SpriteBatch sb)
        {
            foreach (MinimapRoom room in rooms)
            {
                room.Draw(sb);
            }

            marker.Draw(sb, Position + new Vector2(currentX * spacing, currentY * spacing));
        }
    }
}
