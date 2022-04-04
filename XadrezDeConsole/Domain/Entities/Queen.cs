using System;
using System.Collections.Generic;
using System.Text;
using XadrezDeConsole.Domain.Abstraction;
using XadrezDeConsole.Helpers.Enums;

namespace XadrezDeConsole.Domain.Entities
{
    public class Queen : Piece
    {
        public Queen(Board board, Color color) : base(board, color)
        {
        }

        public override bool[,] PossibleMovements()
        {
            var response = new bool[this.Board.Lines, this.Board.Columns];

            var goOn = true;
            var position = new Position(this.Position.Line, this.Position.Column);
            while (goOn)
            {
                position.Line += 1;
                position.Column += 1;

                if (IsMovementValid(position))
                {
                    response[position.Line, position.Column] = true;
                    if (this.Board.Piece(position.Line, position.Column) != null)
                    {
                        break;
                    }
                }
                else
                {
                    goOn = false;
                }
            }

            goOn = true;
            position = new Position(this.Position.Line, this.Position.Column);
            while (goOn)
            {
                position.Line -= 1;
                position.Column -= 1;

                if (IsMovementValid(position))
                {
                    response[position.Line, position.Column] = true;
                    if (this.Board.Piece(position.Line, position.Column) != null)
                    {
                        break;
                    }
                }
                else
                {
                    goOn = false;
                }
            }

            goOn = true;
            position = new Position(this.Position.Line, this.Position.Column);
            while (goOn)
            {
                position.Line += 1;
                position.Column -= 1;

                if (IsMovementValid(position))
                {
                    response[position.Line, position.Column] = true;
                    if (this.Board.Piece(position.Line, position.Column) != null)
                    {
                        break;
                    }
                }
                else
                {
                    goOn = false;
                }
            }

            goOn = true;
            position = new Position(this.Position.Line, this.Position.Column);
            while (goOn)
            {
                position.Line -= 1;
                position.Column += 1;

                if (IsMovementValid(position))
                {
                    response[position.Line, position.Column] = true;
                    if (this.Board.Piece(position.Line, position.Column) != null)
                    {
                        break;
                    }
                }
                else
                {
                    goOn = false;
                }
            }

            for (int i = this.Position.Line + 1; i < this.Board.Lines; i++)
            {
                position = new Position(i, this.Position.Column);
                if (IsMovementValid(position))
                {
                    response[position.Line, position.Column] = true;
                    if (this.Board.Piece(position.Line, position.Column) != null)
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            for (int i = this.Position.Line - 1; i >= 0; i--)
            {
                position = new Position(i, this.Position.Column);
                if (IsMovementValid(position))
                {
                    response[position.Line, position.Column] = true;
                    if (this.Board.Piece(position.Line, position.Column) != null)
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            for (int i = this.Position.Column + 1; i < this.Board.Columns; i++)
            {
                position = new Position(this.Position.Line, i);
                if (IsMovementValid(position))
                {
                    response[position.Line, position.Column] = true;
                    if (this.Board.Piece(position.Line, position.Column) != null)
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            for (int i = this.Position.Column - 1; i >= 0; i--)
            {
                position = new Position(this.Position.Line, i);
                if (IsMovementValid(position))
                {
                    response[position.Line, position.Column] = true;
                    if (this.Board.Piece(position.Line, position.Column) != null)
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            return response;
        }

        public override string ToString()
        {
            return " Q ";
        }
    }
}
