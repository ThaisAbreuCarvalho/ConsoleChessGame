using System;
using System.Collections.Generic;
using System.Text;
using XadrezDeConsole.Domain.Abstraction;
using XadrezDeConsole.Helpers.Enums;

namespace XadrezDeConsole.Domain.Entities
{
    public class King : Piece
    {
        public King(Board board, Color color) : base(board, color)
        {
        }

        public bool IsMovementValid(Position position)
        {
            var hasPiece = this.Board.Piece(position);

            if (hasPiece == null || hasPiece.Color != this.Color)
            {
                return true;
            }

            return false;
        }

        public override bool[,] PossibleMovements()
        {
            var response = new bool[this.Board.Lines, this.Board.Columns];

            for (int i = 0; i < this.Board.Lines; i++)
            {
                for (int j = 0; j < this.Board.Columns; j++)
                {
                    response[i, j] = IsMovementValid(new Position(i, j));
                }
            }

            return response;
        }

        public override string ToString()
        {
            return "K ";
        }
    }
}
