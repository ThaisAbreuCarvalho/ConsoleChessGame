using XadrezDeConsole.Helpers.Enums;

namespace XadrezDeConsole.Domain.Abstraction
{
    public abstract class Piece
    {
        public Board Board { get; protected set; }
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int Movements { get; protected set; }
    
        public Piece(Board board, Color color)
        {
            this.Board = board;
            this.Color = color;
            this.Position = null;
            this.Movements = 0;
        }

        public void Move()
        {
            this.Movements ++;
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

        public abstract bool[,] PossibleMovements();
    }
}
