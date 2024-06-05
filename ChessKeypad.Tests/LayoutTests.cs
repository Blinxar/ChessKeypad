using ChessKeypad.Models.Layouts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit.Sdk;

namespace ChessKeypad.Tests;

[TestClass]
public class LayoutTests
{
    [TestMethod]
    [DataRow(0, 3, '1')]
    [DataRow(1, 3, '2')]
    [DataRow(2, 3, '3')]
    [DataRow(0, 2, '4')]
    [DataRow(1, 2, '5')]
    [DataRow(2, 2, '6')]
    [DataRow(0, 1, '7')]
    [DataRow(1, 1, '8')]
    [DataRow(2, 1, '9')]
    [DataRow(1, 0, '0')]
    [DataRow(0, 0, '*')]
    [DataRow(2, 0, '#')]
    public void LayoutGridReferenceCheck(int x, int y, char character)
    {
        var layout = new KeypadLayout();
        Assert.IsTrue(layout.Cells[new(x, y)].Character == character);
    }
}
