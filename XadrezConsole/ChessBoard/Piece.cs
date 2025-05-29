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

        public void IncrementMoveCount()
        {
            AmountMovements++;
        }
    }
}
