namespace ChessKeypad.Models.Cells
{
    public abstract record Cell(char Character)
    {
        /// <summary>
        /// Determines whether this cell is valid.
        /// If <paramref name="position"/> == null, this method should return if the cell is valid for any position.
        /// Otherwise, it should return whether it is valid for the requested position
        /// </summary>
        /// <param name="position">The position in the number being generated, if required</param>
        /// <returns>Whether the cell is valid</returns>
        public abstract bool IsValid(int? position = null);
    }
}
