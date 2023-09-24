using SchachConsole.Figures;
using System.Drawing;

namespace SchachConsole
{
    /// <summary>
    /// The Chessboard, containing the figures and deferring player input.
    /// Responsible for working with and drawing the chessboard.
    /// </summary>
    public class Chessboard
    {
        private ConsoleIO co;
        public Figure[,] board { get; set; }
        /// <summary>
        /// Determines whether the current turn is for the white player
        /// </summary>
        public bool isWhitesTurn { get; set; }

        public Chessboard()
        {
            co = new ConsoleIO();
            isWhitesTurn = true;
            InitBoard();
            DrawBoard();
        }

        /// <summary>
        /// Initializes the chessboard with the default arrangement of chess figures
        /// </summary>
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

        /// <summary>
        /// Draws the chessboard and figures to the console
        /// </summary>
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
        /// <summary>
        /// Process next player input and switches turns
        /// </summary>
        {
            co.PromptInput(isWhitesTurn);
            isWhitesTurn = !isWhitesTurn;
        }
    }
}
