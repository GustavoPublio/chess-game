using ChessConsole.ChessBoard;

namespace Chess
{
    class ChessPosition
    {
        public char File { get; set; }
        public int Rank { get; set; }

        public ChessPosition(char file, int rank)
        {
            File = file;
            Rank = rank;
        }

        public Position ToPosition()
        {
            return new Position(8 - Rank, File - 'a');
        }

        public override string ToString()
        {
            return "" + File + Rank;
        }
    }
}
