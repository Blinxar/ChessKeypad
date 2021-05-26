using System.Collections.Generic;

namespace ChessKeypad.Models.Moves
{
    public record CompoundMove(List<Move> Moves, bool VariableLength) : Move(VariableLength)
    {
        public override Coordinate Process(Coordinate start)
        {
            var end = start;
            foreach (var move in Moves)
            {
                end = move.Process(end);
            }
            return end;
        }
    }
}
