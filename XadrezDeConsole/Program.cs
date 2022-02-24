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
                Match match = new Match();
                Screen.PrintBoard(match.Board);
            }
            catch (GameException ex)
            {
                Console.WriteLine(ex.Message + ex.InnerException + ex.StackTrace);
            }
        }
    }
}
