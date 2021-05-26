using ChessKeypad.Models;
using ChessKeypad.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessKeypad.Managers
{
    public class NumberGenerator
    {
        public int CalculatePermutations(Layout layout, Piece piece, int numberOfDigits)
        {
            if (numberOfDigits < 1)
            {
                throw new ArgumentException($"Cannot be less than 1", nameof(numberOfDigits));
            }

            var validMoves = CalculateValidMoves(layout, piece);

            var permutations = 0;
            foreach (Coordinate start in validMoves.Keys.Where(x => layout.Cells[x].ValidStatus == ValidStatus.Anywhere))
            {
                permutations += CalculatePermutations(numberOfDigits, start, validMoves);
            }
            return permutations;
        }

        Dictionary<Coordinate, List<Coordinate>> CalculateValidMoves(Layout layout, Piece piece)
        {
            // Calculate all valid moves from a valid start position to any other node
            var validMoves = new Dictionary<Coordinate, List<Coordinate>>();
            var mover = new Mover();
            foreach (var coordinate in layout.Cells.Keys)
            {
                foreach (var move in piece.ValidMoves)
                {
                    if (mover.IsMoveValid(layout, move, coordinate, out var endCoordinate))
                    {
                        if (!validMoves.ContainsKey(coordinate))
                        {
                            validMoves[coordinate] = new List<Coordinate>();
                        }
                        validMoves[coordinate].Add(endCoordinate);

                        // If the move has a variable length, keep going until the move is no longer valid
                        if (move.VariableLength)
                        {
                            while (mover.IsMoveValid(layout, move, endCoordinate, out endCoordinate))
                            {
                                validMoves[coordinate].Add(endCoordinate);
                            }
                        }
                    }
                }
            }
            return validMoves;
        }

        int CalculatePermutations(int numberOfDigits, Coordinate start, Dictionary<Coordinate, List<Coordinate>> validMoves)
        {
            // Fully completed a number
            if (numberOfDigits == 1)
            {
                return 1;
            }
            // Reached a dead end
            if (!validMoves.ContainsKey(start))
            {
                return 0;
            }
            var permutations = 0;
            foreach (var node in validMoves[start])
            {
                permutations += CalculatePermutations(numberOfDigits - 1, node, validMoves);
            }
            return permutations;
        }
    }
}
