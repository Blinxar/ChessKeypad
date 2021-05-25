using ChessKeypad.Models.Enums;

namespace ChessKeypad.Models.Moves
{
    public record VariableMove(Direction Direction) : Move(true);
}
