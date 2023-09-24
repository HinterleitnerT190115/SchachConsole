using System.Drawing;

namespace SchachConsole
{
    /// <summary>
    /// Stores a move of a figure.
    /// Parses player input and validates moves possibility
    /// </summary>
    public class Zug
    {
        public static Chessboard Chessboard;
        private Point startPos, endPos;
        public Point StartPosition { get { return startPos; } }
        public Point EndPosition { get { return endPos; } }

        /// <summary>
        /// Converts a chessboard position string into an Point object
        /// </summary>
        /// <param name="s">The chessboard position to parse</param>
        /// <returns>The converted Point object</returns>
        private static Point PosToPoint(string s)
        {
            Point p = new Point();
            p.X = s[0] - 'a';
            p.Y = s[1] - '0';
            return p;
        }

        /// <summary>
        /// Converts a Point object to the chessboard position string
        /// </summary>
        /// <param name="p">The point object</param>
        /// <returns>The converted chessboard position string</returns>
        private static string PointToPos(Point p)
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
                z = null;
                return false;
            }

            string[] positions = input.Split('-');

            //Check whether input positions contains numbers within range and at correct positions
            {
                int posStart, posEnd;
                if (int.TryParse(positions[0][1].ToString(), out posStart) &&
                    int.TryParse(positions[1][1].ToString(), out posEnd))
                {
                    if (!(posStart >= 1 && posEnd <= 8 &&
                            posEnd >= 1 && posEnd <= 8))
                    {
                        z = null;
                        return false;
                    }
                }
                else
                {
                    z = null;
                    return false;
                }
            }

            //Check whether input positions contains letters within range and at correct positions
            if (!(positions[0][0] >= 'a' && positions[0][0] <= 'h' &&
                positions[1][0] >= 'a' && positions[1][0] <= 'h'))
            {
                z = null;
                return false;
            }

            z = new Zug();

            z.startPos = PosToPoint(positions[0]);
            z.endPos = PosToPoint(positions[0]);

            //TODO: Check whether move is valid (aka whether movement of piece is possible)
            //Since the method must be static and parameters cannot be changed,
            //a public static variable hold the reference to the chessboard
            Chessboard cb = Zug.Chessboard;

            return true;
        }
    }
}