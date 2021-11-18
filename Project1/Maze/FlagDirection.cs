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
            // Dead Ends
            public static readonly List<Direction> DeadEnds = new List<Direction>()
                {Direction.North, Direction.East, Direction.South, Direction.West};

            // Turns
            public static readonly List<Direction> Turns = new List<Direction>()
            {
                Direction.North | Direction.West, Direction.North | Direction.East, Direction.East | Direction.South,
                Direction.South | Direction.West
            };

            // CrossSection
            public static readonly Direction CrossSection =
                Direction.North | Direction.West | Direction.East | Direction.South;

            // Straights
            public static readonly List<Direction> Straights = new List<Direction>()
                {Direction.North | Direction.South, Direction.East | Direction.West};

            // TJunctions
            public static readonly List<Direction> TJunctions = new List<Direction>()
            {
                Direction.North | Direction.West | Direction.South,
                Direction.East | Direction.North | Direction.West,
                Direction.South | Direction.East | Direction.North,
                Direction.West | Direction.South | Direction.East
            };

            // Direction checker
            public static bool IsCrossSection(this Direction direction) => direction == CrossSection;
            public static bool IsDeadEnd(this Direction direction) => DeadEnds.Contains(direction);
            public static bool IsStraight(this Direction direction) => Straights.Contains(direction);
            public static bool IsTurn(this Direction direction) => Turns.Contains(direction);
            public static bool IsTJunction(this Direction direction) => TJunctions.Contains(direction);
        }
}
