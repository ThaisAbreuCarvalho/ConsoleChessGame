using System;
using System.Collections.Generic;
using System.Text;
using XadrezDeConsole.Domain.Abstraction;
using XadrezDeConsole.Helpers.Enums;

namespace XadrezDeConsole.Domain.Entities
{
    public class Pawn : Piece
    {
        public Position InitialPosition { get; set; }

        public Pawn(Board board, Color color, Position initialPosition) : base(board, color)
        {
            this.Position = InitialPosition;
        }

        public override bool[,] PossibleMovements()
        {
            var response = new bool[this.Board.Lines, this.Board.Columns];
            var direction = this.Color == Color.Red ? -1 : 1;

            var position = new Position(this.Position.Line + (direction * -1), this.Position.Column);
            if (IsMovementValid(position) && this.Board.Piece(position) == null)
            {
                response[position.Line, position.Column] = true;
            }

            position = new Position(this.Position.Line + (direction * -2), this.Position.Column);
            if (this.Movements == 0)
            {
                if (IsMovementValid(position) && this.Board.Piece(position) == null)
                {
                    response[position.Line, position.Column] = true;
                }
            }

            position = new Position(this.Position.Line + (direction * -1), this.Position.Column - 1);
            if (IsMovementValid(position) && (this.Board.Piece(position) == null || this.Board.Piece(position).Color != this.Color))
            {
                response[position.Line, position.Column] = true;
            }

            position = new Position(this.Position.Line + (direction * -1), this.Position.Column + 1);
            if (IsMovementValid(position) && (this.Board.Piece(position) == null || this.Board.Piece(position) .Color != this.Color))
            {
                response[position.Line, position.Column] = true;
            }

            return response;
        }

        public override string ToString()
        {
            return " P ";
        }
    }
}
