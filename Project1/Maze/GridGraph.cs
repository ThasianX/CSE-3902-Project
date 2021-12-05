using System;
using System.Collections;
using System.Collections.Generic;

namespace Project1.Maze
{
    public class GridGraph<T> : IGridGraph<T>
    {
        private readonly T[,] internalGrid;

        public int NumberOfRows { get; private set; }
        public int NumberOfColumns { get; private set; }

        public GridGraph(int numberOfRows, int numberOfColumns)
        {
            NumberOfRows = numberOfRows;
            NumberOfColumns = numberOfColumns;
            // each [i,j] in internalGrid eventually represent a bool value, indicate whether the cell is "occupied" or not 
            internalGrid = new T[NumberOfRows, NumberOfColumns];
        }

        public T GetCellValue(int row, int column)
        {
            return internalGrid[row, column];
        }

        public void SetCellValue(int row, int column, T dataValue)
        {
            internalGrid[row, column] = dataValue;
        }

        // IEnumerator now can return the grid direction
        public IEnumerator<(int Row, int Column, T NodeValue)> GetEnumerator()
        {
            for (int row = 0; row < NumberOfRows; row++)
            {
                for (int column = 0; column < NumberOfColumns; column++)
                {
                    T nodeValue = GetCellValue(row, column);
                    yield return (row, column, nodeValue);
                }
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

       
    }
}
