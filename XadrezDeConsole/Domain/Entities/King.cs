﻿using System;
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

        public override bool[,] PossibleMovements()
        {
            var response = new bool[this.Board.Lines, this.Board.Columns];

            var position = new Position(this.Position.Line + 1, this.Position.Column);
            if (IsMovementValid(position))
                response[position.Line, position.Column] = true;
            position = new Position(this.Position.Line + 1, this.Position.Column + 1);
            if (IsMovementValid(position))
                response[position.Line, position.Column] = true;
            position = new Position(this.Position.Line + 1, this.Position.Column - 1);
            if (IsMovementValid(position))
                response[position.Line, position.Column] = true;

            position = new Position(this.Position.Line - 1, this.Position.Column);
            if (IsMovementValid(position))
                response[position.Line, position.Column] = true;
            position = new Position(this.Position.Line - 1, this.Position.Column + 1);
            if (IsMovementValid(position))
                response[position.Line, position.Column] = true;
            position = new Position(this.Position.Line - 1, this.Position.Column - 1);
            if (IsMovementValid(position))
                response[position.Line, position.Column] = true;

            position = new Position(this.Position.Line, this.Position.Column + 1);
            if (IsMovementValid(position))
                response[position.Line, position.Column] = true;
            position = new Position(this.Position.Line, this.Position.Column - 1);
            if (IsMovementValid(position))
                response[position.Line, position.Column] = true;

            return response;
        }

        public override string ToString()
        {
            return " K ";
        }
    }
}
