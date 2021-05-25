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
        public void TestInvalidLocationsOnPhoneKeypad()
        {
            var factory = new LayoutFactory();
            var layout = factory.Get(LayoutType.PhoneKeypad);

            Assert.IsTrue(layout.Cells[new(0, 0)] == new Cell('*', ValidStatus.Nowhere));
            Assert.IsTrue(layout.Cells[new(2, 0)] == new Cell('#', ValidStatus.Nowhere));
        }

        [TestMethod]
        public void TestValidLocationsOnPhoneKeypad()
        {
            var factory = new LayoutFactory();
            var layout = factory.Get(LayoutType.PhoneKeypad);

            Assert.IsTrue(layout.Cells[new(0, 3)] == new Cell('1', ValidStatus.NotAtStart));
            Assert.IsTrue(layout.Cells[new(1, 3)] == new Cell('2', ValidStatus.Anywhere));
            Assert.IsTrue(layout.Cells[new(2, 3)] == new Cell('3', ValidStatus.Anywhere));
            Assert.IsTrue(layout.Cells[new(0, 2)] == new Cell('4', ValidStatus.Anywhere));
            Assert.IsTrue(layout.Cells[new(1, 2)] == new Cell('5', ValidStatus.Anywhere));
            Assert.IsTrue(layout.Cells[new(2, 2)] == new Cell('6', ValidStatus.Anywhere));
            Assert.IsTrue(layout.Cells[new(0, 1)] == new Cell('7', ValidStatus.Anywhere));
            Assert.IsTrue(layout.Cells[new(1, 1)] == new Cell('8', ValidStatus.Anywhere));
            Assert.IsTrue(layout.Cells[new(2, 1)] == new Cell('9', ValidStatus.Anywhere));
            Assert.IsTrue(layout.Cells[new(1, 0)] == new Cell('0', ValidStatus.NotAtStart));
        }
    }
}
