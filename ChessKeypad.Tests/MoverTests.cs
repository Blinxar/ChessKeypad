using ChessKeypad.Factories;
using ChessKeypad.Managers;
using ChessKeypad.Models;
using ChessKeypad.Models.Enums;
using ChessKeypad.Models.Moves;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ChessKeypad.Tests
{
    [TestClass]
    public class MoverTests
    {
        [TestMethod]
        [DataRow(5, 5, Direction.Up, 1, 5, 6)]
        [DataRow(5, 5, Direction.Down, 1, 5, 4)]
        [DataRow(5, 5, Direction.Left, 1, 4, 5)]
        [DataRow(5, 5, Direction.Right, 1, 6, 5)]
        [DataRow(5, 5, Direction.UpLeft, 1, 4, 6)]
        [DataRow(5, 5, Direction.UpRight, 1, 6, 6)]
        [DataRow(5, 5, Direction.DownLeft, 1, 4, 4)]
        [DataRow(5, 5, Direction.DownRight, 1, 6, 4)]
        public void FixedMovesShouldMoveInCorrectDirection(int startX, int startY, Direction direction, int distance, int endX, int endY)
        {
            var mover = new Mover();
            var start = new Coordinate(startX, startY);
            var proposedEnd = new Coordinate(endX, endY);
            var move = new FixedMove(direction, distance);

            var end = mover.ProcessMove(move, start);

            Assert.AreEqual(proposedEnd, end);
        }

        [TestMethod]
        public void TestCompoundMove()
        {
            var mover = new Mover();
            var start = new Coordinate(5, 5);
            var move = new FixedCompoundMove(new List<Move>()
            {
                new FixedMove(Direction.UpLeft, 2),
                new FixedMove(Direction.Up, 3)
            });


            var end = mover.ProcessMove(move, start);

            Assert.AreEqual(new Coordinate(3, 10), end);
        }

        [TestMethod]
        [DataRow(LayoutType.PhoneKeypad, 0, 0, Direction.Down, 1, false)]
        [DataRow(LayoutType.PhoneKeypad, 4, 2, Direction.Right, 1, false)]
        [DataRow(LayoutType.PhoneKeypad, 0, 0, Direction.Up, 1, true)]
        [DataRow(LayoutType.PhoneKeypad, 0, 0, Direction.UpLeft, 1, false)]
        public void TestValidMoves(LayoutType layoutType, int startX, int startY, Direction direction, int distance, bool valid)
        {
            var mover = new Mover();
            var layoutFactory = new LayoutFactory();

            var layout = layoutFactory.Get(layoutType);
            var start = new Coordinate(startX, startY);
            var move = new FixedMove(direction, distance);

            var isMoveValid = mover.IsMoveValid(layout, move, start, out var end);

            Assert.AreEqual(valid, isMoveValid);
        }
    }
}
