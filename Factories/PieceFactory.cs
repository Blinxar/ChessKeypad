using ChessKeypad.Models;
using ChessKeypad.Models.Enums;
using ChessKeypad.Models.Moves;
using System;
using System.Collections.Generic;

namespace ChessKeypad.Factories
{
    public class PieceFactory
    {
        public Piece Get(PieceType pieceType)
        {
            return pieceType switch
            {
                PieceType.Pawn => GetPawn(),
                PieceType.Rook => GetRook(),
                PieceType.Knight => GetKnight(),
                PieceType.Bishop => GetBishop(),
                PieceType.Queen => GetQueen(),
                PieceType.King => GetKing(),
                _ => throw new NotImplementedException(),
            };
        }

        Piece GetPawn()
        {
            return new Piece
            {
                ValidMoves = new List<Move>
                {
                    new FixedMove(Direction.Up, 1)
                }
            };
        }

        Piece GetRook()
        {
            return new Piece
            {
                ValidMoves = new List<Move>
                {
                    new VariableMove(Direction.Up),
                    new VariableMove(Direction.Down),
                    new VariableMove(Direction.Left),
                    new VariableMove(Direction.Right),
                }
            };
        }
        Piece GetKnight()
        {
            return new Piece
            {
                ValidMoves = new List<Move>
                {
                    new FixedCompoundMove(new List<Move>
                    {
                        new FixedMove(Direction.Up, 2),
                        new FixedMove(Direction.Left, 1),
                    }),
                    new FixedCompoundMove(new List<Move>
                    {
                        new FixedMove(Direction.Up, 2),
                        new FixedMove(Direction.Right, 1),
                    }),
                    new FixedCompoundMove(new List<Move>
                    {
                        new FixedMove(Direction.Down, 2),
                        new FixedMove(Direction.Left, 1),
                    }),
                    new FixedCompoundMove(new List<Move>
                    {
                        new FixedMove(Direction.Down, 2),
                        new FixedMove(Direction.Right, 1),
                    }),
                    new FixedCompoundMove(new List<Move>
                    {
                        new FixedMove(Direction.Left, 2),
                        new FixedMove(Direction.Up, 1),
                    }),
                    new FixedCompoundMove(new List<Move>
                    {
                        new FixedMove(Direction.Left, 2),
                        new FixedMove(Direction.Down, 1),
                    }),
                    new FixedCompoundMove(new List<Move>
                    {
                        new FixedMove(Direction.Right, 2),
                        new FixedMove(Direction.Up, 1),
                    }),
                    new FixedCompoundMove(new List<Move>
                    {
                        new FixedMove(Direction.Right, 2),
                        new FixedMove(Direction.Down, 1),
                    })
                }
            };
        }

        Piece GetBishop()
        {
            return new Piece
            {
                ValidMoves = new List<Move>
                {
                    new VariableMove(Direction.UpLeft),
                    new VariableMove(Direction.UpRight),
                    new VariableMove(Direction.DownLeft),
                    new VariableMove(Direction.DownRight),
                }
            };
        }

        Piece GetQueen()
        {
            return new Piece
            {
                ValidMoves = new List<Move>
                {
                    new VariableMove(Direction.UpLeft),
                    new VariableMove(Direction.UpRight),
                    new VariableMove(Direction.DownLeft),
                    new VariableMove(Direction.DownRight),
                    new VariableMove(Direction.Up),
                    new VariableMove(Direction.Down),
                    new VariableMove(Direction.Left),
                    new VariableMove(Direction.Right),
                }
            };
        }

        Piece GetKing()
        {
            return new Piece
            {
                ValidMoves = new List<Move>
                {
                    new FixedMove(Direction.UpLeft, 1),
                    new FixedMove(Direction.UpRight, 1),
                    new FixedMove(Direction.DownLeft, 1),
                    new FixedMove(Direction.DownRight, 1),
                    new FixedMove(Direction.Up, 1),
                    new FixedMove(Direction.Down, 1),
                    new FixedMove(Direction.Left, 1),
                    new FixedMove(Direction.Right, 1),
                }
            };
        }
    }
}
