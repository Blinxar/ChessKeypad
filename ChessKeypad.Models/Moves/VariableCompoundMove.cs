using System.Collections.Generic;

namespace ChessKeypad.Models.Moves
{
    public record VariableCompoundMove(List<Move> Moves) : CompoundMove(Moves, true);
}
