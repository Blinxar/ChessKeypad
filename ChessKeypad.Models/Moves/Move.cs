namespace ChessKeypad.Models.Moves
{
    public abstract record Move (bool VariableLength)
    {
        public abstract Coordinate Process(Coordinate start);
    }
}
