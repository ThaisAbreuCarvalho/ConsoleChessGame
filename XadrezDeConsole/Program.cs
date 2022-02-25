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

                while (!match.IsFinished)
                {
                    Console.Clear();
                    Screen.PrintBoard(match.Board);
                    Console.WriteLine("From: ");
                    Position origin = Screen.ReadPosition().ToPosition(match.Board);
                    Console.WriteLine("To: ");
                    Position destination = Screen.ReadPosition().ToPosition(match.Board);

                    match.MovePiece(origin, destination);
                }
            }
            catch (GameException ex)
            {
                Console.WriteLine(ex.Message + ex.InnerException + ex.StackTrace);
            }
        }
    }
}
