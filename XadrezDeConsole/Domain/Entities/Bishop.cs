using System;
using System.Collections.Generic;
using System.Text;
using XadrezDeConsole.Domain.Abstraction;
using XadrezDeConsole.Helpers.Enums;

namespace XadrezDeConsole.Domain.Entities
{
    public class Bishop : Piece
    {
        public Bishop(Board board, Color color) : base(board, color)
        {
        }

        public override bool[,] PossibleMovements()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return " B ";
        }
    }
}
