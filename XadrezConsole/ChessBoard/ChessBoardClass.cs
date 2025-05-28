

using ChessBoard;

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

        public Piece Piece(Position position)
        {
            return _pieces[position.Rank, position.File];
        }

        public bool IsThereAPiece(Position position)
        {
            ValidatePosition(position);
            return Piece(position) != null;
        }

        public void PlacePiece(Piece p, Position position)
        {
            if (IsThereAPiece(position)){
                throw new ChessBoardException("A piece already exists in this position");
            }
            _pieces[position.Rank, position.File] = p;
            p.Position = position;
        }

        public Piece RemovePiece(Position position)
        {
            if (Piece(position) == null)
            {
                return null;
            }
            Piece aux = Piece(position);
            aux.Position = null;
            _pieces[position.Rank, position.File] = null;
            return aux;
        }


        public bool IsValidPosition(Position position)
        {
            return (position.Rank < 0 || position.Rank >= Rank || position.File < 0 || position.File >= File) ? false : true;
        }

        public void ValidatePosition(Position position)
        {
            if (!IsValidPosition(position))
            {
                throw new ChessBoardException("Invalid position!");
            }
        }
    }
}
