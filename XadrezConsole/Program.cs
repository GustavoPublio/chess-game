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
            ChessPosition position = new ChessPosition('c', 7);
            Console.WriteLine(position);
            Console.WriteLine(position.ToPosition());
            Console.ReadLine();
        }
    }
}