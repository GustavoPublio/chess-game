
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

        private bool CanMove(Position position)
        {
            Piece p = ChessBoard.Piece(position);
            return p == null || p.Color != this.Color;
        }
        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[ChessBoard.Rank, ChessBoard.File]; 


            Position position = new Position(0, 0);

            position.SetValues(Position.Rank - 1, Position.File);
            while (ChessBoard.IsValidPosition(position) && CanMove(position))
            {
                mat[position.Rank, position.File] = true;
                if (ChessBoard.Piece(position) != null && ChessBoard.Piece(position).Color != this.Color)
                {
                    break;
                }
                position.Rank--;
            }

            position.SetValues(Position.Rank + 1, Position.File);
            while (ChessBoard.IsValidPosition(position) && CanMove(position))
            {
                mat[position.Rank, position.File] = true;
                if (ChessBoard.Piece(position) != null && ChessBoard.Piece(position).Color != this.Color)
                {
                    break;
                }
                position.Rank++;
            }

            position.SetValues(Position.Rank, Position.File + 1);
            while (ChessBoard.IsValidPosition(position) && CanMove(position))
            {
                mat[position.Rank, position.File] = true;
                if (ChessBoard.Piece(position) != null && ChessBoard.Piece(position).Color != this.Color)
                {
                    break;
                }
                position.File++;
            }

            position.SetValues(Position.Rank, Position.File - 1);
            while (ChessBoard.IsValidPosition(position) && CanMove(position))
            {
                mat[position.Rank, position.File] = true;
                if (ChessBoard.Piece(position) != null && ChessBoard.Piece(position).Color != this.Color)
                {
                    break;
                }
                position.File--;
            }


            return mat;
        }
    }
}
