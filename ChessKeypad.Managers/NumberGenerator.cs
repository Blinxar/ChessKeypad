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
            var mover = new Mover();

            // Calculate all valid moves from a valid start position to any other node
            var validMoves = new Dictionary<Coordinate, List<Coordinate>>();
            foreach (var coordinate in layout.Cells.Keys.Where(x => layout.Cells[x].ValidStatus == ValidStatus.Anywhere))
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

            var permutations = 0;
            foreach (Coordinate start in validMoves.Keys)
            {
                permutations += CalculatePermutations(numberOfDigits, start, validMoves);
            }
            return permutations;
        }

        int CalculatePermutations(int numberOfDigits, Coordinate start, Dictionary<Coordinate, List<Coordinate>> validMoves)
        {
            if (numberOfDigits == 1)
            {
                return 1;
            }
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
