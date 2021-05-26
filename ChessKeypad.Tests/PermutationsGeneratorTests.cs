using ChessKeypad.Factories;
using ChessKeypad.Managers;
using ChessKeypad.Models.Enums;
using ChessKeypad.Models.Layouts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessKeypad.Tests
{
    [TestClass]
    public class PermutationsGeneratorTests
    {
        [TestMethod]
        [DataRow(ChessPiece.Pawn, 2, 6)]
        [DataRow(ChessPiece.Rook, 2, 35)]
        [DataRow(ChessPiece.Bishop, 2, 20)]
        [DataRow(ChessPiece.Knight, 2, 16)]
        [DataRow(ChessPiece.Pawn, 3, 3)]
        [DataRow(ChessPiece.Bishop, 3, 49)]
        [DataRow(ChessPiece.King, 2, 40)]
        [DataRow(ChessPiece.Pawn, 7, 0)]
        [DataRow(ChessPiece.Rook, 7, 49326)]
        [DataRow(ChessPiece.Knight, 7, 952)]
        [DataRow(ChessPiece.Bishop, 7, 2341)]
        [DataRow(ChessPiece.Queen, 7, 751503)]
        [DataRow(ChessPiece.King, 7, 124908)]
        public void PermutationsTest(ChessPiece pieceType, int numberOfDigits, int expectedPermutations)
        {
            var layout = new KeypadLayout();
            var pieceFactory = new ChessPieceFactory();
            var piece = pieceFactory.Get(pieceType);

            var numberGenerator = new PermutationsGenerator();

            var permutations = numberGenerator.CalculatePermutations(layout, piece, numberOfDigits);

            Assert.AreEqual(expectedPermutations, permutations);
        }

        [DataRow(ChessPiece.Knight, 2, 0)]
        [DataRow(ChessPiece.Bishop, 2, 4)]
        [DataRow(ChessPiece.Rook, 2, 8)]
        public void TwoByTwoTests(ChessPiece pieceType, int numberOfDigits, int expectedPermutations)
        {
            var layout = new TwoByTwoLayout();
            var pieceFactory = new ChessPieceFactory();
            var piece = pieceFactory.Get(pieceType);

            var numberGenerator = new PermutationsGenerator();

            var permutations = numberGenerator.CalculatePermutations(layout, piece, numberOfDigits);

            Assert.AreEqual(expectedPermutations, permutations);
        }
    }
}
