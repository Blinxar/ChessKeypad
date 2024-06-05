using ChessKeypad.Models;
using ChessKeypad.Models.Enums;
using ChessKeypad.Models.Moves;
using System;

namespace ChessKeypad.Factories;

public class ChessPieceFactory
{
    public Piece Get(ChessPiece pieceType)
        => pieceType switch
        {
            ChessPiece.Pawn => GetPawn(),
            ChessPiece.Rook => GetRook(),
            ChessPiece.Knight => GetKnight(),
            ChessPiece.Bishop => GetBishop(),
            ChessPiece.Queen => GetQueen(),
            ChessPiece.King => GetKing(),
            _ => throw new NotImplementedException(),
        };

    private static Piece GetPawn()
        => new(
        [
            new SimpleMove(Direction.Up, 1, false)
        ]);

    private static Piece GetRook()
        => new(
        [
            new SimpleMove(Direction.Up, 1, true),
            new SimpleMove(Direction.Down, 1, true),
            new SimpleMove(Direction.Left, 1, true),
            new SimpleMove(Direction.Right, 1, true),
        ]);

    private static Piece GetKnight()
        => new(
        [
            new CompoundMove(
            [
                new SimpleMove(Direction.Up, 2, false),
                new SimpleMove(Direction.Left, 1, false),
            ], false),
            new CompoundMove(
            [
                new SimpleMove(Direction.Up, 2, false),
                new SimpleMove(Direction.Right, 1, false),
            ], false),
            new CompoundMove(
            [
                new SimpleMove(Direction.Down, 2, false),
                new SimpleMove(Direction.Left, 1, false),
            ], false),
            new CompoundMove(
            [
                new SimpleMove(Direction.Down, 2, false),
                new SimpleMove(Direction.Right, 1, false),
            ], false),
            new CompoundMove(
            [
                new SimpleMove(Direction.Left, 2, false),
                new SimpleMove(Direction.Up, 1, false),
            ], false),
            new CompoundMove(
            [
                new SimpleMove(Direction.Left, 2, false),
                new SimpleMove(Direction.Down, 1, false),
            ], false),
            new CompoundMove(
            [
                new SimpleMove(Direction.Right, 2, false),
                new SimpleMove(Direction.Up, 1, false),
            ], false),
            new CompoundMove(
            [
                new SimpleMove(Direction.Right, 2, false),
                new SimpleMove(Direction.Down, 1, false),
            ], false)
        ]);
    
    private static Piece GetBishop()
       => new(
        [
            new SimpleMove(Direction.UpLeft, 1, true),
            new SimpleMove(Direction.UpRight, 1, true),
            new SimpleMove(Direction.DownLeft, 1, true),
            new SimpleMove(Direction.DownRight, 1, true),
        ]);

    private static Piece GetQueen()
        => new(
        [
            new SimpleMove(Direction.UpLeft, 1, true),
            new SimpleMove(Direction.UpRight, 1, true),
            new SimpleMove(Direction.DownLeft, 1, true),
            new SimpleMove(Direction.DownRight, 1, true),
            new SimpleMove(Direction.Up, 1, true),
            new SimpleMove(Direction.Down, 1, true),
            new SimpleMove(Direction.Left, 1, true),
            new SimpleMove(Direction.Right, 1, true),
        ]);

    private static Piece GetKing()
        => new(
        [
            new SimpleMove(Direction.UpLeft, 1, false),
            new SimpleMove(Direction.UpRight, 1, false),
            new SimpleMove(Direction.DownLeft, 1, false),
            new SimpleMove(Direction.DownRight, 1, false),
            new SimpleMove(Direction.Up, 1, false),
            new SimpleMove(Direction.Down, 1, false),
            new SimpleMove(Direction.Left, 1, false),
            new SimpleMove(Direction.Right, 1, false),
        ]);
}
