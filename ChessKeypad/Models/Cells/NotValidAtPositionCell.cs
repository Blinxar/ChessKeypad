namespace ChessKeypad.Models.Cells;

public record NotValidAtPositionCell(char Character, int Position) : Cell(Character)
{
    public override bool IsValid(int? position = null)
    {
        return !position.HasValue || Position != position;
    }
}
