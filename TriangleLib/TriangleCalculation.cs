using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace TriangleLib
{
    public class TriangleCalculation
    {
        private int cellHeight;
        private int cellWidth;
        private int columnCount;
        private int rowCount;

        private enum enumAlphaLabel
        { A = 0, B = 1, C = 2, D = 3, E = 4, F = 5, G = 6, H = 7, I = 8, J = 9, K = 10, L = 11, M = 12, N = 13,
            O = 14, P = 15, Q = 16, R = 17, S = 18, T = 19, U = 20, V = 21, W = 22, X = 23, Y = 24, Z = 25 };

        public TriangleCalculation()
        {
            columnCount = 12;
            rowCount = 6;
            cellWidth = 10;
            cellHeight = 10;
        }

        public TriangleCalculation(int totalColumns, int totalRows, int columnWidth, int rowHeight)
        {
            columnCount = totalColumns;
            rowCount = totalRows;
            cellWidth = columnWidth;
            cellHeight = rowHeight;
        }

        public OrderedDictionary GetTriangleCoordinates()
        {
            var results = new OrderedDictionary();

            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < columnCount; col++)
                {
                    // triangle name
                    var key = GetRowNameFromIndex(row) + (col + 1).ToString();
                    var coordinates = new List<Coordinate>();

                    var xList = GetXValues(col, row);
                    var yList = GetYValues(col, row);

                    // 3 coordinates per triangle
                    for (int i = 0; i < 3; i++)
                    {
                        var coord = new Coordinate { X = xList[i], Y = yList[i] };
                        coordinates.Add(coord);
                    }
                    results.Add(key, coordinates);
                }
            }

            return results;
        }

        public string GetTriangleName(List<int> xList, List<int> yList)
        {
            if (!CoordinatesAreValid(xList, yList))
                return "Invalid";

            var col = GetColumnName(xList);
            var row = GetRowName(yList);
            return row + col;
        }

        private List<int> GetYValues(int col, int row)
        {
            if (col % 2 == 0)
            {
                return new List<int> { row * cellHeight, row * cellHeight + cellHeight, row * cellHeight + cellHeight };
            }
            return new List<int> { row * cellHeight, row * cellHeight, row * cellHeight + cellHeight };
        }

        private List<int> GetXValues(int col, int row)
        {
            if (col % 2 == 0)
            {
                return new List<int> { col * cellWidth / 2, col * cellWidth / 2, col * cellWidth / 2 + cellWidth };
            }
            return new List<int> { (col - 1) * cellWidth / 2, (col - 1) * cellWidth / 2 + cellWidth, (col - 1) * cellWidth / 2 + cellWidth };
        }

        private bool CoordinatesAreValid(List<int> xList, List<int> yList)
        {
            var xMin = xList.Min();
            var xMax = xList.Max();
            var yMin = yList.Min();
            var yMax = yList.Max();

            // min/max span must be 10
            if ((xMax - xMin) != cellWidth)
                return false;
            if ((yMax - yMin) != cellHeight)
                return false;

            // numbers must be a multipule of 10
            if (xMax % cellWidth != 0)
                return false;
            if (yMax % cellHeight != 0)
                return false;

            // There must be 2 of one number and 1 of the other
            if (xList.Count(x => x == xMin) != 2 && xList.Count(x => x == xMax) != 2)
                return false;
            if (yList.Count(y => y == yMin) != 2 && yList.Count(y => y == yMax) != 2)
                return false;

            // check to see if 2 of the points are the same
            if (xList[0] == xList[1] && yList[0] == yList[1])
                return false;
            if (xList[0] == xList[2] && yList[0] == yList[2])
                return false;
            if (xList[1] == xList[2] && yList[1] == yList[2])
                return false;

            return true;
        }

        private string GetRowName(List<int> yList)
        {
            return GetRowNameFromIndex((yList.Min() / cellHeight));
            
        }

        private string GetColumnName(List<int> xList)
        {
            int col = xList.Min() / (cellWidth / 2);
            if (xList.Count(x => x == xList.Min()) == 2)
            {
                return (col + 1).ToString();
            }
            return (col + 2).ToString();
        }

        private string GetRowNameFromIndex(int index)
        {
            StringBuilder sb = new StringBuilder();
            GetMinRowLabel(index, sb);

            return sb.ToString();
        }

        // Recursive function to build the alpha row label when there are more than 26 rows
        private void GetMinRowLabel(int index, StringBuilder sb)
        {
            if (index < 26)
                sb.Append(Enum.GetName(typeof(enumAlphaLabel), index));
            else
            {
                GetMinRowLabel(index / 26 - 1, sb);

                int remainder = index % 26;
                if (remainder < 26)
                    sb.Append(Enum.GetName(typeof(enumAlphaLabel), remainder));
            }
        }
    }
}
