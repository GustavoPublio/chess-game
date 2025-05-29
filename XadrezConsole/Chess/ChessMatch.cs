using System;
using System.Reflection.PortableExecutable;
using ChessBoard;
using ChessConsole.ChessBoard;

namespace Chess
{
    class ChessMatch
    {
        public ChessBoardClass Board { get; private set; }
        public int Turn { get; private set; }
        public Color Player { get; private set; }
        public bool Finished { get; private set; }

        public ChessMatch()
        {
            Board = new ChessBoardClass(8, 8);
            Turn = 1;
            Player = Color.White;
            Finished = false;
            PlacePieces();
        }

        public void MakeMove(Position origin, Position target) {
            Piece p = Board.RemovePiece(origin);
            p.IncrementMoveCount();
            Piece capturedPiece = Board.RemovePiece(target);
            Board.PlacePiece(p, target);
        }

        public void PeformMove(Position origin, Position target)
        {
            MakeMove(origin, target);
            Turn++;
            SwitchPlayer();
        }

        public void ValidateOriginPosition(Position position)
        { 
            if(Board.Piece(position) == null)
            {
                throw new ChessBoardException("There is no piece at the chosen source position!");
            }
            if(Player != Board.Piece(position).Color)
            {
                throw new ChessBoardException("The chosen source piece is not yours!");
            }
            if(!Board.Piece(position).IsTherePossibleMoves())
            {
                throw new ChessBoardException("There are no possible moves for the chosen source piece");
            }
        }

        public void ValidateTargetPosition(Position origin, Position target)
        {
            if (!Board.Piece(origin).CanMoveTo(target)){
                throw new ChessBoardException("Invalid target position!");
            }
        }

        public void SwitchPlayer()
        {
            Player = (Player == Color.White) ? Color.Black : Color.White;
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
