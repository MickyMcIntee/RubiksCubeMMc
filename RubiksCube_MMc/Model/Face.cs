using System;
using System.Collections.Generic;
using RubiksCube_MMc.Enums;
using RubiksCube_MMc.Model;

namespace RubiksCube_MMc.Model
{
    public class Face
    {
        FaceEnum face;
        FaceEnum topNeighbour;
        FaceEnum bottomNeightbour;
        FaceEnum leftNeighbour;
        FaceEnum rightNeighbour;

        List<Square> squares;

        public Face(FaceEnum face, Colour colour)
        {
            squares = new List<Square>();
            this.face = face;

            SetUpNeighbours();
            
            var enums = Enum.GetValues(typeof(Colour));

            for(int i = 0; i < 3; i++)
            {
                for(int y = 0; y < 3; y++)
                {
                    squares.Add(new Square(colour));
                }
            }
        }

        public Face(FaceEnum face, List<Square> squaresToCopy)
        {
            this.face = face;
            squares = new List<Square>();
            foreach(var square in squaresToCopy)
            {
                squares.Add(square);
            }

            SetUpNeighbours();
        }

        public Square GetSquare(int index)
        {
            return squares[index];
        }

        public FaceEnum GetFace()
        {
            return face;
        }

        public void SetSquare(Square square, int index)
        {
            squares[index] = square;
        }

        public List<Square> GetSquares()
        {
            return squares;
        }

        public FaceEnum GetTopNeighbour()
        {
            return topNeighbour;
        }

        public FaceEnum GetBottomNeighbour()
        {
            return bottomNeightbour;
        }

        public FaceEnum GetLeftNeighbour()
        {
            return leftNeighbour;
        }

        public FaceEnum GetRightNeighbour()
        {
            return rightNeighbour;
        }

        public (Square, Square, Square) GetIndexTriplet((int, int, int) index)
        {
            return (squares[index.Item1], squares[index.Item2], squares[index.Item3]);
        }

        public void SetIndexTriplet((int, int, int) index, (Square, Square, Square) squareTriplet)
        {
            squares[index.Item1] = squareTriplet.Item1;
            squares[index.Item2] = squareTriplet.Item2;
            squares[index.Item3] = squareTriplet.Item3;
        }

        private void SetUpNeighbours()
        {
            switch (face)
            {
                case FaceEnum.Front:
                    topNeighbour = FaceEnum.Top;
                    bottomNeightbour = FaceEnum.Bottom;
                    leftNeighbour = FaceEnum.Left;
                    rightNeighbour = FaceEnum.Right;
                    break;
                case FaceEnum.Rear:
                    topNeighbour = FaceEnum.Top;
                    bottomNeightbour = FaceEnum.Bottom;
                    rightNeighbour = FaceEnum.Left;
                    leftNeighbour = FaceEnum.Right;
                    break;
                case FaceEnum.Top:
                    topNeighbour = FaceEnum.Left;
                    bottomNeightbour = FaceEnum.Right;
                    leftNeighbour = FaceEnum.Front;
                    rightNeighbour = FaceEnum.Rear;
                    break;
                case FaceEnum.Bottom:
                    topNeighbour = FaceEnum.Left;
                    bottomNeightbour = FaceEnum.Right;
                    leftNeighbour = FaceEnum.Rear;
                    rightNeighbour = FaceEnum.Left;
                    break;
                case FaceEnum.Left:
                    topNeighbour = FaceEnum.Top;
                    bottomNeightbour = FaceEnum.Bottom;
                    leftNeighbour = FaceEnum.Rear;
                    rightNeighbour = FaceEnum.Front;
                    break;
                case FaceEnum.Right:
                    topNeighbour = FaceEnum.Top;
                    bottomNeightbour = FaceEnum.Bottom;
                    leftNeighbour = FaceEnum.Front;
                    rightNeighbour = FaceEnum.Rear;
                    break;
            }

        }
    }
}
