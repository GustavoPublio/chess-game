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
            if(ChessBoard.IsValidPosition(position) && CanMove(position))
            {
                mat[position.Rank, position.File] = true;
            }

            position.SetValues(Position.Rank - 1, Position.File + 1);
            if (ChessBoard.IsValidPosition(position) && CanMove(position))
            {
                mat[position.Rank, position.File] = true;
            }

            position.SetValues(Position.Rank, Position.File + 1);
            if (ChessBoard.IsValidPosition(position) && CanMove(position))
            {
                mat[position.Rank, position.File] = true;
            }

            position.SetValues(Position.Rank + 1, Position.File + 1);
            if (ChessBoard.IsValidPosition(position) && CanMove(position))
            {
                mat[position.Rank, position.File] = true;
            }

            position.SetValues(Position.Rank + 1, Position.File);
            if (ChessBoard.IsValidPosition(position) && CanMove(position))
            {
                mat[position.Rank, position.File] = true;
            }

            position.SetValues(Position.Rank + 1, Position.File - 1);
            if (ChessBoard.IsValidPosition(position) && CanMove(position))
            {
                mat[position.Rank, position.File] = true;
            }

            position.SetValues(Position.Rank, Position.File - 1);
            if (ChessBoard.IsValidPosition(position) && CanMove(position))
            {
                mat[position.Rank, position.File] = true;
            }

            position.SetValues(Position.Rank - 1, Position.File - 1);
            if (ChessBoard.IsValidPosition(position) && CanMove(position))
            {
                mat[position.Rank, position.File] = true;
            }

            return mat;
        }
    }
}
