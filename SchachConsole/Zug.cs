using System.Drawing;

namespace SchachConsole
{
    /// <summary>
    /// Stores a move of a figure.
    /// Parses player input and validates moves possibility
    /// </summary>
    public class Zug
    {
        private Point startPos, endPos;
        public Point StartPos { get { return startPos; } }
        public Point EndPos { get { return endPos; } }

        /// <summary>
        /// Converts a chessboard position string into an Point object
        /// </summary>
        /// <param name="s">The chessboard position to parse</param>
        /// <returns>The converted Point object</returns>
        private static Point PosToPoint(string s)
        {
            Point p = new()
            {
                X = s[0] - 'a',
                Y = 8 - int.Parse(s[1].ToString())
            };
            return p;
        }

        {
            string s = "";
            s += p.X + 'a';
            s += p.Y;
            return s;
        }

        /// <summary>
        /// Parses and validates figure move from player input
        /// </summary>
        /// <param name="input">Player input describing a figure move</param>
        /// <param name="z">Output figure move as object (null if invalid)</param>
        /// <returns>True if parsed and validated successfully, false if failure</returns>
        public static bool TryParse(string input, out Zug z)
        {
            //Check whether input is in a valid format
            if (string.IsNullOrEmpty(input) ||
               input.Length != 5 ||
               !input.Contains('-'))
            {
                ConsoleIO.DrawErrorMessage("Fehler: Ungültiges Format vom Zug! (z.B. a2-a3)");
                z = null;
                return false;
            }

            string[] positions = input.Split('-');

            //Check whether input positions contains numbers within range and at correct positions
            {
                if (int.TryParse(positions[0][1].ToString(), out int posStart) &&
                    int.TryParse(positions[1][1].ToString(), out int posEnd))
                {
                    if (!(posStart >= 1 && posEnd <= 8 &&
                            posEnd >= 1 && posEnd <= 8))
                    {
                        ConsoleIO.DrawErrorMessage("Fehler: Zahl außerhalb des Bereichs 1 bis 8! (z.B. a2-a3)");
                        z = null;
                        return false;
                    }
                }
                else
                {
                    ConsoleIO.DrawErrorMessage("Fehler: Keine gültige Zahl im Zug! (z.B. a2-a3)");
                    z = null;
                    return false;
                }
            }

            //Check whether input positions contains letters within range and at correct positions
            if (!(positions[0][0] >= 'a' && positions[0][0] <= 'h' &&
                positions[1][0] >= 'a' && positions[1][0] <= 'h'))
            {
                ConsoleIO.DrawErrorMessage("Fehler: Kein gültiger Buchstabe im Zug! (z.B. a2-a3)");
                z = null;
                return false;
            }

            Zug tmp = new()
            {
                startPos = PosToPoint(positions[0]),
                endPos = PosToPoint(positions[1])
            };

            //Check whether start and end position is the same
            if(tmp.StartPos == tmp.EndPos)
            {
                ConsoleIO.DrawErrorMessage("Fehler: Start- und Endposition im Zug ist identisch!");
                z = null;
                return false;
            }
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

            z = tmp;
            return true;
        }
    }
}