using System;
using System.Collections.Generic;
using System.Text;
using XadrezDeConsole.Domain.Abstraction;
using XadrezDeConsole.Helpers.Enums;

namespace XadrezDeConsole.Domain.Entities
{
    public class Bishop : Piece
    {
        public override string Name { get; set; } = "B";

        public Bishop(Board board, Color color) : base(board, color)
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

                    if(this.Board.Piece(position) != null)
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

                    if (this.Board.Piece(position) != null)
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

                    if (this.Board.Piece(position) != null)
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

                    if (this.Board.Piece(position) != null)
                    {
                        break;
                    }
                }
                else
                {
                    goOn = false;
                }
            }

            return response;
        }

        public override string ToString()
        {
            return $" {this.Name} ";
        }
    }
}
