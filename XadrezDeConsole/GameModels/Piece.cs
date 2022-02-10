using XadrezDeConsole.Helpers.Enums;

namespace XadrezDeConsole.GameModels
{
    public class Piece
    {
        public Board Board { get; protected set; }
        public Position Position { get; set; }
        public ColorEnum Color { get; protected set; }
        public int Movements { get; protected set; }
    
        public Piece(Board board, Position position, ColorEnum color)
        {
            this.Board = board;
            this.Position = position;
            this.Color = color;
            this.Movements = 0;
        }
    }
}
