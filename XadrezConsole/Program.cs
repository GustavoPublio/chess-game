using System;
using Chess;
using ChessBoard;
using ChessConsole.ChessBoard;

namespace ChessConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessBoardClass Board = new ChessBoardClass(8, 8);
                Board.PlacePiece(new Rook(Board, Color.Black), new Position(0, 0));
                Board.PlacePiece(new Rook(Board, Color.Black), new Position(1, 3));
                Board.PlacePiece(new King(Board, Color.Black), new Position(0, 2));

                Board.PlacePiece(new Rook(Board, Color.White), new Position(3, 5));
                Screen.PrintChessBoard(Board);
            }
            catch (ChessBoardException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}