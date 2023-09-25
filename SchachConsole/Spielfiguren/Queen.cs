using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchachConsole.Figures
{
    public class Queen : Figure
    {
        public Queen(bool white) : base(white)
        {
        }

        public override char Letter => 'D';

        public override bool CanMove(Zug z, Figure[,] board)
        {
            if (!IsTargetFieldValid(z, board)) return false;

            Point mov = z.GetRelativeMovement();

            //Restrict to Diagonally + Axis (Bishop & Rook)
            mov.X = Math.Abs(mov.X);
            mov.Y = Math.Abs(mov.Y);
            if ( (mov.X != 0 && mov.Y != 0) ||
                  mov.X != mov.Y)
            {
                return false;
            }

            return true;
        }
    }
}
