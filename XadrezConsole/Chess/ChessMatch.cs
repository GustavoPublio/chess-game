using System.Collections.Generic;
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
        private HashSet<Piece> Pìeces;
        private HashSet<Piece> Captured;

        public ChessMatch()
        {
            Board = new ChessBoardClass(8, 8);
            Turn = 1;
            Player = Color.White;
            Finished = false;
            Pìeces = new HashSet<Piece>();
            Captured = new HashSet<Piece>();
            PlacePieces();
        }

        public void MakeMove(Position origin, Position target) {
            Piece p = Board.RemovePiece(origin);
            p.IncrementMoveCount();
            Piece capturedPiece = Board.RemovePiece(target);
            Board.PlacePiece(p, target);
            if(capturedPiece != null)
            {
                Captured.Add(capturedPiece);
            }

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

        public HashSet<Piece> CapturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach(Piece p in Captured)
            {
                if(p.Color == color)////
                {
                    aux.Add(p);
                }
            }
            return aux;
        }

        public HashSet<Piece> PiecesInPlay(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece p in Captured)
            {
                if (p.Color == color)
                {
                    aux.Add(p);
                }
            }
            aux.ExceptWith(CapturedPieces(color));/////
            return aux;
        }

        public void PlaceNewPiece(char file, int rank, Piece piece)
        {
            Board.PlacePiece(piece, new ChessPosition(file, rank).ToPosition());
            Pìeces.Add(piece);
        }

        private void PlacePieces()
        {
            PlaceNewPiece('c', 1, new Rook(Board, Color.White));
            PlaceNewPiece('c', 2, new Rook(Board, Color.White));
            PlaceNewPiece('d', 2, new Rook(Board, Color.White));
            PlaceNewPiece('e', 2, new Rook(Board, Color.White));
            PlaceNewPiece('e', 1, new Rook(Board, Color.White));
            PlaceNewPiece('d', 1, new King(Board, Color.White));

            PlaceNewPiece('c', 7, new Rook(Board, Color.Black));
            PlaceNewPiece('c', 8, new Rook(Board, Color.Black));
            PlaceNewPiece('d', 7, new Rook(Board, Color.Black));
            PlaceNewPiece('e', 7, new Rook(Board, Color.Black));
            PlaceNewPiece('e', 8, new Rook(Board, Color.Black));
            PlaceNewPiece('d', 8, new King(Board, Color.Black));


        }
    }
}
