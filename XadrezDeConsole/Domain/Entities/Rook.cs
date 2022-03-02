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

            //upper
            for (int i = this.Position.Line; i > 0; i--)
            {
                var isEnemy = this.Board.Piece(new Position(i, this.Position.Column));

                if (isEnemy != null && isEnemy.Color == this.Color && isEnemy.Position != this.Position)
                {
                    break;
                }
                else if (isEnemy == null || isEnemy.Position != this.Position)
                {
                    response[i, this.Position.Column] = true;
                }
            }

            //left side
            for (int i = this.Position.Line; i > 0; i--)
            {
                var isEnemy = this.Board.Piece(new Position(this.Position.Line, i));

                if (isEnemy == null || isEnemy.Color != this.Color)
                {
                    response[i, this.Position.Column] = true;
                }
            }

            return response;
        }

        public override string ToString()
        {
            return "R ";
        }
    }
}
