using System;
using System.Collections.Generic;
using System.Text;
using XadrezDeConsole.Domain.Abstraction;
using XadrezDeConsole.Helpers.Enums;

namespace XadrezDeConsole.Domain.Entities
{
    public class Tour : Piece
    {
        public Tour(Board board, ColorEnum color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "T ";
        }
    }
}
