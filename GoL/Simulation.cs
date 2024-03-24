using static GoL.Cells;
using static GoL.Settings;
using static GoL.Menu;

namespace GoL
{
    public class Simulation
    {
        public static string? row;

        public static void StartSimulation()
        {
            Console.CursorVisible = false;
            do
            {
                while (!Console.KeyAvailable)
                {
                    Thread.Sleep(renderDelay);
                    Console.Clear();

                    cells = CheckNeignborsOfCells(cells);

                    for (int i = 0; i < cells.Length; i++)
                    {
                        row = "";
                        for (int j = 0; j < cells[i].Length; j++)
                        {
                            if (cells[i][j] == 0)
                            {
                                row += " ";
                            }
                            else
                            {
                                row += "o";
                            }
                        }
                        Console.WriteLine(row);
                    }
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            ResetCells(Settings.cells);
            RenderMenu();
        }

    }
}
