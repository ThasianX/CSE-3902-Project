using System.Collections.Generic;

namespace Project1.Maze
{
    public class DirectionDictionaryMaze
    {
        private Dictionary<Direction, bool>[,] directionDict;
        private GridGraph<Direction> directionGridGraph;
        public int rows;
        public int columns;

        public DirectionDictionaryMaze(GridGraph<Direction> directionGridGraph)
        {
            this.directionGridGraph = directionGridGraph;
            this.rows = directionGridGraph.NumberOfRows;
            this.columns = directionGridGraph.NumberOfColumns;
            directionDict = new Dictionary<Direction, bool>[rows, columns];
        }

        public Dictionary<Direction, bool>[,] Dictionarify()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (directionGridGraph.GetCellValue(i, j).IsTJunction())
                    {
                        directionDict[i,j] = new Dictionary<Direction, bool>()
                        {
                            {Direction.East, true},
                            {Direction.West, true},
                            {Direction.North, true},
                            {Direction.South, true}
                        };
                    }
                    if (directionGridGraph.GetCellValue(i, j).IsStraight())
                    {
                        if (directionGridGraph.GetCellValue(i, j).HasFlag(Direction.North))
                        {
                            directionDict[i, j] = new Dictionary<Direction, bool>()
                            {
                                {Direction.East, false},
                                {Direction.West, false},
                                {Direction.North, true},
                                {Direction.South, true}
                            };
                        }else if (directionGridGraph.GetCellValue(i, j).HasFlag(Direction.East))
                        {
                            directionDict[i, j] = new Dictionary<Direction, bool>()
                            {
                                {Direction.East, true},
                                {Direction.West, true},
                                {Direction.North, false},
                                {Direction.South, false}
                            };
                        }
                    }

                    if (directionGridGraph.GetCellValue(i, j).IsTJunction())
                    {
                        if (directionGridGraph.GetCellValue(i, j).HasFlag(Direction.North) && directionGridGraph.GetCellValue(i, j).HasFlag(Direction.South) && directionGridGraph.GetCellValue(i, j).HasFlag(Direction.West))
                        {
                            directionDict[i, j] = new Dictionary<Direction, bool>()
                            {
                                {Direction.East, false},
                                {Direction.West, true},
                                {Direction.North, true},
                                {Direction.South, true}
                            };
                        }
                        else if (directionGridGraph.GetCellValue(i, j).HasFlag(Direction.North) && directionGridGraph.GetCellValue(i, j).HasFlag(Direction.East) && directionGridGraph.GetCellValue(i, j).HasFlag(Direction.West))
                        {
                            directionDict[i, j] = new Dictionary<Direction, bool>()
                            {
                                {Direction.East, true},
                                {Direction.West, true},
                                {Direction.North, true},
                                {Direction.South, false}
                            };
                        }
                        else if (directionGridGraph.GetCellValue(i, j).HasFlag(Direction.South) && directionGridGraph.GetCellValue(i, j).HasFlag(Direction.East) && directionGridGraph.GetCellValue(i, j).HasFlag(Direction.North))
                        {
                            directionDict[i, j] = new Dictionary<Direction, bool>()
                            {
                                {Direction.East, true},
                                {Direction.West, false},
                                {Direction.North, true},
                                {Direction.South, true}
                            };
                        }
                        else if (directionGridGraph.GetCellValue(i, j).HasFlag(Direction.South) && directionGridGraph.GetCellValue(i, j).HasFlag(Direction.East) && directionGridGraph.GetCellValue(i, j).HasFlag(Direction.West))
                        {
                            directionDict[i, j] = new Dictionary<Direction, bool>()
                            {
                                {Direction.East, true},
                                {Direction.West, true},
                                {Direction.North, false},
                                {Direction.South, true}
                            };
                        }
                    }

                    if (directionGridGraph.GetCellValue(i, j).IsTurn())
                    {
                        if (directionGridGraph.GetCellValue(i, j).HasFlag(Direction.North)  && directionGridGraph.GetCellValue(i, j).HasFlag(Direction.West))
                        {
                            directionDict[i, j] = new Dictionary<Direction, bool>()
                            {
                                {Direction.East, false},
                                {Direction.West, true},
                                {Direction.North, true},
                                {Direction.South, false}
                            };
                        }
                        else if (directionGridGraph.GetCellValue(i, j).HasFlag(Direction.North) && directionGridGraph.GetCellValue(i, j).HasFlag(Direction.East))
                        {
                            directionDict[i, j] = new Dictionary<Direction, bool>()
                            {
                                {Direction.East, true},
                                {Direction.West, false},
                                {Direction.North, true},
                                {Direction.South, false}
                            };
                        }
                        else if (directionGridGraph.GetCellValue(i, j).HasFlag(Direction.South) && directionGridGraph.GetCellValue(i, j).HasFlag(Direction.East))
                        {
                            directionDict[i, j] = new Dictionary<Direction, bool>()
                            {
                                {Direction.East, true},
                                {Direction.West, false},
                                {Direction.North, false},
                                {Direction.South, true}
                            };
                        }
                        else if (directionGridGraph.GetCellValue(i, j).HasFlag(Direction.South) && directionGridGraph.GetCellValue(i, j).HasFlag(Direction.West))
                        {
                            directionDict[i, j] = new Dictionary<Direction, bool>()
                            {
                                {Direction.East, false},
                                {Direction.West, true},
                                {Direction.North, false},
                                {Direction.South, true}
                            };
                        }
                    }

                    if (directionGridGraph.GetCellValue(i, j).IsDeadEnd())
                    {
                        if (directionGridGraph.GetCellValue(i, j).HasFlag(Direction.East))
                        {
                            directionDict[i, j] = new Dictionary<Direction, bool>()
                            {
                                {Direction.East, true},
                                {Direction.West, false},
                                {Direction.North, false},
                                {Direction.South, false}
                            };
                        }
                        else if (directionGridGraph.GetCellValue(i, j).HasFlag(Direction.South))
                        {
                            directionDict[i, j] = new Dictionary<Direction, bool>()
                            {
                                {Direction.East, false},
                                {Direction.West, false},
                                {Direction.North, false},
                                {Direction.South, true}
                            };
                        }
                    }
                }
            }

            return directionDict;
        }
    }
}
