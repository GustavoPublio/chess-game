

namespace ChessConsole.ChessBoard
{
    class ChessBoardClass
    {
        public int Rank { get; set; }
        public int File { get; set; }
        private Piece[,] _pieces;

        public ChessBoardClass(int rank, int file)
        {
            Rank = rank;
            File = file;
            _pieces = new Piece[Rank, File];
        }

        public Piece Piece(int Rank, int File)
        {
            return _pieces[Rank, File];
        }

        public void PlacePiece(Piece p, Position position)
        {
            _pieces[position.Rank, position.File] = p;
            p.Position = position;
        }
    }
}
