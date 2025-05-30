using ChessConsole.ChessBoard;

namespace Chess
{
    class King : Piece
    {
        private ChessMatch _match;
        public King(ChessBoardClass chessBoard, Color color, ChessMatch match) : base(chessBoard, color)
        {
            _match = match;
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

        private bool TestRookForCastling(Position position)
        {
            Piece p = ChessBoard.Piece(position);
            return p != null && p is Rook && p.Color == Color && p.AmountMovements == 0;
        }
        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[ChessBoard.Rank, ChessBoard.File];


            Position position = new Position(0, 0);

            position.SetValues(Position.Rank - 1, Position.File);
            if (ChessBoard.IsValidPosition(position) && CanMove(position))
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

            // Special Move
            if (AmountMovements == 0 && !_match.Check)
            {
                Position positionRook = new Position(Position.Rank, Position.File + 3); 
                if (TestRookForCastling(positionRook))
                {
                    Position p1 = new Position(Position.Rank, Position.File + 1);
                    Position p2 = new Position(Position.Rank, Position.File + 2);
                    if (ChessBoard.Piece(p1) == null && ChessBoard.Piece(p2) == null)
                    {
                        mat[Position.Rank, Position.File + 2] = true;
                    }
                }

                Position positionRook2 = new Position(Position.Rank, Position.File - 4); 
                if (TestRookForCastling(positionRook2))
                {
                    Position p1 = new Position(Position.Rank, Position.File - 1);
                    Position p2 = new Position(Position.Rank, Position.File - 2);
                    Position p3 = new Position(Position.Rank, Position.File - 3);
                    if (ChessBoard.Piece(p1) == null && ChessBoard.Piece(p2) == null && ChessBoard.Piece(p3) == null)
                    {
                        mat[Position.Rank, Position.File - 2] = true;
                    }
                }
            }
            return mat;
        }
    }
}
