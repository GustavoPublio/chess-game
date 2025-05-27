
using ChessConsole.ChessBoard;

namespace Chess
{
    class Rook : Piece
    {
        public Rook(ChessBoardClass chessBoard, Color color) : base(chessBoard, color)
        {
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
