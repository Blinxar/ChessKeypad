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
        public void PawnShouldNotHaveAnyPermutationsFor7DigitNumbers()
        {
            var layoutFactory = new LayoutFactory();
            var layout = layoutFactory.Get(LayoutType.PhoneKeypad);
            var pieceFactory = new PieceFactory();
            var piece = pieceFactory.Get(PieceType.Pawn);

            var numberGenerator = new NumberGenerator();

            var permutations = numberGenerator.CalculatePermutations(layout, piece, 7);

            Assert.AreEqual(0, permutations);
        }

        [TestMethod]
        public void PawnShouldHave6PermutationsFor2DigitNumbers()
        {
            var layoutFactory = new LayoutFactory();
            var layout = layoutFactory.Get(LayoutType.PhoneKeypad);
            var pieceFactory = new PieceFactory();
            var piece = pieceFactory.Get(PieceType.Pawn);

            var numberGenerator = new NumberGenerator();

            var permutations = numberGenerator.CalculatePermutations(layout, piece, 2);

            Assert.AreEqual(6, permutations);
        }

        [TestMethod]
        public void RookShouldHave8PermutationsFor2DigitsOn2By2Grid()
        {
            var layoutFactory = new LayoutFactory();
            var layout = layoutFactory.Get(LayoutType.TwoByTwo);
            var pieceFactory = new PieceFactory();
            var piece = pieceFactory.Get(PieceType.Rook);

            var numberGenerator = new NumberGenerator();

            var permutations = numberGenerator.CalculatePermutations(layout, piece, 2);

            Assert.AreEqual(8, permutations);
        }

        [TestMethod]
        public void BishopShouldHave4PermutationsFor2DigitsOn2By2Grid()
        {
            var layoutFactory = new LayoutFactory();
            var layout = layoutFactory.Get(LayoutType.TwoByTwo);
            var pieceFactory = new PieceFactory();
            var piece = pieceFactory.Get(PieceType.Bishop);

            var numberGenerator = new NumberGenerator();

            var permutations = numberGenerator.CalculatePermutations(layout, piece, 2);

            Assert.AreEqual(4, permutations);
        }

        [TestMethod]
        public void KnightShouldHaveNoPermutationsFor2DigitsOn2By2Grid()
        {
            var layoutFactory = new LayoutFactory();
            var layout = layoutFactory.Get(LayoutType.TwoByTwo);
            var pieceFactory = new PieceFactory();
            var piece = pieceFactory.Get(PieceType.Knight);

            var numberGenerator = new NumberGenerator();

            var permutations = numberGenerator.CalculatePermutations(layout, piece, 2);

            Assert.AreEqual(0, permutations);
        }

        [TestMethod]
        public void RookShouldHavePermutationsFor7DigitsOn()
        {
            var layoutFactory = new LayoutFactory();
            var layout = layoutFactory.Get(LayoutType.PhoneKeypad);
            var pieceFactory = new PieceFactory();
            var piece = pieceFactory.Get(PieceType.Rook);

            var numberGenerator = new NumberGenerator();

            var permutations = numberGenerator.CalculatePermutations(layout, piece, 7);

            Assert.AreEqual(0, permutations);
        }
    }
}
