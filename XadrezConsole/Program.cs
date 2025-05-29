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

                while (!match.Finished)
                {
                    try
                    {
                        Console.Clear();
                        Screen.PrintChessBoard(match.Board);
                        Console.WriteLine("\nTurn: " + match.Turn);
                        Console.WriteLine("Waiting for play: " + match.Player);

                        Console.Write("\nOrigin: ");
                        Position origin = Screen.ReadChessPosition().ToPosition();
                        match.ValidateOriginPosition(origin);

                        bool[,] possiblePositions = match.Board.Piece(origin).PossibleMoves();

                        Console.Clear();
                        Screen.PrintChessBoard(match.Board, possiblePositions);



                        Console.Write("\nTarget: ");
                        Position target = Screen.ReadChessPosition().ToPosition();
                        match.ValidateTargetPosition(origin, target);

                        match.PeformMove(origin, target);
                    }
                    catch (ChessBoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
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