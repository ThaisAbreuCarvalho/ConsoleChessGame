using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XadrezDeConsole.Domain.Abstraction;
using XadrezDeConsole.Helpers.Enums;

namespace XadrezDeConsole.Domain.Entities
{
    public class King : Piece
    {
        private Match Match;
        public override string Name { get; set; } = "K";

        public King(Board board, Color color, Match match) : base(board, color)
        {
            this.Match = match;
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

            VerifyCastling(response);

            return response;
        }

        public override string ToString()
        {
            return $" {this.Name} ";
        }

        public void VerifyCastling(bool[,] possibleMovements)
        {
            if (this.Movements == 0)
            {
                var rooks = this.Match.MatchPieces.Where(x => x.Color == this.Match.CurrentPlayer && x is Rook);

                foreach (var rook in rooks)
                {
                    var rookPosition = rook.Position;

                    if (rookPosition.Column == 0)
                    {
                        var pos = this.Board.Piece(new Position(rookPosition.Line, rookPosition.Column + 1)) == null;
                        var pos1 = this.Board.Piece(rookPosition.Line, rookPosition.Column + 2) == null;
                        var pos2 = this.Board.Piece(rookPosition.Line, rookPosition.Column + 3) == null;
                        if (pos && pos1 && pos2)
                        {
                            Match.CastlingPosition = new Position(this.Position.Line, this.Position.Column - 2);
                            possibleMovements[this.Position.Line, this.Position.Column - 2] = true;
                        }
                    }
                    else if (rookPosition.Column == 7)
                    {
                        var pos1 = this.Board.Piece(new Position(rookPosition.Line, rookPosition.Column - 1)) == null;
                        var pos2 = this.Board.Piece(rookPosition.Line, rookPosition.Column - 2) == null;
                        if (pos1 && pos2)
                        {
                            Match.CastlingPosition = new Position(this.Position.Line, this.Position.Column + 2);
                            possibleMovements[this.Position.Line, this.Position.Column + 2] = true;
                        }
                    }
                }
            }
        }
    }
}
