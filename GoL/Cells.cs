using static GoL.Settings;

namespace GoL
{
    public class Cells
    {
        public static void SetExamples()
        {
            cells[26][43] = 1;

            cells[25][45] = 1;
            cells[26][45] = 1;

            cells[22][47] = 1;
            cells[23][47] = 1;
            cells[24][47] = 1;

            cells[21][49] = 1;
            cells[22][49] = 1;
            cells[22][50] = 1;
            cells[23][49] = 1;
        }

        public static int[][] ResetCells(int[][] cells)
        {
            for (int i = 0; i < cells.Length; i++)
            {
                cells[i] = new int[maxCols];
                for (int j = 0; j < cells[i].Length; j++)
                {
                    cells[i][j] = 0;
                }
            }
            return cells;
        }

        public static int[][] CheckNeignborsOfCells(int[][] c)
        {
            int xNeignCell, yNeignCell;
            int[][] cellCopy = new int[maxRows][];
            int neignbors = 0;
            int[][] directions = [
                [-1, -1],
                [0, -1],
                [1, -1],
                [-1, 0],
                [1, 0],
                [-1, 1],
                [0, 1],
                [1, 1]
            ];

            for (int _x = 0; _x < c.Length; _x++)
            {
                cellCopy[_x] = new int[maxCols];
                for (int _y = 0; _y < c[_x].Length; _y++)
                {
                    cellCopy[_x][_y] = 0;
                    for (int di = 0; di < directions.Length; di++)
                    {
                        xNeignCell = _x + directions[di][0];
                        yNeignCell = _y + directions[di][1];
                        if ((xNeignCell >= 0 && yNeignCell >= 0) && (xNeignCell <= maxRows - 1 && yNeignCell <= maxCols - 1))
                        {
                            if (c[xNeignCell][yNeignCell] == 1)
                            {
                                neignbors++;
                            }
                        };
                    }

                    if (c[_x][_y] == 0 && neignbors == 3)
                    {
                        cellCopy[_x][_y] = 1;
                    }

                    if (c[_x][_y] == 1 && (neignbors == 2 || neignbors == 3))
                    {
                        cellCopy[_x][_y] = 1;
                    }

                    if (c[_x][_y] == 1 && (neignbors < 2 || neignbors > 3))
                    {
                        cellCopy[_x][_y] = 0;
                    }

                    neignbors = 0;
                }
            }

            return cellCopy;
        }
    }
}
