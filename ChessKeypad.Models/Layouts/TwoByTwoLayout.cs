using ChessKeypad.Models.Cells;
using System.Collections.Generic;

namespace ChessKeypad.Models.Layouts
{
    public class TwoByTwoLayout : Layout
    {
        public override Dictionary<Coordinate, Cell> Cells { get; } = new()
        {
            { new(0, 0), new DefaultCell('0') },
            { new(1, 0), new DefaultCell('1') },
            { new(0, 1), new DefaultCell('2') },
            { new(1, 1), new DefaultCell('3') },
        };        
    }
}
