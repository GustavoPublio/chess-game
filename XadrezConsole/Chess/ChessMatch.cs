using System;
using System.Reflection.PortableExecutable;
using ChessConsole.ChessBoard;

namespace Chess
{
    class ChessMatch
    {
        public ChessBoardClass Board { get; private set; }
        private int _turn;
        private Color _player;
        public bool Finished { get; private set; }

        public ChessMatch()
        {
            Board = new ChessBoardClass(8, 8);
            _turn = 1;
            _player = Color.White;
            Finished = false;
            PlacePieces();
        }

        public void MakeMove(Position origin, Position target) {
            Piece p = Board.RemovePiece(origin);
            p.IncrementMoveCount();
            Piece capturedPiece = Board.RemovePiece(target);
            Board.PlacePiece(p, target);
        }

        private void PlacePieces()
        {
            Board.PlacePiece(new Rook(Board, Color.White), new ChessPosition('c', 1).ToPosition());
            Board.PlacePiece(new Rook(Board, Color.White), new ChessPosition('c', 2).ToPosition());
            Board.PlacePiece(new Rook(Board, Color.White), new ChessPosition('d', 2).ToPosition());
            Board.PlacePiece(new Rook(Board, Color.White), new ChessPosition('e', 2).ToPosition());
            Board.PlacePiece(new Rook(Board, Color.White), new ChessPosition('e', 1).ToPosition());
            Board.PlacePiece(new King(Board, Color.White), new ChessPosition('d', 1).ToPosition());

            Board.PlacePiece(new Rook(Board, Color.Black), new ChessPosition('c', 7).ToPosition());
            Board.PlacePiece(new Rook(Board, Color.Black), new ChessPosition('c', 8).ToPosition());
            Board.PlacePiece(new Rook(Board, Color.Black), new ChessPosition('d', 7).ToPosition());
            Board.PlacePiece(new Rook(Board, Color.Black), new ChessPosition('e', 7).ToPosition());
            Board.PlacePiece(new Rook(Board, Color.Black), new ChessPosition('e', 8).ToPosition());
            Board.PlacePiece(new King(Board, Color.Black), new ChessPosition('d', 8).ToPosition());


        }
    }
}
