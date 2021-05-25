using ChessKeypad.Models;
using ChessKeypad.Models.Enums;
using ChessKeypad.Models.Moves;

namespace ChessKeypad.Managers
{
    public class Mover
    {
        public bool IsMoveValid(Layout layout, Move move, Coordinate start, out Coordinate end)
        {
            end = ProcessMove(move, start);
            return layout.Cells.ContainsKey(end) && layout.Cells[end].ValidStatus != ValidStatus.Nowhere;
        }

        public Coordinate ProcessMove(Move move, Coordinate start)
        {
            return move switch
            {
                CompoundMove compoundMove => ProcessCompoundMove(compoundMove, start),
                FixedMove fixedMove => ProcessMove(start, fixedMove.Direction, fixedMove.Distance),
                VariableMove variableMove => ProcessMove(start, variableMove.Direction, 1),
                _ => throw new System.NotImplementedException(),
            };
        }

        Coordinate ProcessCompoundMove(CompoundMove move, Coordinate start)
        {
            var end = start;
            foreach (var subMove in move.Moves)
            {
                end = ProcessMove(subMove, end);
            }
            return end;
        }

        Coordinate ProcessMove(Coordinate start, Direction direction, int distance)
        {
            return direction switch
            {
                Direction.Up => start with { Y = start.Y + distance },
                Direction.Down => start with { Y = start.Y - distance },
                Direction.Left => start with { X = start.X - distance },
                Direction.Right => start with { X = start.X + distance },
                Direction.UpLeft => start with { Y = start.Y + distance, X = start.X - distance },
                Direction.UpRight => start with { Y = start.Y + distance, X = start.X + distance },
                Direction.DownLeft => start with { Y = start.Y - distance, X = start.X - distance },
                Direction.DownRight => start with { Y = start.Y - distance, X = start.X + distance },
                _ => throw new System.NotImplementedException(),
            };
        }
    }
}
