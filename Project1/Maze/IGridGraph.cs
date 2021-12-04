using System.Collections.Generic;

namespace Project1.Maze
{
    // Specify the enumerable
    public interface IGridGraph<T> : IEnumerable<(int Row, int Column, T NodeValue)>
    {
        // query number of rows and columns
        int NumberOfRows { get; }
        int NumberOfColumns { get; }
        // get current cell value at a position (i,j)
        T GetCellValue(int row, int column);
    }
}
