using System;
using System.Collections.Generic;
using System.Text;
using XadrezDeConsole.Domain.Abstraction;
using XadrezDeConsole.Helpers.Enums;

namespace XadrezDeConsole.Domain.Entities
{
    public class Horse : Piece
    {
        public Horse(Board board, Color color) : base(board, color)
        {
        }

        public override bool[,] PossibleMovements()
        {
            var response = new bool[this.Board.Lines, this.Board.Columns];
            var currentPosition = this.Board.Piece(this.Position).Position;

            //top side
            var position = new Position(currentPosition.Line - 2, currentPosition.Column - 1);
            if (this.Board.IsValidPosition(position))
            {
                response[position.Line, position.Column] = true;
            }
            position.Column = currentPosition.Column + 1;
            if (this.Board.IsValidPosition(position))
            {
                response[position.Line, position.Column] = true;
            }

            //bottom side
            position = new Position(currentPosition.Line + 2, currentPosition.Column - 1);
            if (this.Board.IsValidPosition(position))
            {
                response[position.Line, position.Column] = true;
            }
            position.Column = currentPosition.Column + 1;
            if (this.Board.IsValidPosition(position))
            {
                response[position.Line, position.Column] = true;
            }

            //left side
            position = new Position(currentPosition.Line - 1, currentPosition.Column - 2);
            if (this.Board.IsValidPosition(position))
            {
                response[position.Line, position.Column] = true;
            }
            position.Column = currentPosition.Line + 1;
            if (this.Board.IsValidPosition(position))
            {
                response[position.Line, position.Column] = true;
            }

            //right side
            position = new Position(currentPosition.Line - 1, currentPosition.Column - 2);
            if (this.Board.IsValidPosition(position))
            {
                response[position.Line, position.Column] = true;
            }
            position.Column = currentPosition.Line + 1;
            if (this.Board.IsValidPosition(position))
            {
                response[position.Line, position.Column] = true;
            }

            return response;
        }

        public override string ToString()
        {
            return "H ";
        }
    }
}
