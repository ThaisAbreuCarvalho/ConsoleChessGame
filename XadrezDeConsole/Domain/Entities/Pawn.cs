using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XadrezDeConsole.Domain.Abstraction;
using XadrezDeConsole.Helpers.Enums;

namespace XadrezDeConsole.Domain.Entities
{
    public class Pawn : Piece
    {
        public Match Match;
        public Position InitialPosition { get; set; }
        public override string Name { get; set; } = "P";

        public Pawn(Board board, Color color, Position initialPosition, Match match) : base(board, color)
        {
            this.Position = initialPosition;
            this.Match = match;
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

            if (this.Movements == 0 && response[position.Line, position.Column] == true)
            {
                position = new Position(this.Position.Line + (direction * -2), this.Position.Column);
                if (IsMovementValid(position) && this.Board.Piece(position) == null)
                {
                    response[position.Line, position.Column] = true;
                }
            }

            position = new Position(this.Position.Line + (direction * -1), this.Position.Column - 1);
            if (IsMovementValid(position) && this.Board.Piece(position) != null)
            {
                response[position.Line, position.Column] = true;
            }

            position = new Position(this.Position.Line + (direction * -1), this.Position.Column + 1);
            if (IsMovementValid(position) && this.Board.Piece(position) != null)
            {
                response[position.Line, position.Column] = true;
            }

            VerifyEnPassant(response);

            return response;
        }

        public override string ToString()
        {
            return $" {this.Name} ";
        }

        public void VerifyEnPassant(bool[,] possibleMovements)
        {
            var direction = this.Color == Color.Red ? 1 : -1;

            if (this.Position.Line == 3 || this.Position.Line == 4)
            {
                var positionLeft = new Position(this.Position.Line, this.Position.Column - 1);
                var positionRight = new Position(this.Position.Line, this.Position.Column + 1);

                if (this.Board.IsValidPosition(positionLeft) && this.Board.Piece(positionLeft) != null && Match.EnPassant != null)
                {
                    if (this.Board.IsValidPosition(new Position(this.Position.Line + direction, this.Position.Column - 1)) && Match.EnPassant.Equals(this.Board.Piece(positionLeft)))
                    {
                        possibleMovements[this.Position.Line + direction, this.Position.Column - 1] = true;
                        Match.EnPassantAllowed = true;
                    }
                }
                else if (this.Board.IsValidPosition(positionRight) && this.Board.Piece(positionRight) != null && Match.EnPassant != null)
                {
                    if (this.Board.IsValidPosition(new Position(this.Position.Line + direction, this.Position.Column + 1)) && Match.EnPassant.Equals(this.Board.Piece(positionRight)))
                    {
                        possibleMovements[this.Position.Line + direction, this.Position.Column + 1] = true;
                        Match.EnPassantAllowed = true;
                    }
                }
            }
        }
    }
}
