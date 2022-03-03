using System;
using XadrezDeConsole.Domain.Abstraction;

namespace XadrezDeConsole.Helpers
{
    public class Screen
    {
        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write(board.Columns - i + "  ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (board.Piece(i, j) == null)
                    {
                        Console.Write(" - ");
                    }

                    PrintPiece(board.Piece(i, j));
                    Console.Write(" ");
                }
                Console.WriteLine();
                Console.WriteLine();
            }

            Console.WriteLine("    a   b   c   d   e   f   g   h");
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece != null)
            {
                Console.ForegroundColor = (ConsoleColor)piece.Color;
            }

            Console.Write(piece);
            Console.ForegroundColor= ConsoleColor.Gray;
        }

        public static ScreenPositon ReadPosition()
        {
            var movement = Console.ReadLine();
            return new ScreenPositon(movement[0], Convert.ToInt32(movement[1].ToString()));
        }
    }
}
