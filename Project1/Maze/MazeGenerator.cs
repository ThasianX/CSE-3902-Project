using System.Collections.Generic;

namespace Project1.Maze
{
    public class MazeGenerator
    {
        private GridGraph<Direction> directionGridGraph;
        
        private static MazeGenerator instance = new MazeGenerator();

        public static MazeGenerator Instance
        {
            get
            {
                return instance;
            }
        }

        public GridGraph<Direction> BuildMaze(int num)
        {
            directionGridGraph = new CreateDirectionalMaze(num, num).Build();
            return directionGridGraph;
        }
    }
}
