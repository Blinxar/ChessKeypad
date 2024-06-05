using ChessKeypad.Models.Cells;
using System.Collections.Generic;

namespace ChessKeypad.Models.Layouts;

public class KeypadLayout : Layout
{
    public override Dictionary<Coordinate, Cell> Cells { get; } = new()
    {
        [new(0, 0)] = new NeverValidCell('*'),
        [new(1, 0)] = new NotValidAtPositionCell('0', 0),
        [new(2, 0)] = new NeverValidCell('#'),
        [new(0, 1)] = new DefaultCell('7'),
        [new(1, 1)] = new DefaultCell('8'),
        [new(2, 1)] = new DefaultCell('9'),
        [new(0, 2)] = new DefaultCell('4'),
        [new(1, 2)] = new DefaultCell('5'),
        [new(2, 2)] = new DefaultCell('6'),
        [new(0, 3)] = new NotValidAtPositionCell('1', 0),
        [new(1, 3)] = new DefaultCell('2'),
        [new(2, 3)] = new DefaultCell('3')
    };        
}
