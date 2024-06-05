namespace ChessKeypad.Models.Moves;

public abstract record Move (bool VariableLength)
{
    /// <summary>
    /// Process a single iteration of this move
    /// </summary>
    /// <param name="start">The coordinate to start from</param>
    /// <returns>The resulting coordinate</returns>
    public abstract Coordinate Process(Coordinate start);
}
