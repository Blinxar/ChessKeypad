using System.Collections.Generic;

namespace ChessKeypad.Models
{
    public class Layout
    {
        public Dictionary<Coordinate, Cell> Cells { get; init; }
    }
}
