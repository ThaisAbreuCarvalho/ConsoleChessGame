using System;
using System.Collections.Generic;
using System.Text;

namespace XadrezDeConsole.GameModels
{
    public class Board
    {
        public int Lines { get; set; }
        public int Columns { get; set; }

        private Piece[,] Pieces;

        public Board(int lines, int columns)
        {
            this.Lines = lines;
            this.Columns = columns;
            this.Pieces = new Piece[lines, columns];
        }

        public Piece Piece(int line, int column)
        {
            return Pieces[line, column];
        }
    }
}
