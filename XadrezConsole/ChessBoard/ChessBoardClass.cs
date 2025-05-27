

namespace ChessConsole.ChessBoard
{
    class ChessBoardClass
    {
        public int Rank { get; set; }
        public int File { get; set; }
        private Piece[,] _pieces;

        public ChessBoardClass(int rank , int file)
        {
            Rank = rank;
            File = file;
            _pieces = new Piece[Rank, File];
        }
    }
}
