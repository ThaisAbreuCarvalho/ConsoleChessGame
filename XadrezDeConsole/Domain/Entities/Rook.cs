using System;
using System.Collections.Generic;
using System.Text;
using XadrezDeConsole.Domain.Abstraction;
using XadrezDeConsole.Helpers.Enums;

namespace XadrezDeConsole.Domain.Entities
{
    public class Rook : Piece
    {
        public Rook(Board board, Color color) : base(board, color)
        {
        }

        public override bool[,] PossibleMovements()
        {
            var response = new bool[this.Board.Lines, this.Board.Columns];

            //top and bottom check
            for (int i = this.Position.Line; i < this.Board.Lines; i++)
            {
                var position = new Position(i, this.Position.Column);
                if (IsMovementValid(position))
                {
                    var hasPiece = this.Board.Piece(position);

                    if (hasPiece == null || hasPiece.Color != this.Color)
                    {
                        response[position.Line, position.Column] = true;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            for (int i = this.Position.Line; i >= 0; i--)
            {
                var position = new Position(i, this.Position.Column);
                if (IsMovementValid(position))
                {
                    var hasPiece = this.Board.Piece(position);

                    if (hasPiece == null || hasPiece.Color != this.Color)
                    {
                        response[position.Line, position.Column] = true;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            //sides check
            for (int i = this.Position.Column; i < this.Board.Columns; i++)
            {
                var position = new Position(this.Position.Line, i);
                if (IsMovementValid(position))
                {
                    var hasPiece = this.Board.Piece(position);

                    if (hasPiece == null || hasPiece.Color != this.Color)
                    {
                        response[position.Line, position.Column] = true;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            for (int i = this.Position.Column; i >= 0; i--)
            {
                var position = new Position(this.Position.Line, i);
                if (IsMovementValid(position))
                {
                    var hasPiece = this.Board.Piece(position);

                    if (hasPiece == null || hasPiece.Color != this.Color)
                    {
                        response[position.Line, position.Column] = true;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return response;
        }

        public override string ToString()
        {
            return " R ";
        }
    }
}
