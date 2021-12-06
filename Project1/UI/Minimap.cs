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

        int verticalSpacing = 8, horizontalSpacing = 16;

        private int currentX = 0, currentY = 0;

        private int rows = 4, columns = 4;

        public Minimap(Vector2 position)
        {
            Position = position;
            rooms = new MinimapRoom[rows, columns];
            
            for(int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Vector2 roomPos = Position + new Vector2(j * verticalSpacing, i * verticalSpacing);
                    rooms[i, j] = new MinimapRoom(roomPos, LevelManager.Instance.doorMatrix[i, j]);
                }
            }

        }

        public void UpdateDiscoveredRooms()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    
                }
            }
        }

        public void Draw(SpriteBatch sb)
        {
            foreach (MinimapRoom room in rooms)
            {
                room.Draw(sb);
            }
        }
    }
}
