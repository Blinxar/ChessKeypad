namespace ChessKeypad.Models.Cells;

public record NeverValidCell(char Character) : Cell(Character)
{
    public override bool IsValid(int? position = null) => false;
}
