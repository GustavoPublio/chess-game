using System;
using ChessConsole.ChessBoard;

namespace ChessConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ChessBoardClass Board = new ChessBoardClass(8, 8);
            Screen.PrintChessBoard(Board);

            Console.ReadLine();
        }
    }
}