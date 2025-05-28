using System;
using Chess;
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
                Console.Write(8 - i + " ");
                for (int j = 0; j < ChessBoard.File; j++)
                {
                    if (ChessBoard.Piece(i, j) == null)
                    {
                        Console.Write("- ");
                    } else
                    {
                        PrintPiece(ChessBoard.Piece(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h ");
        }

        public static ChessPosition ReadChessPosition()
        {
            string s = Console.ReadLine();
            char File = s[0];
            int Rank = int.Parse(s[1] + "");
            return new ChessPosition(File, Rank);
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece.Color == Color.White)
            {
                Console.Write(piece);
            } else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.ForegroundColor = aux;
            }
        }
    }
}
