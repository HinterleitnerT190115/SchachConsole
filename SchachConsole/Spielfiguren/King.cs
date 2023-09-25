using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchachConsole.Figures
{
    public class King : Figure
    {
        public King(bool white) : base(white)
        {
        }

        public override char Letter => 'K';

        public override bool CanMove(Zug z, Figure[,] board)
        {
            if (!IsTargetFieldValid(z, board)) return false;

            Point mov = z.GetRelativeMovement();

            //Restrict movement to one field around the king
            if(mov.X < -1 || mov.X > 1 ||
               mov.Y < -1 || mov.Y > 1)
            {
                return false;
            }

            return true;
        }
    }
}