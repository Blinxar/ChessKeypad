using ChessKeypad.Models.Cells;
using System.Collections.Generic;

namespace ChessKeypad.Models.Layouts
{
    public abstract class Layout
    {
        public abstract Dictionary<Coordinate, Cell> Cells { get; }

        public virtual bool IsCoordinateValid(Coordinate coordinate, int? position = null)
        {
            return Cells.ContainsKey(coordinate) && Cells[coordinate].IsValid(position);
        }
    }
}
