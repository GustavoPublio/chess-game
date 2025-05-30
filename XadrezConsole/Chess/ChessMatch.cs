using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using ChessBoard;
using ChessConsole.Chess;
using ChessConsole.ChessBoard;

namespace Chess
{
    class ChessMatch
    {
        public ChessBoardClass Board { get; private set; }
        public int Turn { get; private set; }
        public Color Player { get; private set; }
        public bool Finished { get; private set; }
        private HashSet<Piece> Pieces;
        private HashSet<Piece> Captured;
        public bool Check { get; private set; }

        public ChessMatch()
        {
            Board = new ChessBoardClass(8, 8);
            Turn = 1;
            Player = Color.White;
            Finished = false;
            Check = false;
            Pieces = new HashSet<Piece>();
            Captured = new HashSet<Piece>();
            PlacePieces();
        }

        public Piece MakeMove(Position origin, Position target) {
            Piece p = Board.RemovePiece(origin);
            p.IncrementMoveCount();
            Piece capturedPiece = Board.RemovePiece(target);
            Board.PlacePiece(p, target);
            if(capturedPiece != null)
            {
                Captured.Add(capturedPiece);
            }

            if (p is King && target.File == origin.File + 2) 
            {
                Position originRook = new Position(origin.Rank, origin.File + 3);
                Position targetRook = new Position(origin.Rank, origin.File + 1);
                Piece R = Board.RemovePiece(originRook);
                R.IncrementMoveCount();
                Board.PlacePiece(R, targetRook);    
            }


            if (p is King && target.File == origin.File - 2) 
            {
                Position originRook = new Position(origin.Rank, origin.File - 4);
                Position targetRook = new Position(origin.Rank, origin.File - 1);
                Piece R = Board.RemovePiece(originRook);
                R.IncrementMoveCount();
                Board.PlacePiece(R, targetRook);
            }


            return capturedPiece;
        }

        public void UndoMove(Position origin, Position target, Piece capturedPiece)
        {
            Piece p = Board.RemovePiece(target);
            p.DecrementMoveCount();
            if(capturedPiece != null)
            {
                Board.PlacePiece(capturedPiece, target);
                Captured.Remove(capturedPiece);
            }
            Board.PlacePiece(p, origin);

            if (p is King && target.File == origin.File + 2) 
            {
                Position originRook = new Position(origin.Rank, origin.File + 3);
                Position targetRook = new Position(origin.Rank, origin.File + 1);
                Piece R = Board.RemovePiece(targetRook);
                R.DecrementMoveCount();
                Board.PlacePiece(R, originRook);
            }

            if (p is King && target.File == origin.File - 2) 
            {
                Position originRook = new Position(origin.Rank, origin.File - 4);
                Position targetRook = new Position(origin.Rank, origin.File - 1);
                Piece R = Board.RemovePiece(targetRook);
                R.DecrementMoveCount();
                Board.PlacePiece(R, originRook);
            }
        }

        public void PerformMove(Position origin, Position target)
        {
            Piece capturedPiece = MakeMove(origin, target);

            if (IsInCheck(Player))
            {
                UndoMove(origin, target, capturedPiece);
                throw new ChessBoardException("You cannot put yourself in check!");
            }

            if (IsInCheck(Opponent(Player)))
            {
                Check = true;
            } 
            else
            {
                Check = false;
            }

            if (CheckMate(Opponent(Player)))
            {
                Finished = true;
            }
            else
            {
                Turn++;
                SwitchPlayer();
            }
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
                if(p.Color == color)
                {
                    aux.Add(p);
                }
            }
            return aux;
        }

        public HashSet<Piece> PiecesInPlay(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece p in Pieces)
            {
                if (p.Color == color)
                {
                    aux.Add(p);
                }
            }
            aux.ExceptWith(CapturedPieces(color));
            return aux;
        }

        private Color Opponent(Color color)
        {
            return (color == Color.White) ? Color.Black : Color.White;
        }

        private Piece King(Color color)
        {
            foreach(Piece p in PiecesInPlay(color))
            {
                if(p is King)
                {
                    return p;
                }
            }
            return null;
        }

        public bool IsInCheck(Color color)
        {
            Piece K = King(color);
            if (K == null)
            {
                throw new ChessBoardException("There is no " + color + " king on the board");
            }

            foreach (Piece p in PiecesInPlay(Opponent(color)))
            {
                bool[,] mat = p.PossibleMoves();
                if (mat != null && mat[K.Position.Rank, K.Position.File])
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckMate(Color color)
        {
            if (!IsInCheck(color))
            {
                return false;
            }
            foreach(Piece p in PiecesInPlay(color))
            {
                bool[,] mat = p.PossibleMoves();
                for(int i = 0; i < Board.Rank; i++)
                {
                    for(int j = 0; j < Board.File; j++)
                    {
                        if (mat[i, j])
                        {
                            Position origin = p.Position;
                            Position target = new Position(i, j);
                            Piece capturedPiece = MakeMove(origin, target);
                            bool testCheck = IsInCheck(color);
                            UndoMove(origin, target, capturedPiece);
                            if(!testCheck)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
        
        public void PlaceNewPiece(char file, int rank, Piece piece)
        {
            Board.PlacePiece(piece, new ChessPosition(file, rank).ToPosition());
            Pieces.Add(piece);
        }

        private void PlacePieces()
        {
            PlaceNewPiece('a', 1, new Rook(Board, Color.White));
            PlaceNewPiece('b', 1, new Knight(Board, Color.White));
            PlaceNewPiece('c', 1, new Bishop(Board, Color.White));
            PlaceNewPiece('d', 1, new Queen(Board, Color.White));
            PlaceNewPiece('e', 1, new King(Board, Color.White , this));
            PlaceNewPiece('f', 1, new Bishop(Board, Color.White));
            PlaceNewPiece('g', 1, new Knight(Board, Color.White));
            PlaceNewPiece('h', 1, new Rook(Board, Color.White));
            PlaceNewPiece('a', 2, new Pawn(Board, Color.White));
            PlaceNewPiece('b', 2, new Pawn(Board, Color.White));
            PlaceNewPiece('c', 2, new Pawn(Board, Color.White));
            PlaceNewPiece('d', 2, new Pawn(Board, Color.White));
            PlaceNewPiece('e', 2, new Pawn(Board, Color.White));
            PlaceNewPiece('f', 2, new Pawn(Board, Color.White));
            PlaceNewPiece('g', 2, new Pawn(Board, Color.White));
            PlaceNewPiece('h', 2, new Pawn(Board, Color.White));


            PlaceNewPiece('a', 8, new Rook(Board, Color.Black));
            PlaceNewPiece('b', 8, new Knight(Board, Color.Black));
            PlaceNewPiece('c', 8, new Bishop(Board, Color.Black));
            PlaceNewPiece('d', 8, new Queen(Board, Color.Black));
            PlaceNewPiece('e', 8, new King(Board, Color.Black, this));
            PlaceNewPiece('f', 8, new Bishop(Board, Color.Black));
            PlaceNewPiece('g', 8, new Knight(Board, Color.Black));
            PlaceNewPiece('h', 8, new Rook(Board, Color.Black));
            PlaceNewPiece('a', 7, new Pawn(Board, Color.Black));
            PlaceNewPiece('b', 7, new Pawn(Board, Color.Black));
            PlaceNewPiece('c', 7, new Pawn(Board, Color.Black));
            PlaceNewPiece('d', 7, new Pawn(Board, Color.Black));
            PlaceNewPiece('e', 7, new Pawn(Board, Color.Black));
            PlaceNewPiece('f', 7, new Pawn(Board, Color.Black));
            PlaceNewPiece('g', 7, new Pawn(Board, Color.Black));
            PlaceNewPiece('h', 7, new Pawn(Board, Color.Black));


        }
    }
}
