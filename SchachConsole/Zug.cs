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
        public Point StartPosition { get { return startPos; } }
        public Point EndPosition { get { return startPos; } }

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
            if (string.IsNullOrEmpty(input) ||
               input.Length != 5 ||
               !input.Contains('-'))
            {
                z = null;
                return false;
            }

            string[] positions = input.Split('-');
            //Try to parse int to check wether valid int.Parse(positions[0][1])

            z = new Zug();

            z.startPos = PosToPoint(positions[0]);
            z.endPos = PosToPoint(positions[0]);

            //TODO: Check whether move is valid (aka whether movement of piece is possible)
            //Somehow access the Chessboard, probably through public static variable since method is static and cant add parameter

            return true;
        }
    }
}