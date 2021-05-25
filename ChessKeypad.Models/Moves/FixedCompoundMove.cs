using System.Collections.Generic;

namespace ChessKeypad.Models.Moves
{
    public record FixedCompoundMove(List<Move> Moves) : CompoundMove(Moves, false);
}
