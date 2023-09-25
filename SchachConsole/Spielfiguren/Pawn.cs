using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchachConsole.Figures
{
    public class Pawn : Figure
    {
        public Pawn(bool white) : base(white)
        {
        }

        public override char Letter => 'B';

        public override bool CanMove(Zug z, Figure[,] board)
        {
            if (!IsTargetFieldValid(z, board)) return false;

            Point mov = z.GetRelativeMovement();
            
            //Restrict movement to forwards only
            if (mov.X != 0)
            {
                return false;
            }
            if(IsWhite)
            {
                if (mov.Y < 0) return false;
            } else
            {
                if (mov.Y > 0) return false;
            }


            //If in starting position, allow to move two fields forward
            int startingYPos = IsWhite ? 6 : 1;
            if(mov.Y > 2)
            {
                return false;
            } else if(mov.Y > 1 && z.StartPos.
                
                Y != startingYPos)
            {
                return false;
            }

            return true;
        }
    }
}
