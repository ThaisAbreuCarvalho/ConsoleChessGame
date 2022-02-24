using System;
using System.Collections.Generic;
using System.Text;
using XadrezDeConsole.Domain.Abstraction;

namespace XadrezDeConsole.Helpers
{
    public class ScreenPositon
    {
        public char Column { get; set; }
        public int Line { get; set; }

        public ScreenPositon(char column, int line)
        {
            this.Column = column;
            this.Line = line;
        }

        public override string ToString()
        {
            return "" + Column + Line;
        }

        public Position ToPosition(Board board)
        {
            return new Position(board.Lines - Line, Column - 'a');
        } 
    }
}
