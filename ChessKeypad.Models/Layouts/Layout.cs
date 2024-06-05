using ChessKeypad.Models.Cells;
using System.Collections.Generic;

namespace ChessKeypad.Models.Layouts;

public abstract class Layout
{
    public abstract Dictionary<Coordinate, Cell> Cells { get; }

    /// <summary>
    /// Returns whether the given coordinate is valid.
    /// If <paramref name="position"/> == null then the method should check whether the coordinate is valid for any position
    /// </summary>
    /// <param name="coordinate">The coordinate to test</param>
    /// <param name="position">The poisition in the number being generated, if required</param>
    /// <returns>Whether the coordinate is valid</returns>
    public virtual bool IsCoordinateValid(Coordinate coordinate, int? position = null)
    {
        return Cells.ContainsKey(coordinate) && Cells[coordinate].IsValid(position);
    }
}
