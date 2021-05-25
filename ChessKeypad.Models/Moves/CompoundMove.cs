using System.Collections.Generic;

namespace ChessKeypad.Models.Moves
{
    public abstract record CompoundMove : Move
    {
        public List<Move> Moves { get; } = new List<Move>();

        protected CompoundMove(List<Move> moves, bool VariableLength) : base(VariableLength)
        {
            Moves = moves;
        }
    }
}
