using System;
using XadrezDeConsole.GameModels;

namespace XadrezDeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);

            Screen.PrintBoard(board);
        }
    }
}
