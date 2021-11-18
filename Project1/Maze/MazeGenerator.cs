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

        public GridGraph<Direction> BuildMaze()
        {
            directionGridGraph = new CreateDirectionalMaze(10, 10).Build();
            return directionGridGraph;
        }
    }
}
