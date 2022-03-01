using System;
using RubiksCube_MMc.Enums;

namespace RubiksCube_MMc.Model
{
    public class Square
    {
        Colour colour;
        (int, int) position;

        public Square(Colour colour)
        {
            this.colour = colour;
        }

        public char GetColour()
        {
            switch(colour)
            {
                case Colour.Orange:
                    return 'O';
                case Colour.Yellow:
                    return 'Y';
                case Colour.Green:
                    return 'G';
                case Colour.Blue:
                    return 'B';
                case Colour.Red:
                    return 'R';
                case Colour.White:
                    return 'W';
                default:
                    return 'N';
            }
        }
    }
}
