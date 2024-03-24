namespace GoL
{
    public class Settings
    {
        public const int maxRows = 40;
        public const int maxCols = 80;
        public const int renderDelay = 250;
        public static int[][] cells = new int[maxRows][];

        public static void SetConsoleSettings()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
        }
    }
}
