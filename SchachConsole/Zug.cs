using System.Drawing;

namespace SchachConsole
{
    public class Zug
    {
        private Point startPos, endPos;
        public Point StartPosition { get { return startPos; } }
        public Point EndPosition { get { return startPos; } }

        private static Point PosToPoint(string s)
        {
            Point p = new Point();
            p.X = s[0] - 'a';
            p.Y = s[1] - '0';
            return p;
        }

        private static string PointToPos(Point p)
        {
            string s = "";
            s += p.X + 'a';
            s += p.Y;
            return s;
        }

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