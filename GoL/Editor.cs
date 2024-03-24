using static GoL.Settings;
using static GoL.Menu;

namespace GoL
{

    public struct Coords ()
    {
        public int x { get; set; }
        public int y { get; set; }
    }

    public class Editor()
    {
        private int[][] cells = Settings.cells;
        private Coords cursorPosition = new Coords();

        public static void OpenEditor()
        {
            Editor editor = new Editor();
            DrawField(editor);
        }

        public static void DrawField(Editor editor)
        {
            string row;
            Console.Clear();
            for (int i = 0; i < editor.cells.Length; i++)
            {
                row = "";
                for (int j = 0; j < editor.cells[i].Length; j++)
                {
                    if (editor.cursorPosition.x == i && editor.cursorPosition.y == j)
                    {
                        if (editor.cells[i][j] == 1)
                        {
                            row += "O";
                        }
                        else
                        {
                            row += "X";
                        }
                    }
                    else
                    {
                        if (editor.cells[i][j] == 1)
                        {
                            row += "o";
                        }
                        else
                        {
                            row += ".";
                        }
                    }
                }
                Console.WriteLine(row);
            }
            CheckCursorMovement(editor);
        }

        public static void CheckCursorMovement(Editor editor)
        {
            bool positionChanged = false;
            do
            {
                while (!Console.KeyAvailable)
                {
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.LeftArrow:
                            if (editor.cursorPosition.y - 1 >= 0)
                            {
                                positionChanged = true;
                                editor.cursorPosition.y -= 1;
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (editor.cursorPosition.y + 1 <= maxCols)
                            {
                                positionChanged = true;
                                editor.cursorPosition.y += 1;
                            }
                            break;
                        case ConsoleKey.UpArrow:
                            if (editor.cursorPosition.x - 1 >= 0)
                            {
                                positionChanged = true;
                                editor.cursorPosition.x -= 1;
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            if (editor.cursorPosition.x + 1 <= maxRows)
                            {
                                positionChanged = true;
                                editor.cursorPosition.x += 1;
                            }
                            break;
                        case ConsoleKey.Spacebar:
                            positionChanged = true;
                            if (editor.cells[editor.cursorPosition.x][editor.cursorPosition.y] == 1)
                            {
                                editor.cells[editor.cursorPosition.x][editor.cursorPosition.y] = 0;
                            } else
                            {
                                editor.cells[editor.cursorPosition.x][editor.cursorPosition.y] = 1;
                            }
                            break;
                        case ConsoleKey.S:
                            Settings.cells = editor.cells;
                            RenderMenu();
                            break;
                    }
                    if (positionChanged) DrawField(editor);
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.S);
        }
    }
}
