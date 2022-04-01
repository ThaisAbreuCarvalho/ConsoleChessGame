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
                    Screen.PrintBoard(match.Board, match);
                    Console.Write("Player " + EnumExtension.GetEnumDescription(match.CurrentPlayer) + " is your turn to move...");
                    Console.WriteLine();
                    Console.WriteLine("From: ");
                    Position origin = Screen.ReadPosition().ToPosition(match.Board);
                    match.ValidateOrigin(origin);
                    var possibleMovements = match.Board.Piece(origin).PossibleMovements();
                    Console.Clear();
                    Screen.PrintBoard(match.Board, possibleMovements);
                    Console.WriteLine("To: ");
                    Position destination = Screen.ReadPosition().ToPosition(match.Board);
                    match.Board.IsValidPosition(destination);
                    match.ExecuteMovement(origin, destination);
                }
            }
            catch (GameException ex)
            {
                Console.WriteLine(ex.Message + ex.InnerException + ex.StackTrace);
            }
        }
    }
}
