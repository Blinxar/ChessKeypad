using ChessKeypad.Factories;
using ChessKeypad.Models;
using ChessKeypad.Models.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit.Sdk;

namespace ChessKeypad.Tests
{
    [TestClass]
    public class LayoutTests
    {
        [TestMethod]
        [DataRow(0, 3, '1', ValidStatus.NotAtStart)]
        [DataRow(1, 3, '2', ValidStatus.Anywhere)]
        [DataRow(2, 3, '3', ValidStatus.Anywhere)]
        [DataRow(0, 2, '4', ValidStatus.Anywhere)]
        [DataRow(1, 2, '5', ValidStatus.Anywhere)]
        [DataRow(2, 2, '6', ValidStatus.Anywhere)]
        [DataRow(0, 1, '7', ValidStatus.Anywhere)]
        [DataRow(1, 1, '8', ValidStatus.Anywhere)]
        [DataRow(2, 1, '9', ValidStatus.Anywhere)]
        [DataRow(1, 0, '0', ValidStatus.NotAtStart)]
        [DataRow(0, 0, '*', ValidStatus.Nowhere)]
        [DataRow(2, 0, '#', ValidStatus.Nowhere)]
        public void LayoutGridReferenceCheck(int x, int y, char character, ValidStatus validStatus)
        {
            var factory = new LayoutFactory();
            var layout = factory.Get(LayoutType.PhoneKeypad);
            Assert.IsTrue(layout.Cells[new(x, y)] == new Cell(character, validStatus));
        }
    }
}
