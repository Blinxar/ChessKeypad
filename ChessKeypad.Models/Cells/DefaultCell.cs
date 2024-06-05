namespace ChessKeypad.Models.Cells;

public record DefaultCell(char Character) : Cell(Character)
{
    public override bool IsValid(int? position = null) => true;
}
