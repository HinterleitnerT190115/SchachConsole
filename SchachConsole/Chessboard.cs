using SchachConsole.Figures;
using System.Drawing;

namespace SchachConsole
{
    public class Chessboard
    {
        private ConsoleIO co;
        public Figure[,] board { get; set; }
        public bool isWhitesTurn { get; set; }

        public Chessboard()
        {
            co = new ConsoleIO();
            isWhitesTurn = true;
            InitBoard();
            DrawBoard();
        }

        public void InitBoard()
        {
            //https://www.chess-poster.com/english/notes_and_facts/chess_piece_names_in_other_languages.htm
            /*board = new Figure[8, 8] {
                { new Rook(), new Knight(), new Bishop(), new Queen(), new King(), new Bishop(), new Knight(), new Rook() },
                { new Pawn(), new Pawn()  , new Pawn()  , new Pawn() , new Pawn(), new Pawn()  , new Pawn()  , new Pawn() },
                {       null,         null,         null,        null,       null,         null,         null,       null },
                {       null,         null,         null,        null,       null,         null,         null,       null },
                {       null,         null,         null,        null,       null,         null,         null,       null },
                {       null,         null,         null,        null,       null,         null,         null,       null },
                { new Pawn(), new Pawn()  , new Pawn()  , new Pawn() , new Pawn(), new Pawn()  , new Pawn()  , new Pawn() },
                { new Rook(), new Knight(), new Bishop(), new Queen(), new King(), new Bishop(), new Knight(), new Rook() }
            };*/
            //Is rotated -90° because of array init
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
            co.DrawEmptyBoard();

            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    var figure = board[x, y];
                    if (figure == null) continue;

                    co.DrawFigure(figure, new Point(x,y));
                }
            }
        }

        internal void NextInput()
        {
            co.PromptInput(isWhitesTurn);
            isWhitesTurn = !isWhitesTurn;
        }
    }
}
