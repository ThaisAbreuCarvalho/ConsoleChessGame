using XadrezDeConsole.Domain.Abstraction;
using XadrezDeConsole.Domain.Entities;
using XadrezDeConsole.Helpers.Enums;

namespace XadrezDeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);

            board.InsertPiece(new Tour(board, ColorEnum.Branca), new Position(0, 0));
            board.InsertPiece(new Tour(board, ColorEnum.Branca), new Position(1, 3));
            board.InsertPiece(new King(board, ColorEnum.Branca), new Position(2,4));

            Screen.PrintBoard(board);
        }
    }
}
