using ChessConsole.ChessBoard;

namespace ChessConsole.Chess
{
    class Pawn : Piece
    {

        public Pawn(ChessBoardClass chessBoard, Color color) : base(chessBoard, color)
        {
        }

        public override string ToString()
        {
            return "P";
        }

        private bool HasEnemy(Position position)
        {
            Piece p = ChessBoard.Piece(position);
            return p != null && p.Color != this.Color;
        }

        private bool IsFree(Position position)
        {
            return ChessBoard.Piece(position) == null;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[ChessBoard.Rank, ChessBoard.File];


            Position position = new Position(0, 0);

            if (Color == Color.White)
            {
                position.SetValues(Position.Rank - 1, Position.File);
                if (ChessBoard.IsValidPosition(position) && IsFree(position))
                {
                    mat[position.Rank, position.File] = true;
                }

                position.SetValues(Position.Rank - 2, Position.File);
                if (ChessBoard.IsValidPosition(position) && IsFree(position) && AmountMovements == 0)
                {
                    mat[position.Rank, position.File] = true;
                }

                position.SetValues(Position.Rank - 1, Position.File - 1);
                if (ChessBoard.IsValidPosition(position) && HasEnemy(position))
                {
                    mat[position.Rank, position.File] = true;
                }

                position.SetValues(Position.Rank - 1, Position.File + 1);
                if (ChessBoard.IsValidPosition(position) && HasEnemy(position))
                {
                    mat[position.Rank, position.File] = true;
                }
            }
            else {
                position.SetValues(Position.Rank + 1, Position.File);
                if (ChessBoard.IsValidPosition(position) && IsFree(position))
                {
                    mat[position.Rank, position.File] = true;
                }

                position.SetValues(Position.Rank + 2, Position.File);
                if (ChessBoard.IsValidPosition(position) && IsFree(position) && AmountMovements == 0)
                {
                    mat[position.Rank, position.File] = true;
                }

                position.SetValues(Position.Rank + 1, Position.File - 1);
                if (ChessBoard.IsValidPosition(position) && HasEnemy(position))
                {
                    mat[position.Rank, position.File] = true;
                }

                position.SetValues(Position.Rank + 1, Position.File + 1);
                if (ChessBoard.IsValidPosition(position) && HasEnemy(position))
                {
                    mat[position.Rank, position.File] = true;
                }
            }

            return mat;
        }
    }
}
