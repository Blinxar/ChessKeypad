using ChessKeypad.Models;
using ChessKeypad.Models.Enums;
using ChessKeypad.Models.Layouts;
using ChessKeypad.Models.Moves;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ChessKeypad.Tests
{
    [TestClass]
    public class MoveTests
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
            var start = new Coordinate(startX, startY);
            var proposedEnd = new Coordinate(endX, endY);
            var move = new SimpleMove(direction, distance, false);

            var end = move.Process(start);

            Assert.AreEqual(proposedEnd, end);
        }

        [TestMethod]
        public void TestCompoundMove()
        {
            var start = new Coordinate(5, 5);
            var move = new CompoundMove(new List<Move>()
            {
                new SimpleMove(Direction.UpLeft, 2, false),
                new SimpleMove(Direction.Up, 3, false)
            }, false);


            var end = move.Process(start);

            Assert.AreEqual(new Coordinate(3, 10), end);
        }

        [TestMethod]
        [DataRow(0, 0, Direction.Down, 1, false)]
        [DataRow(4, 2, Direction.Right, 1, false)]
        [DataRow(0, 0, Direction.Up, 1, true)]
        [DataRow(0, 0, Direction.UpLeft, 1, false)]
        public void TestValidMoves(int startX, int startY, Direction direction, int distance, bool valid)
        {
            var layout = new KeypadLayout();
            var start = new Coordinate(startX, startY);
            var move = new SimpleMove(direction, distance, false);

            var end = move.Process(start);
            var isMoveValid = layout.IsCoordinateValid(end);

            Assert.AreEqual(valid, isMoveValid);
        }
    }
}
