using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchachConsole.Figures
{
    public class Knight : Figure
    {
        public Knight(bool white) : base(white)
        {
        }

        public override char Letter => 'S';

        public override bool CanMove(Zug z, Figure[,] board)
        {
            if (!IsTargetFieldValid(z, board)) return false;

            Point mov = z.GetRelativeMovement();

            //Restrict movement around corner of L shape (2 forward, then 1 left and 1 right)
            //Ignore sign, since movement is symmetrical anyway
            mov.X = Math.Abs(mov.X);
            mov.Y = Math.Abs(mov.Y);
            if ( !(mov.X == 1 && mov.Y == 2 ||
                   mov.X == 2 && mov.Y == 1) )
            {
                return false;
            }

            return true;
        }
    }
}
