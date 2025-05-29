namespace ChessConsole.ChessBoard
{

    abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int AmountMovements { get; protected set; }
        public ChessBoardClass ChessBoard { get; protected set; }

        public Piece(ChessBoardClass chessBoard, Color color)
        {
            Position = null;
            ChessBoard = chessBoard;
            Color = color;
            AmountMovements = 0;
        }

        public abstract bool[,] PossibleMoves();

        public bool IsTherePossibleMoves()
        {
            bool[,] mat = PossibleMoves();
            for (int i = 0; i < ChessBoard.Rank; i++)
            {
                for(int j = 0; j < ChessBoard.File; j++)
                {
                    if (mat[i,j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CanMoveTo(Position position)
        {
            return PossibleMoves()[position.Rank, position.File];
        }

        public void IncrementMoveCount()
        {
            AmountMovements++;
        }
    }
}
