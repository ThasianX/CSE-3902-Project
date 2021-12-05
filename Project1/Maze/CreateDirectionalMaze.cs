using System;
using System.Collections.Generic;

namespace Project1.Maze
{
    public class CreateDirectionalMaze
    {
        private int rows;
        private int columns;

        private Direction currentDirection;
        private List<Direction> pathDirections = new List<Direction> { Direction.South, Direction.East };
        private Random rand = new Random();

        public CreateDirectionalMaze(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
        }

        public GridGraph<Direction> Build()
        {
            // x * x directional grid graph
            GridGraph<Direction> directionGridGraph = new GridGraph<Direction>(rows, columns);
            // set all grid direction to Blank
            InitializeDirectionMaze(directionGridGraph);
            // Binarized
            BinaryTreeMaze(directionGridGraph);
            return directionGridGraph;
        }


        // Initialize all grid to Blank
        private void InitializeDirectionMaze(GridGraph<Direction> directionGridGraph)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    directionGridGraph.SetCellValue(i,j,Direction.Blank);
                }
            }
        }

        private void BinaryTreeMaze(GridGraph<Direction> directionGridGraph)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    // Randomly choose a direction
                    int directionIndex = rand.Next(0, pathDirections.Count);
                    currentDirection = pathDirections[directionIndex];

                    // If current cell not in last row or right most column, then it could go South or East
                    // Check current cell's child
                    if (i < rows - 1 && j < columns - 1)
                    {
                        directionGridGraph.SetCellValue(i, j, currentDirection);
                    }
                    else if (i == rows - 1 && j != columns - 1) // If current cell is in last row, then it could only go east
                    {
                        currentDirection = Direction.East;
                        directionGridGraph.SetCellValue(i, j, currentDirection);
                    }
                    else if (i != rows - 1 && j == columns - 1) // If current cell is in right most column, then it could only go South
                    {
                        currentDirection = Direction.South;
                        directionGridGraph.SetCellValue(i, j, currentDirection);
                    }
                    else  // Note that when the cell at i == rows -1 & j == columns - 1 cannot choose direction
                    {
                        currentDirection = Direction.Blank;
                    }


                    // If current cell not in first row or left most column, then it will have a parent either North or West
                    // Check current cell's parent 

                    // Check not the first row
                    if (i > 0)
                    {
                        if (directionGridGraph.GetCellValue(i - 1, j).HasFlag(Direction.South))
                        {
                            currentDirection |= Direction.North;
                            directionGridGraph.SetCellValue(i, j, currentDirection);
                        }
                    }

                    // check not the left column
                    if (j > 0)
                    {
                        if (directionGridGraph.GetCellValue(i, j - 1).HasFlag(Direction.East))
                        {
                            currentDirection |= Direction.West;
                            directionGridGraph.SetCellValue(i, j, currentDirection);
                        }
                    }
                }
            }
        }
    }
}
