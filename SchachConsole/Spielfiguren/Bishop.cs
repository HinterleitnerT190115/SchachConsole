using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchachConsole.Figures
{
    public class Bishop : Figure
    {
        public Bishop(bool white) : base(white)
        {
        }

        public override char Letter => 'L';

        public override bool CanMove(Zug z, Figure[,] board)
        {
            if (!IsTargetFieldValid(z, board)) return false;

            Point mov = z.GetRelativeMovement();

            //Restrict movement diagonally - X and Y must be identical (ignoring sign)
            mov.X = Math.Abs(mov.X);
            mov.Y = Math.Abs(mov.Y);
            if (mov.X != mov.Y) return false;

            return true;
        }
    }
}
