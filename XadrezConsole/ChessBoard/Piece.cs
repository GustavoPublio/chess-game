namespace ChessConsole.ChessBoard
{

    class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int AmountMovements { get; protected set; }
        public ChessBoardClass ChessBoard { get; protected set; }

        public Piece(Position position, ChessBoardClass chessBoard, Color color)
        {
            Position = position;
            ChessBoard = chessBoard;
            Color = color;
            AmountMovements = 0;
        }
    }
}
