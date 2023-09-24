using SchachConsole.Figures;
using System.Drawing;

namespace SchachConsole
{
    public class ConsoleIO

    {
        /// <summary>
        /// Size of the chessboard in characters excluding labelling
        /// </summary>
        private readonly Size consoleBoardSize = new Size(49, 33);
        /// <summary>
        /// Top-Left starting point of chessboard in characters excluding labelling
        /// </summary>
        private readonly Point consoleBoardStart = new Point(2, 1);
        /// <summary>
        /// Top-Left starting point of the first playing field for figures
        /// </summary>
        private readonly Point firstField = new Point(3, 2);

        public ConsoleIO()
        {
            //Fix console size so the drawing works correctly
            Console.SetWindowSize(consoleBoardSize.Width + 2, consoleBoardSize.Height + 6);
            Console.SetBufferSize(consoleBoardSize.Width + 20, consoleBoardSize.Height + 45);
        }

        /// <summary>
        /// Draw an empty chessboard, clearing the existing screen
        /// </summary>
        public void DrawEmptyBoard()
        {
            Console.Clear();

            // Write horizontal labels
            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = ConsoleColor.Gray; Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("     a     b     c     d     e     f     g     h   ");

            // Fill board with "0" (border) &
            // Write vertical labels
            for (int i = consoleBoardStart.Y; i <= consoleBoardSize.Height; i++)
            {
                Console.SetCursorPosition(0, i);

                string verticalLabel = " ";
                if ((i - 3) % 4 == 0)
                {
                    //    (i - 3) / 4  to get a number range 0 to 7
                    //8 -              to invert the number range to 8 to 1
                    verticalLabel = (8 - ((i - 3) / 4)).ToString();
                }

                Console.WriteLine($"{verticalLabel} " + new String('0', consoleBoardSize.Width));
            }

            // Fill board with checkerboard pattern
            bool white = true;
            SetConsoleColor(white: white);

            for (int y = firstField.Y; y < (consoleBoardSize.Height + 0); y += 4)
            {
                for (int x = firstField.X; x < (consoleBoardSize.Width + 2); x += 6)
                {
                    for (int offset = 0; offset < 3; offset++)
                    {
                        Console.SetCursorPosition(x, y + offset);
                        Console.Write("     ");
                    }

                    white = !white;
                    SetConsoleColor(white: white);
                }

                white = !white;
                SetConsoleColor(white: white);
            }


            Console.SetCursorPosition(0, consoleBoardStart.Y + consoleBoardSize.Height);
            SetConsoleColor(white: false);
            Console.WriteLine(new String(' ', consoleBoardSize.Width + 2));
        }

        /// <summary>
        /// Sets console fg and bg color more easily
        /// </summary>
        /// <param name="white">Determines whether the bg color is white (true) or black (false). Inverted for fg.</param>
        public void SetConsoleColor(bool white = true)
        {
            Console.BackgroundColor = white ? ConsoleColor.White : ConsoleColor.Black;
            Console.ForegroundColor = white ? ConsoleColor.Black : ConsoleColor.White;
        }

        /// <summary>
        /// Draws the prompt and processes player input
        /// </summary>
        /// <param name="promptForWhite">Determines whether to prompt for player white or black</param>
        /// <returns>Returns the given user input, already validated for correctness</returns>
        public Zug PromptInput(bool promptForWhite)
        {
            string input;
            Zug z;
            do
            {
                Console.SetCursorPosition(0, consoleBoardStart.Y + consoleBoardSize.Height + 2);
                SetConsoleColor(white: promptForWhite);
                if (promptForWhite)
                {
                    Console.WriteLine("WEISS: Geben Sie den nächsten Zug ein:"); //TODO: extract strings into lang file
                }
                else
                {
                    Console.WriteLine("SCHWARZ: Geben Sie den nächsten Zug ein:");
                }
                SetConsoleColor(white: !promptForWhite);

                Console.WriteLine("                                          ");
                Console.SetCursorPosition(0, consoleBoardStart.Y + consoleBoardSize.Height + 3);

                input = Console.ReadLine();
            } while (!Zug.TryParse(input, out z));

            return z;
        }

        /// <summary>
        /// Draw a figure to the chessboard
        /// </summary>
        /// <param name="figure">The figure object to draw</param>
        /// <param name="figureCoord">The coordinate (field index, not character index) to draw the figure to</param>
        public void DrawFigure(Figure figure, Point figureCoord)
        {
            //Text offset from field: x+2, y+2
            Point textCoord = new Point()
            {
                X = figureCoord.X * 6 + consoleBoardStart.X + 2,
                Y = figureCoord.Y * 4 + consoleBoardStart.Y + 2
            };

            string acronym = figure.GetAcronym();
            bool isWhite = figure.IsWhite;

            Console.SetCursorPosition(textCoord.X, textCoord.Y);
            SetConsoleColor(white: isWhite);
            Console.Write(acronym);
        }
    }
}
