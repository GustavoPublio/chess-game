using ChessConsole.ChessBoard;

namespace Chess
{
    class King : Piece
    {
        public King(ChessBoardClass chessBoard, Color color) : base(chessBoard, color) 
        {

        }

        public override string ToString()
        {
            return "K";
        }
    }
}
