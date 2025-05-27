using System;
using System.Threading.Channels;
using ChessConsole.ChessBoard;

namespace ChessConsole
{
    class Screen
    {
        public static void PrintChessBoard(ChessBoardClass ChessBoard)
        {
            for (int i = 0; i < ChessBoard.Rank; i++)
            {
                for (int j = 0; j < ChessBoard.File; j++)
                {
                    Console.Write(ChessBoard.Piece(i, j) == null ? "- " : ChessBoard.Piece(i, j) + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
