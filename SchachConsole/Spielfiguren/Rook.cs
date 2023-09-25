using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchachConsole.Figures
{
    public class Rook : Figure
    {
        public Rook(bool white) : base(white)
        {
        }

        public override char Letter => 'T';

        public override bool CanMove(Zug z, Figure[,] board)
        {
            if (!IsTargetFieldValid(z, board)) return false;

            Point mov = z.GetRelativeMovement();

            //Restrict movement to one axis - one must be 0
            if(mov.X != 0 && mov.Y != 0)
            {
                return false;
            }

            return true;
        }
    }
}
