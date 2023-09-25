﻿using SchachConsole.Figures;
using System.Drawing;

namespace SchachConsole
{
    /// <summary>
    /// The Chessboard, containing the figures and deferring player input.
    /// Responsible for working with and drawing the chessboard.
    /// </summary>
    public class Chessboard
    {
        public Figure[,] Board { get; set; }
        public bool IsWhitesTurn { get; set; }

        public Chessboard()
        {
            InitBoard();
            IsWhitesTurn = true;
            DrawBoard();
        }

        /// <summary>
        /// Initializes the chessboard with the default arrangement of chess figures
        /// </summary>
        public void InitBoard()
        {
            //Source for figure names: https://www.chess-poster.com/english/notes_and_facts/chess_piece_names_in_other_languages.htm
            //Is rotated -90° because of array init
            //TODO: Add color to figures constructors
            board = new Figure[8, 8] {
                {   new Rook(), new Pawn(), null, null, null, null, new Pawn(),   new Rook() },
                { new Knight(), new Pawn(), null, null, null, null, new Pawn(), new Knight() },
                { new Bishop(), new Pawn(), null, null, null, null, new Pawn(), new Bishop() },
                {  new Queen(), new Pawn(), null, null, null, null, new Pawn(),  new Queen() },
                {   new King(), new Pawn(), null, null, null, null, new Pawn(),   new King() },
                { new Bishop(), new Pawn(), null, null, null, null, new Pawn(), new Bishop() },
                { new Knight(), new Pawn(), null, null, null, null, new Pawn(), new Knight() },
                {   new Rook(), new Pawn(), null, null, null, null, new Pawn(),   new Rook() }
            };
        }

        public void DrawBoard()
        {
            ConsoleIO.DrawEmptyBoard();

            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    var figure = Board[x, y];
                    if (figure == null) continue;

                    ConsoleIO.DrawFigure(figure, new Point(x,y));
                }
            }
        }

        /// <summary>
        /// Process next player input and switches turns
        /// </summary>
        public void NextInput()
        {
            bool moveSuccessful = false;
            do {
                Zug z = ConsoleIO.PromptInput(IsWhitesTurn);
                Figure figureToMove = Board[z.StartPos.X, z.StartPos.Y];
                if(figureToMove == null) continue;

                if(figureToMove.IsWhite != IsWhitesTurn)
                {
                    ConsoleIO.DrawErrorMessage("Fehler: Gegnerische Spielfigur kann nicht bewegt werden!");
                }

                if (figureToMove.CanMove(z, Board))
                {
                    Board[z.EndPos.X, z.EndPos.Y] = figureToMove;
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    Board[z.StartPos.X, z.StartPos.Y] = null;
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
                    moveSuccessful = true;
                } else
                {
                    ConsoleIO.DrawErrorMessage("Fehler: Ungültiger Zug!");
                }
            } while (!moveSuccessful);

            IsWhitesTurn = !IsWhitesTurn;

            DrawBoard();
        }
    }
}
