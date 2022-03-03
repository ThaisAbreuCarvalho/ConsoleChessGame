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
            var position = new Position(0, 0);

            //moves just foward
            if (this.InitialPosition.Line == 7)
            {
                position = new Position(this.Position.Line - 1, this.Position.Column);

                if (this.IsMovementValid(position) && this.Board.Piece(position) == null)
                {
                    response[position.Line, position.Column] = true;
                }

                if (this.Movements == 0)
                {
                    position = new Position(this.Position.Line - 2, this.Position.Column);
                    if (this.IsMovementValid(position) && this.Board.Piece(position) == null)
                    {
                        response[position.Line, position.Column] = true;
                    }
                }

                //side check
            }
            else
            {

            }

            return response;
        }

        public override string ToString()
        {
            return " P ";
        }
    }
}
