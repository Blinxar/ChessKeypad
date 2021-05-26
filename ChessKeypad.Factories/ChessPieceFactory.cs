using ChessKeypad.Models;
using ChessKeypad.Models.Enums;
using ChessKeypad.Models.Moves;
using System;
using System.Collections.Generic;

namespace ChessKeypad.Factories
{
    public class ChessPieceFactory
    {
        public Piece Get(ChessPiece pieceType)
        {
            return pieceType switch
            {
                ChessPiece.Pawn => GetPawn(),
                ChessPiece.Rook => GetRook(),
                ChessPiece.Knight => GetKnight(),
                ChessPiece.Bishop => GetBishop(),
                ChessPiece.Queen => GetQueen(),
                ChessPiece.King => GetKing(),
                _ => throw new NotImplementedException(),
            };
        }

        Piece GetPawn()
        {
            return new Piece(new()
            {
                new SimpleMove(Direction.Up, 1, false)
            });
        }

        Piece GetRook()
        {
            return new Piece(new()
            {
                new SimpleMove(Direction.Up, 1, true),
                new SimpleMove(Direction.Down, 1, true),
                new SimpleMove(Direction.Left, 1, true),
                new SimpleMove(Direction.Right, 1, true),
            });
        }
        Piece GetKnight()
        {
            return new Piece(new()
            {
                new CompoundMove(new()
                {
                    new SimpleMove(Direction.Up, 2, false),
                    new SimpleMove(Direction.Left, 1, false),
                }, false),
                new CompoundMove(new()
                {
                    new SimpleMove(Direction.Up, 2, false),
                    new SimpleMove(Direction.Right, 1, false),
                }, false),
                new CompoundMove(new()
                {
                    new SimpleMove(Direction.Down, 2, false),
                    new SimpleMove(Direction.Left, 1, false),
                }, false),
                new CompoundMove(new()
                {
                    new SimpleMove(Direction.Down, 2, false),
                    new SimpleMove(Direction.Right, 1, false),
                }, false),
                new CompoundMove(new()
                {
                    new SimpleMove(Direction.Left, 2, false),
                    new SimpleMove(Direction.Up, 1, false),
                }, false),
                new CompoundMove(new()
                {
                    new SimpleMove(Direction.Left, 2, false),
                    new SimpleMove(Direction.Down, 1, false),
                }, false),
                new CompoundMove(new()
                {
                    new SimpleMove(Direction.Right, 2, false),
                    new SimpleMove(Direction.Up, 1, false),
                }, false),
                new CompoundMove(new()
                {
                    new SimpleMove(Direction.Right, 2, false),
                    new SimpleMove(Direction.Down, 1, false),
                }, false)
            });
        }

        Piece GetBishop()
        {
            return new Piece(new()
            {
                new SimpleMove(Direction.UpLeft, 1, true),
                new SimpleMove(Direction.UpRight, 1, true),
                new SimpleMove(Direction.DownLeft, 1, true),
                new SimpleMove(Direction.DownRight, 1, true),
            });
        }

        Piece GetQueen()
        {
            return new Piece(new()
            {
                new SimpleMove(Direction.UpLeft, 1, true),
                new SimpleMove(Direction.UpRight, 1, true),
                new SimpleMove(Direction.DownLeft, 1, true),
                new SimpleMove(Direction.DownRight, 1, true),
                new SimpleMove(Direction.Up, 1, true),
                new SimpleMove(Direction.Down, 1, true),
                new SimpleMove(Direction.Left, 1, true),
                new SimpleMove(Direction.Right, 1, true),
            });
        }

        Piece GetKing()
        {
            return new Piece(new()
            {
                new SimpleMove(Direction.UpLeft, 1, false),
                new SimpleMove(Direction.UpRight, 1, false),
                new SimpleMove(Direction.DownLeft, 1, false),
                new SimpleMove(Direction.DownRight, 1, false),
                new SimpleMove(Direction.Up, 1, false),
                new SimpleMove(Direction.Down, 1, false),
                new SimpleMove(Direction.Left, 1, false),
                new SimpleMove(Direction.Right, 1, false),
            });
        }
    }
}
