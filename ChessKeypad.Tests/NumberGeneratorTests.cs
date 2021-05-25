using ChessKeypad.Factories;
using ChessKeypad.Managers;
using ChessKeypad.Models.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessKeypad.Tests
{
    [TestClass]
    public class NumberGeneratorTests
    {
        [TestMethod]
        [DataRow(LayoutType.TwoByTwo, PieceType.Knight, 2, 0)]
        [DataRow(LayoutType.TwoByTwo, PieceType.Bishop, 2, 4)]
        [DataRow(LayoutType.TwoByTwo, PieceType.Rook, 2, 8)]
        [DataRow(LayoutType.PhoneKeypad, PieceType.Pawn, 2, 6)]
        [DataRow(LayoutType.PhoneKeypad, PieceType.Rook, 2, 35)]
        [DataRow(LayoutType.PhoneKeypad, PieceType.Bishop, 2, 20)]
        [DataRow(LayoutType.PhoneKeypad, PieceType.Knight, 2, 16)]
        [DataRow(LayoutType.PhoneKeypad, PieceType.Pawn, 3, 3)]
        [DataRow(LayoutType.PhoneKeypad, PieceType.Bishop, 3, 49)]
        [DataRow(LayoutType.PhoneKeypad, PieceType.King, 2, 40)]
        [DataRow(LayoutType.PhoneKeypad, PieceType.Pawn, 7, 0)]
        [DataRow(LayoutType.PhoneKeypad, PieceType.Rook, 7, 49326)]
        public void PermutationsTest(LayoutType layoutType, PieceType pieceType, int numberOfDigits, int expectedPermutations)
        {
            var layoutFactory = new LayoutFactory();
            var layout = layoutFactory.Get(layoutType);
            var pieceFactory = new PieceFactory();
            var piece = pieceFactory.Get(pieceType);

            var numberGenerator = new NumberGenerator();

            var permutations = numberGenerator.CalculatePermutations(layout, piece, numberOfDigits);

            Assert.AreEqual(expectedPermutations, permutations);
        }
    }
}
