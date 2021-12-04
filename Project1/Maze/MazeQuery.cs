using System.Collections.Generic;
using System.Linq;

namespace Project1.Maze
{
    public static class MazeQuery
    {
        // query is like a List of vector2 where each dead end grid value is stored
        public static IEnumerable<(int Row, int Column)> DeadEnds(this GridGraph<Direction> directionGridGraph)
        {
            var query = from grid in directionGridGraph
                        where grid.NodeValue.IsDeadEnd()
                        select (grid.Row, grid.Column);
            return query;
        }

        public static IEnumerable<(int Row, int Column)> TJunctions(this GridGraph<Direction> directionGridGraph)
        {
            var query = from grid in directionGridGraph
                        where grid.NodeValue.IsTJunction()
                        select (grid.Row, grid.Column);
            return query;
        }

        public static IEnumerable<(int Row, int Column)> Straights(this GridGraph<Direction> directionGridGraph)
        {
            var query = from grid in directionGridGraph
                        where grid.NodeValue.IsStraight()
                        select (grid.Row, grid.Column);
            return query;
        }

        public static IEnumerable<(int Row, int Column)> Turns(this GridGraph<Direction> directionGridGraph)
        {
            var query = from grid in directionGridGraph
                        where grid.NodeValue.IsTurn()
                        select (grid.Row, grid.Column);
            return query;
        }

        public static IEnumerable<(int Row, int Column)> CrossSections(this GridGraph<Direction> directionGridGraph)
        {
            var query = from grid in directionGridGraph
                        where grid.NodeValue.IsCrossSection()
                        select (grid.Row, grid.Column);
            return query;
        }
    }
}
