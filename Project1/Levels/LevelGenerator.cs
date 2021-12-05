using System;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Project1.Enemy;
using Project1.Objects;
using Project1.NPC;
using System.Collections.ObjectModel;
using System.Xml;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Project1.Interfaces;
using Project1.Levels;
using Project1.Maze;

namespace Project1.Levels
{
    public class LevelGenerator
    {

        private Room[][] roomMatrix;
        public LevelGenerator() {

        }

        public void generateRooms() {
            GridGraph<Maze.Direction> directionGridGraph = MazeGenerator.Instance.BuildMaze(3);
            DirectionDictionaryMaze dictionaryMaze = new DirectionDictionaryMaze(directionGridGraph);
            // dictionary in which you pass in matrix position and returns which doors exist
            Dictionary<Maze.Direction, bool>[,] doorExists = dictionaryMaze.Dictionarify();
            for (int i = 0; i < dictionaryMaze.rows; i++)
            {
                for (int j = 0; j < dictionaryMaze.columns; j++)
                {
                    foreach (var value in doorExists[i, j])
                    {
                        Console.WriteLine($"{i} {j} {value}");
                    }
                }
            }
        }
    }
}