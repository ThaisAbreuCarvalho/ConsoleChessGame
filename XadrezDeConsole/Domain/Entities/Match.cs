using XadrezDeConsole.Domain.Abstraction;
using XadrezDeConsole.Helpers;
using XadrezDeConsole.Helpers.Enums;

namespace XadrezDeConsole.Domain.Entities
{
    public class Match
    {
        public Board Board { get; private set; }

        private int Turn;

        private Color CurrentPlayer;

        public Match()
        {
            this.Board = new Board();
            this.Turn = 1;
            this.CurrentPlayer = Color.Yellow;
            SetBoard();
        }

        public void MovePiece(Position origin, Position destination)
        {
            Piece piece = this.Board.RemovePiece(origin);
            piece.Move();
            Piece pieceTrapped = this.Board.RemovePiece(destination);
            this.Board.InsertPiece(piece, destination);
        }

        private void SetBoard()
        {
            //yellow
            this.Board.InsertPiece(new Horse(this.Board, Color.Yellow), new ScreenPositon('a', 1).ToPosition(this.Board));
            this.Board.InsertPiece(new Tour(this.Board, Color.Yellow), new ScreenPositon('b', 1).ToPosition(this.Board));
            this.Board.InsertPiece(new Bishop(this.Board, Color.Yellow), new ScreenPositon('c', 1).ToPosition(this.Board));
            this.Board.InsertPiece(new King(this.Board, Color.Yellow), new ScreenPositon('d', 1).ToPosition(this.Board));
            this.Board.InsertPiece(new Queen(this.Board, Color.Yellow), new ScreenPositon('e', 1).ToPosition(this.Board));
            this.Board.InsertPiece(new Bishop(this.Board, Color.Yellow), new ScreenPositon('f', 1).ToPosition(this.Board));
            this.Board.InsertPiece(new Tour(this.Board, Color.Yellow), new ScreenPositon('g', 1).ToPosition(this.Board));
            this.Board.InsertPiece(new Horse(this.Board, Color.Yellow), new ScreenPositon('h', 1).ToPosition(this.Board));

            this.Board.InsertPiece(new Pawn(this.Board, Color.Yellow), new ScreenPositon('a', 2).ToPosition(this.Board));
            this.Board.InsertPiece(new Pawn(this.Board, Color.Yellow), new ScreenPositon('b', 2).ToPosition(this.Board));
            this.Board.InsertPiece(new Pawn(this.Board, Color.Yellow), new ScreenPositon('c', 2).ToPosition(this.Board));
            this.Board.InsertPiece(new Pawn(this.Board, Color.Yellow), new ScreenPositon('d', 2).ToPosition(this.Board));
            this.Board.InsertPiece(new Pawn(this.Board, Color.Yellow), new ScreenPositon('e', 2).ToPosition(this.Board));
            this.Board.InsertPiece(new Pawn(this.Board, Color.Yellow), new ScreenPositon('f', 2).ToPosition(this.Board));
            this.Board.InsertPiece(new Pawn(this.Board, Color.Yellow), new ScreenPositon('g', 2).ToPosition(this.Board));
            this.Board.InsertPiece(new Pawn(this.Board, Color.Yellow), new ScreenPositon('h', 2).ToPosition(this.Board));

            //red
            this.Board.InsertPiece(new Horse(this.Board, Color.Red), new ScreenPositon('a', 8).ToPosition(this.Board));
            this.Board.InsertPiece(new Tour(this.Board, Color.Red), new ScreenPositon('b', 8).ToPosition(this.Board));
            this.Board.InsertPiece(new Bishop(this.Board, Color.Red), new ScreenPositon('c', 8).ToPosition(this.Board));
            this.Board.InsertPiece(new King(this.Board, Color.Red), new ScreenPositon('d', 8).ToPosition(this.Board));
            this.Board.InsertPiece(new Queen(this.Board, Color.Red), new ScreenPositon('e', 8).ToPosition(this.Board));
            this.Board.InsertPiece(new Bishop(this.Board, Color.Red), new ScreenPositon('f', 8).ToPosition(this.Board));
            this.Board.InsertPiece(new Tour(this.Board, Color.Red), new ScreenPositon('g', 8).ToPosition(this.Board));
            this.Board.InsertPiece(new Horse(this.Board, Color.Red), new ScreenPositon('h', 8).ToPosition(this.Board));


            this.Board.InsertPiece(new Pawn(this.Board, Color.Red), new ScreenPositon('a', 7).ToPosition(this.Board));
            this.Board.InsertPiece(new Pawn(this.Board, Color.Red), new ScreenPositon('b', 7).ToPosition(this.Board));
            this.Board.InsertPiece(new Pawn(this.Board, Color.Red), new ScreenPositon('c', 7).ToPosition(this.Board));
            this.Board.InsertPiece(new Pawn(this.Board, Color.Red), new ScreenPositon('d', 7).ToPosition(this.Board));
            this.Board.InsertPiece(new Pawn(this.Board, Color.Red), new ScreenPositon('e', 7).ToPosition(this.Board));
            this.Board.InsertPiece(new Pawn(this.Board, Color.Red), new ScreenPositon('f', 7).ToPosition(this.Board));
            this.Board.InsertPiece(new Pawn(this.Board, Color.Red), new ScreenPositon('g', 7).ToPosition(this.Board));
            this.Board.InsertPiece(new Pawn(this.Board, Color.Red), new ScreenPositon('h', 7).ToPosition(this.Board));
        }
    }
}
