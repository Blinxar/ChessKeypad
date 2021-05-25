using ChessKeypad.Factories;
using ChessKeypad.Models.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

namespace ChessKeypad.Tests
{
    [TestClass]
    public class PieceTests
    {
        [TestMethod]
        [DataRow(PieceType.Pawn, 1)]
        [DataRow(PieceType.Rook, 4)]
        [DataRow(PieceType.Knight, 8)]
        [DataRow(PieceType.Bishop, 4)]
        [DataRow(PieceType.Queen, 8)]
        [DataRow(PieceType.King, 8)]
        public void CheckNumberOfMoves(PieceType pieceType, int numberOfMoves)
        {
            var factory = new PieceFactory();
            var piece = factory.Get(pieceType);
            Assert.AreEqual(piece.ValidMoves.Count, numberOfMoves);
        }
    }
}
