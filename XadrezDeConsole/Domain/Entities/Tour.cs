using System;
using System.Collections.Generic;
using System.Text;
using XadrezDeConsole.Domain.Abstraction;
using XadrezDeConsole.Helpers.Enums;

namespace XadrezDeConsole.Domain.Entities
{
    public class Tour : Piece
    {
        public Tour(Board board, Color color) : base(board, color)
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
            var currentPosition = this.Board.Piece(this.Position);

            //upper
            for (int i = currentPosition.Position.Line; i > 0; i--)
            {
                var isEnemy = this.Board.Piece(new Position(i, currentPosition.Position.Column));

                if (isEnemy != null && isEnemy.Color == this.Color && isEnemy.Position != currentPosition.Position)
                {
                    break;
                }
                else if (isEnemy.Position != currentPosition.Position)
                {
                    response[i, currentPosition.Position.Column] = true;
                }
            }

            //left side
            for (int i = currentPosition.Position.Line; i > 0; i--)
            {
                var isEnemy = this.Board.Piece(new Position(currentPosition.Position.Line, i));

                if (isEnemy == null || isEnemy.Color != this.Color && isEnemy.Position != currentPosition.Position)
                {
                    response[i, currentPosition.Position.Column] = true;
                }
            }

            return response;
        }

        public override string ToString()
        {
            return "T ";
        }
    }
}
