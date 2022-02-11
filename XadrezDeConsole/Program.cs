using System;
using XadrezDeConsole.Domain.Abstraction;
using XadrezDeConsole.Domain.Entities;
using XadrezDeConsole.Helpers;
using XadrezDeConsole.Helpers.Enums;
using XadrezDeConsole.Helpers.GameException;

namespace XadrezDeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                Board board = new Board();

                board.InsertPiece(new Tour(board, ColorEnum.Yellow), new Position(0, 0));
                board.InsertPiece(new Tour(board, ColorEnum.Yellow), new Position(1, 3));
                board.InsertPiece(new King(board, ColorEnum.Red), new Position(2, 4));

                Screen.PrintBoard(board);
            }
            catch (GameException ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
