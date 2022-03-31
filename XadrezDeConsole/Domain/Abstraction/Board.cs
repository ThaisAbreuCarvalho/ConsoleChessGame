using XadrezDeConsole.Helpers.GameException;

namespace XadrezDeConsole.Domain.Abstraction
{
    public class Board
    {
        public int Lines { get; } = 8;
        public int Columns { get; } = 8;

        private Piece[,] Pieces;

        public Board()
        {
            this.Pieces = new Piece[Lines, Columns];
        }

        public Piece Piece(int line, int column)
        {
            return Pieces[line, column];
        }

        public Piece Piece(Position position)
        {
            return Pieces[position.Line, position.Column];
        }

        public void InsertPiece(Piece piece, Position position)
        {
            if (IsEmpty(position))
                throw new GameException($"Position occupied {position}");

            this.Pieces[position.Line, position.Column] = piece;
            piece.Position = position;
        }
        
        public Piece RemovePiece(Position position)
        {
            var piece = Piece(position);
            if (piece == null)
            {
                return null;
            }

            piece.Position = null;
            Pieces[position.Line, position.Column] = null;
            return piece;
        }

        public bool IsValidPosition(Position position)
        {
            if (position.Line < 0 || position.Column < 0)
                return false;

            return (position.Line < this.Pieces.GetLength(0) && position.Column < this.Pieces.GetLength(1));
        }

        public void ValidatePosition(Position position)
        {
            if (!IsValidPosition(position))
                throw new GameException($"Invalid Position: {position}");
        }

        public bool IsEmpty(Position position)
        {
            IsValidPosition(position);
            return Piece(position) != null;
        }
    }
}
