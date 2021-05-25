using ChessKeypad.Models;
using ChessKeypad.Models.Enums;

namespace ChessKeypad.Factories
{
    public class LayoutFactory
    {
        public Layout Get(LayoutType layoutType)
        {
            return layoutType switch
            {
                LayoutType.PhoneKeypad => GetTelephoneKeypadLayout(),
                LayoutType.TwoByTwo => Get2x2Layout(),
                _ => throw new System.NotImplementedException(),
            };
        }

        Layout GetTelephoneKeypadLayout()
        {
            return new Layout
            {
                Cells = new()
                {
                    { new(0, 0), new('*', ValidStatus.Nowhere) },
                    { new(1, 0), new('0', ValidStatus.NotAtStart) },
                    { new(2, 0), new('#', ValidStatus.Nowhere) },
                    { new(0, 1), new('7', ValidStatus.Anywhere) },
                    { new(1, 1), new('8', ValidStatus.Anywhere) },
                    { new(2, 1), new('9', ValidStatus.Anywhere) },
                    { new(0, 2), new('4', ValidStatus.Anywhere) },
                    { new(1, 2), new('5', ValidStatus.Anywhere) },
                    { new(2, 2), new('6', ValidStatus.Anywhere) },
                    { new(0, 3), new('1', ValidStatus.NotAtStart) },
                    { new(1, 3), new('2', ValidStatus.Anywhere) },
                    { new(2, 3), new('3', ValidStatus.Anywhere) },
                }
            };
        }

        Layout Get2x2Layout()
        {
            return new Layout
            {
                Cells = new()
                {
                    { new(0, 0), new('0', ValidStatus.Anywhere) },
                    { new(0, 1), new('1', ValidStatus.Anywhere) },
                    { new(1, 0), new('2', ValidStatus.Anywhere) },
                    { new(1, 1), new('3', ValidStatus.Anywhere) },
                }
            };
        }
    }
}
