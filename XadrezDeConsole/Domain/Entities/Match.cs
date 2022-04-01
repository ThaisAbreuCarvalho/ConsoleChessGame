using System.Collections.Generic;
using System.Linq;
using XadrezDeConsole.Domain.Abstraction;
using XadrezDeConsole.Helpers;
using XadrezDeConsole.Helpers.Enums;
using XadrezDeConsole.Helpers.GameException;

namespace XadrezDeConsole.Domain.Entities
{
    public class Match
    {
        public Board Board { get; private set; }
        private int Turn;
        public Color CurrentPlayer { get; private set; }
        public bool IsFinished { get; private set; }
        private HashSet<Piece> MatchPieces;
        private HashSet<Piece> CapturedPieces;

        public Match()
        {
            this.Board = new Board();
            this.Turn = 1;
            this.CurrentPlayer = Color.Yellow;
            this.MatchPieces = new HashSet<Piece>();
            this.CapturedPieces = new HashSet<Piece>();
            SetBoard();
        }

        public void ExecuteMovement(Position origin, Position destination)
        {
            MovePiece(origin, destination);
            this.Turn++;
            ChangePlayer();
        }

        public void ChangePlayer()
        {
            if (this.CurrentPlayer == Color.Yellow)
            {
                this.CurrentPlayer = Color.Red;
            }
            else
            {
                this.CurrentPlayer = Color.Yellow;
            }
        }

        public void ValidateOrigin(Position position)
        {
            if (!this.Board.IsValidPosition(position) || this.Board.Piece(position)?.Color != this.CurrentPlayer)
            {
                throw new GameException($"Position Invalid: {position}");
            }

            if (this.Board.Piece(position) == null)
            {
                throw new GameException($"No Piece Selected: {position}");
            }
        }

        public void MovePiece(Position origin, Position destination)
        {
            var possibleMovements = this.Board.Piece(origin).PossibleMovements();
            if (possibleMovements[destination.Line, destination.Column])
            {
                Piece piece = this.Board.RemovePiece(origin);
                piece.Move();
                Piece pieceTrapped = this.Board.RemovePiece(destination);
                this.Board.InsertPiece(piece, destination);
                piece.Move();

                if (pieceTrapped != null)
                {
                    this.CapturedPieces.Add(pieceTrapped);
                }
            }
            else
            {
                throw new GameException($"Position Invalid: {destination}");
            }
        }

        public void PlacePiece(Piece piece, Position position)
        {
            this.Board.InsertPiece(piece, position);
            this.MatchPieces.Add(piece);
        }

        private void SetBoard()
        {
            //yellow
            PlacePiece(new Knight(this.Board, Color.Yellow), new ScreenPositon('a', 1).ToPosition(this.Board));
            PlacePiece(new Rook(this.Board, Color.Yellow), new ScreenPositon('b', 1).ToPosition(this.Board));
            PlacePiece(new Bishop(this.Board, Color.Yellow), new ScreenPositon('c', 1).ToPosition(this.Board));
            PlacePiece(new King(this.Board, Color.Yellow), new ScreenPositon('d', 1).ToPosition(this.Board));
            PlacePiece(new Queen(this.Board, Color.Yellow), new ScreenPositon('e', 1).ToPosition(this.Board));
            PlacePiece(new Bishop(this.Board, Color.Yellow), new ScreenPositon('f', 1).ToPosition(this.Board));
            PlacePiece(new Rook(this.Board, Color.Yellow), new ScreenPositon('g', 1).ToPosition(this.Board));
            PlacePiece(new Knight(this.Board, Color.Yellow), new ScreenPositon('h', 1).ToPosition(this.Board));

            PlacePiece(new Pawn(this.Board, Color.Yellow, new Position(0, 2)), new ScreenPositon('a', 2).ToPosition(this.Board));
            PlacePiece(new Pawn(this.Board, Color.Yellow, new Position(1, 2)), new ScreenPositon('b', 2).ToPosition(this.Board));
            PlacePiece(new Pawn(this.Board, Color.Yellow, new Position(2, 2)), new ScreenPositon('c', 2).ToPosition(this.Board));
            PlacePiece(new Pawn(this.Board, Color.Yellow, new Position(3, 2)), new ScreenPositon('d', 2).ToPosition(this.Board));
            PlacePiece(new Pawn(this.Board, Color.Yellow, new Position(4, 2)), new ScreenPositon('e', 2).ToPosition(this.Board));
            PlacePiece(new Pawn(this.Board, Color.Yellow, new Position(5, 2)), new ScreenPositon('f', 2).ToPosition(this.Board));
            PlacePiece(new Pawn(this.Board, Color.Yellow, new Position(6, 2)), new ScreenPositon('g', 2).ToPosition(this.Board));
            PlacePiece(new Pawn(this.Board, Color.Yellow, new Position(7, 2)), new ScreenPositon('h', 2).ToPosition(this.Board));

            //red
            PlacePiece(new Knight(this.Board, Color.Red), new ScreenPositon('a', 8).ToPosition(this.Board));
            PlacePiece(new Rook(this.Board, Color.Red), new ScreenPositon('b', 8).ToPosition(this.Board));
            PlacePiece(new Bishop(this.Board, Color.Red), new ScreenPositon('c', 8).ToPosition(this.Board));
            PlacePiece(new King(this.Board, Color.Red), new ScreenPositon('d', 8).ToPosition(this.Board));
            PlacePiece(new Queen(this.Board, Color.Red), new ScreenPositon('e', 8).ToPosition(this.Board));
            PlacePiece(new Bishop(this.Board, Color.Red), new ScreenPositon('f', 8).ToPosition(this.Board));
            PlacePiece(new Rook(this.Board, Color.Red), new ScreenPositon('g', 8).ToPosition(this.Board));
            PlacePiece(new Knight(this.Board, Color.Red), new ScreenPositon('h', 8).ToPosition(this.Board));


            PlacePiece(new Pawn(this.Board, Color.Red, new Position(0, 7)), new ScreenPositon('a', 7).ToPosition(this.Board));
            PlacePiece(new Pawn(this.Board, Color.Red, new Position(1, 7)), new ScreenPositon('b', 7).ToPosition(this.Board));
            PlacePiece(new Pawn(this.Board, Color.Red, new Position(2, 7)), new ScreenPositon('c', 7).ToPosition(this.Board));
            PlacePiece(new Pawn(this.Board, Color.Red, new Position(3, 7)), new ScreenPositon('d', 7).ToPosition(this.Board));
            PlacePiece(new Pawn(this.Board, Color.Red, new Position(4, 7)), new ScreenPositon('e', 7).ToPosition(this.Board));
            PlacePiece(new Pawn(this.Board, Color.Red, new Position(5, 7)), new ScreenPositon('f', 7).ToPosition(this.Board));
            PlacePiece(new Pawn(this.Board, Color.Red, new Position(6, 7)), new ScreenPositon('g', 7).ToPosition(this.Board));
            PlacePiece(new Pawn(this.Board, Color.Red, new Position(7, 7)), new ScreenPositon('h', 7).ToPosition(this.Board));
        }

        public HashSet<Piece> GetRedCapturedPieces()
        {
            return this.CapturedPieces.Where(x => x.Color == Color.Red).ToHashSet();
        }
        
        public HashSet<Piece> GetYellowCapturedPieces()
        {
            return this.CapturedPieces.Where(x => x.Color == Color.Yellow).ToHashSet();
        }
    }
}
