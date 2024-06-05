using ChessKeypad.Models;
using ChessKeypad.Models.Cells;
using ChessKeypad.Models.Layouts;
using System;
using System.Collections.Generic;

namespace ChessKeypad.Managers;

public class PermutationsGenerator
{
    public static int CalculatePermutations(Layout layout, Piece piece, int numberOfDigits)
    {
        if (numberOfDigits < 1)
        {
            throw new ArgumentException($"Cannot be less than 1", nameof(numberOfDigits));
        }

        var validMoves = CalculateValidMoves(layout, piece);

        var permutations = 0;
        foreach (Coordinate start in validMoves.Keys)
        {
            permutations += CalculatePermutations(numberOfDigits, 0, start, layout.Cells[start], validMoves);
        }
        return permutations;
    }

    private static Dictionary<Coordinate, List<(Coordinate Coordinate, Cell Cell)>> CalculateValidMoves(Layout layout, Piece piece)
    {
        // Calculate all valid moves from a valid start position to any other node
        var validMoves = new Dictionary<Coordinate, List<(Coordinate Coordinate, Cell Cell)>>();
        foreach (var coordinate in layout.Cells.Keys)
        {
            foreach (var move in piece.ValidMoves)
            {
                var endCoordinate = move.Process(coordinate);
                if (!layout.IsCoordinateValid(endCoordinate))
                {
                    continue;
                }

                if (!validMoves.TryGetValue(coordinate, out List<(Coordinate Coordinate, Cell Cell)> value))
                {
                    value = [];
                    validMoves[coordinate] = value;
                }

                value.Add((endCoordinate, layout.Cells[endCoordinate]));

                // If the move has a variable length, keep going until the move is no longer valid
                if (move.VariableLength)
                {
                    endCoordinate = move.Process(endCoordinate);
                    while (layout.IsCoordinateValid(endCoordinate))
                    {
                        value.Add((endCoordinate, layout.Cells[endCoordinate]));
                        endCoordinate = move.Process(endCoordinate);
                    }
                }
            }
        }
        return validMoves;
    }

    static int CalculatePermutations(int numberOfDigits, int position, Coordinate start, Cell cell, Dictionary<Coordinate, List<(Coordinate Coordinate, Cell Cell)>> validMoves)
    {
        // If this cell isn't valid at this position
        if (!cell.IsValid(position))
        {
            return 0;
        }
        // Fully completed a number
        if (numberOfDigits == position + 1)
        {
            return 1;
        }
        // Reached a dead end
        if (!validMoves.TryGetValue(start, out List<(Coordinate Coordinate, Cell Cell)> value))
        {
            return 0;
        }
        var permutations = 0;
        foreach (var node in value)
        {
            permutations += CalculatePermutations(numberOfDigits, position + 1, node.Coordinate, node.Cell, validMoves);
        }
        return permutations;
    }
}
