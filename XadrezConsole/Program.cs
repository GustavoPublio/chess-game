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
                ChessMatch match = new ChessMatch();
               
                while(!match.Finished)
                {
                    Console.Clear();
                    Screen.PrintChessBoard(match.Board);

                    Console.Write("\nOrigin: ");
                    Position origin = Screen.ReadChessPosition().ToPosition();
                    Console.Write("Target: ");
                    Position target = Screen.ReadChessPosition().ToPosition();
                    match.MakeMove(origin, target);
                }

                Screen.PrintChessBoard(match.Board);
            }
            catch (ChessBoardException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}