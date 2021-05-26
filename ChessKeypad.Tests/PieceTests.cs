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
        [DataRow(ChessPiece.Pawn, 1)]
        [DataRow(ChessPiece.Rook, 4)]
        [DataRow(ChessPiece.Knight, 8)]
        [DataRow(ChessPiece.Bishop, 4)]
        [DataRow(ChessPiece.Queen, 8)]
        [DataRow(ChessPiece.King, 8)]
        public void CheckNumberOfMoves(ChessPiece pieceType, int numberOfMoves)
        {
            var factory = new ChessPieceFactory();
            var piece = factory.Get(pieceType);
            Assert.AreEqual(piece.ValidMoves.Count, numberOfMoves);
        }
    }
}
