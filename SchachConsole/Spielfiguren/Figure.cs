using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchachConsole.Figures
{
    public abstract class Figure
    {
        public bool IsWhite { get; set; } = true;
        public abstract char Letter { get; }

        public override string ToString()
        {
            return $"{(IsWhite ? "w" : "s")} {Letter}";
        }

        public Figure(bool white)
        {
            IsWhite = white;
        }

        public bool IsTargetFieldValid(Zug z, Figure[,] board)
        {
            Figure targetFieldFigure = board[z.EndPos.X, z.EndPos.Y];

            //If target field figure has the same color as this figure (that should be moved), it is an invalid target
            if (targetFieldFigure != null &&
                targetFieldFigure.IsWhite == this.IsWhite)
            {
                return false;
            };

            return true;
        }

        //https://elzr.com/blag/img/2018/chess-pieces/chess-moves.png
        public abstract bool CanMove(Zug z, Figure[,] board);
    }
}
