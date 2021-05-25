using ChessKeypad.Models.Enums;

namespace ChessKeypad.Models.Moves
{
    public record FixedMove(Direction Direction, int Distance) : Move(false);
}
