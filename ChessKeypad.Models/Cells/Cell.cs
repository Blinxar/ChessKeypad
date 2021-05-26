namespace ChessKeypad.Models.Cells
{
    public abstract record Cell(char Character)
    {
        public abstract bool IsValid(int? position = null);
    }
}
