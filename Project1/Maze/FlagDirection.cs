using System.Collections.Generic;

namespace Project1.Maze
{
    public enum Direction
        {
            Blank = 0,
            West = 1,
            East = 2,
            North = 4,
            South = 8
        };

    // All possible directions are defined and initialized
        public static class Directions
        {
            // Dead Ends, the cell with only 1 direction, like (1,1) South.
            // Note that (0,0) should not be count as DeadEnd because the algorithm only set 1 direction at begin
            public static readonly List<Direction> DeadEnds = new List<Direction>()
                {Direction.North, Direction.East, Direction.South, Direction.West};
            //N=4, E=2, S=8, W=1

            // Turns, the cell with 2 direction that form a right angle, ex: (1,1) North, West
            public static readonly List<Direction> Turns = new List<Direction>()
            {
                Direction.North | Direction.West, Direction.North | Direction.East, Direction.East | Direction.South,
                Direction.South | Direction.West
            };// NW=5, NE=6, ES=10, SW=9

            // CrossSection, the cell with all 4 direction (NWES = 15)
            public static readonly Direction CrossSection =
                Direction.North | Direction.West | Direction.East | Direction.South;

            // Straights, the cell that has direction N&&S or E&&W, basically a straight line
            public static readonly List<Direction> Straights = new List<Direction>()
                {Direction.North | Direction.South, Direction.East | Direction.West};
            //NS = 12, EW=3

            // TJunctions, the cell with 3 direction
            public static readonly List<Direction> TJunctions = new List<Direction>()
            {
                Direction.North | Direction.West | Direction.South,
                Direction.East | Direction.North | Direction.West,
                Direction.South | Direction.East | Direction.North,
                Direction.West | Direction.South | Direction.East
            };
            //NWS =13, ENW=7, SEN =14, WSE=11

            // Direction checker
            public static bool IsCrossSection(this Direction direction) => direction == CrossSection;
            public static bool IsDeadEnd(this Direction direction) => DeadEnds.Contains(direction);
            public static bool IsStraight(this Direction direction) => Straights.Contains(direction);
            public static bool IsTurn(this Direction direction) => Turns.Contains(direction);
            public static bool IsTJunction(this Direction direction) => TJunctions.Contains(direction);
        }
}
