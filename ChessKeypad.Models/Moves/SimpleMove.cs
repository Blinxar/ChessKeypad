using ChessKeypad.Models.Enums;

namespace ChessKeypad.Models.Moves
{
    public record SimpleMove(Direction Direction, int Distance, bool VariableLength) : Move(VariableLength)
    {
        public override Coordinate Process(Coordinate start)
        {
            return Direction switch
            {
                Direction.Up => start with { Y = start.Y + Distance },
                Direction.Down => start with { Y = start.Y - Distance },
                Direction.Left => start with { X = start.X - Distance },
                Direction.Right => start with { X = start.X + Distance },
                Direction.UpLeft => start with { Y = start.Y + Distance, X = start.X - Distance },
                Direction.UpRight => start with { Y = start.Y + Distance, X = start.X + Distance },
                Direction.DownLeft => start with { Y = start.Y - Distance, X = start.X - Distance },
                Direction.DownRight => start with { Y = start.Y - Distance, X = start.X + Distance },
                _ => throw new System.NotImplementedException(),
            };
        }
    }
}
