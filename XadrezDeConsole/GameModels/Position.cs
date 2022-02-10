﻿using System;
using System.Collections.Generic;
using System.Text;

namespace XadrezDeConsole.GameModels
{
    public class Position
    {
        public int Line { get; set; }
        public int Column { get; set; }

        public Position(int line, int column)
        {
            this.Line = line;
            this.Column = column;
        }

        public override string ToString()
        {
            return $"{Line},{Column}";
        }
    }
}
