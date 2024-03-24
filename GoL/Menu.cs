using static GoL.Cells;
using static GoL.Simulation;
using static GoL.Editor;

namespace GoL
{
    public class Menu
    {
        public static void RenderMenu()
        {
            Console.Clear();
            Console.WriteLine("Select option:");
            Console.WriteLine("(1) Cells editor");
            Console.WriteLine("(2) Start saved simulation");
            Console.WriteLine("(3) Start example simulation");
            Console.WriteLine("(4) Exit");
            Console.WriteLine("------------------------------------");

            switch (Console.ReadLine())
            {
                case "1":
                    ResetCells(Settings.cells);
                    OpenEditor();
                    break;
                case "2":
                    StartSimulation();
                    break;
                case "3":
                    ResetCells(Settings.cells);
                    SetExamples();
                    StartSimulation();
                    break;
                case "4":
                    System.Environment.Exit(1);
                    break;
                default:
                    RenderMenu();
                    break;
            }
        }
    }
}
