using System;
using System.Collections.Generic;
using RubiksCube_MMc.Enums;
using System.Configuration;

namespace RubiksCube_MMc.Model
{
    public class Cube
    {
        Dictionary<FaceEnum, Face> faces;

        public Cube()
        {
            faces = new Dictionary<FaceEnum, Face>();
            faces.Add(FaceEnum.Front, new Face(FaceEnum.Front, Colour.Orange));
            faces.Add(FaceEnum.Rear, new Face(FaceEnum.Rear, Colour.Red));
            faces.Add(FaceEnum.Top, new Face(FaceEnum.Top, Colour.Yellow));
            faces.Add(FaceEnum.Bottom, new Face(FaceEnum.Bottom, Colour.White));
            faces.Add(FaceEnum.Left, new Face(FaceEnum.Left, Colour.Green));
            faces.Add(FaceEnum.Right, new Face(FaceEnum.Right, Colour.Blue));
        }

        public void RotateClockwise(FaceEnum side)
        {
            switch(side)
            {
                case FaceEnum.Front:
                    RotateFaceClockwise(FaceEnum.Front);
                    Console.WriteLine(ConfigurationManager.AppSettings["RotateFront90"].ToString());
                    break;
                case FaceEnum.Rear:
                    RotateFaceClockwise(FaceEnum.Rear);
                    Console.WriteLine(ConfigurationManager.AppSettings["RotateRear90"].ToString());
                    break;
                case FaceEnum.Top:
                    RotateFaceClockwise(FaceEnum.Top);
                    Console.WriteLine(ConfigurationManager.AppSettings["RotateTop90"].ToString());
                    break;
                case FaceEnum.Bottom:
                    RotateFaceClockwise(FaceEnum.Bottom);
                    Console.WriteLine(ConfigurationManager.AppSettings["RotateBottom90"].ToString());
                    break;
                case FaceEnum.Left:
                    RotateFaceClockwise(FaceEnum.Left);
                    Console.WriteLine(ConfigurationManager.AppSettings["RotateLeft90"].ToString());
                    break;
                case FaceEnum.Right:
                    RotateFaceClockwise(FaceEnum.Right);
                    Console.WriteLine(ConfigurationManager.AppSettings["RotateRight90"].ToString());
                    break;
                default:
                    Console.WriteLine(ConfigurationManager.AppSettings["InvalidOperation"].ToString());
                    break;
            }
        }

        public void RotateAnticlockwise(FaceEnum side)
        {
            switch(side)
            {
                case FaceEnum.Front:
                    RotateFaceAntiClockwise(FaceEnum.Front);
                    Console.WriteLine(ConfigurationManager.AppSettings["RotateFrontAnti90"].ToString());
                    break;
                case FaceEnum.Rear:
                    RotateFaceAntiClockwise(FaceEnum.Rear);
                    Console.WriteLine(ConfigurationManager.AppSettings["RotateRearAnti90"].ToString());
                    break;
                case FaceEnum.Top:
                    RotateFaceAntiClockwise(FaceEnum.Top);
                    Console.WriteLine(ConfigurationManager.AppSettings["RotateTopAnti90"].ToString());
                    break;
                case FaceEnum.Bottom:
                    RotateFaceAntiClockwise(FaceEnum.Bottom);
                    Console.WriteLine(ConfigurationManager.AppSettings["RotateBottomAnti90"].ToString());
                    break;
                case FaceEnum.Left:
                    RotateFaceAntiClockwise(FaceEnum.Left);
                    Console.WriteLine(ConfigurationManager.AppSettings["RotateLeftAnti90"].ToString());
                    break;
                case FaceEnum.Right:
                    RotateFaceAntiClockwise(FaceEnum.Right);
                    Console.WriteLine(ConfigurationManager.AppSettings["RotateRightAnti90"].ToString());
                    break;
                default:
                    Console.WriteLine(ConfigurationManager.AppSettings["InvalidOperation"].ToString());
                    break;
            }
        }

        public Face GetFace(FaceEnum face)
        {
            return faces[face];
        }

        public void SetFace(FaceEnum faceenum, Face face)
        {
            faces[faceenum] = face;
        }

        public void RotateFaceClockwise(FaceEnum faceenum)
        {
            Face face = faces[faceenum];
            Face updatedFace = new Face(faceenum, face.GetSquares());

            updatedFace.SetSquare(face.GetSquare(6), 0);
            updatedFace.SetSquare(face.GetSquare(3), 1);
            updatedFace.SetSquare(face.GetSquare(0), 2);
            updatedFace.SetSquare(face.GetSquare(7), 3);
            updatedFace.SetSquare(face.GetSquare(1), 5);
            updatedFace.SetSquare(face.GetSquare(8), 6);
            updatedFace.SetSquare(face.GetSquare(5), 7);
            updatedFace.SetSquare(face.GetSquare(2), 8);

            SetFace(faceenum, updatedFace);

            Dictionary<Neighbours, (int, int, int)> mapping = GetMapping(faceenum);
            Face topFace = faces[face.GetTopNeighbour()];
            var topSquares = topFace.GetIndexTriplet(mapping[Neighbours.Top]);

            Face rightFace = faces[face.GetRightNeighbour()];
            var rightSquares = rightFace.GetIndexTriplet(mapping[Neighbours.Right]);
            rightFace.SetIndexTriplet(mapping[Neighbours.Right], topSquares);

            Face bottomFace = faces[face.GetBottomNeighbour()];
            var bottomSquares = bottomFace.GetIndexTriplet(mapping[Neighbours.Bottom]);
            bottomFace.SetIndexTriplet(mapping[Neighbours.Bottom], rightSquares);

            Face leftFace = faces[face.GetLeftNeighbour()];
            var leftSquares = leftFace.GetIndexTriplet(mapping[Neighbours.Left]);
            leftFace.SetIndexTriplet(mapping[Neighbours.Left], bottomSquares);

            topFace.SetIndexTriplet(mapping[Neighbours.Top], leftSquares);

        }

        public void RotateFaceAntiClockwise(FaceEnum faceenum)
        {
            Face face = faces[faceenum];
            Face updatedFace = new Face(faceenum, face.GetSquares());

            updatedFace.SetSquare(face.GetSquare(0), 6);
            updatedFace.SetSquare(face.GetSquare(1), 3);
            updatedFace.SetSquare(face.GetSquare(2), 0);
            updatedFace.SetSquare(face.GetSquare(3), 7);
            updatedFace.SetSquare(face.GetSquare(5), 1);
            updatedFace.SetSquare(face.GetSquare(6), 8);
            updatedFace.SetSquare(face.GetSquare(7), 5);
            updatedFace.SetSquare(face.GetSquare(8), 2);

            SetFace(faceenum, updatedFace);

            Dictionary<Neighbours, (int, int, int)> mapping = GetMapping(faceenum);
            Face topFace = faces[face.GetTopNeighbour()];
            var topSquares = topFace.GetIndexTriplet(mapping[Neighbours.Top]);

            Face leftFace = faces[face.GetLeftNeighbour()];
            var leftSquares = leftFace.GetIndexTriplet(mapping[Neighbours.Left]);
            leftFace.SetIndexTriplet(mapping[Neighbours.Left], topSquares);

            Face bottomFace = faces[face.GetBottomNeighbour()];
            var bottomSquares = bottomFace.GetIndexTriplet(mapping[Neighbours.Bottom]);
            bottomFace.SetIndexTriplet(mapping[Neighbours.Bottom], leftSquares);

            Face rightFace = faces[face.GetRightNeighbour()];
            var rightSquares = rightFace.GetIndexTriplet(mapping[Neighbours.Right]);
            rightFace.SetIndexTriplet(mapping[Neighbours.Right], bottomSquares);

            topFace.SetIndexTriplet(mapping[Neighbours.Top], rightSquares);
        }

        public Dictionary<Neighbours, (int, int, int)> GetMapping(FaceEnum faceEnum)
        {
            Dictionary<Neighbours, (int, int, int)> dict = new Dictionary<Neighbours, (int, int, int)>();
            switch (faceEnum)
            {
                case FaceEnum.Front:
                    dict.Add(Neighbours.Top, (6, 7, 8));
                    dict.Add(Neighbours.Bottom, (2, 1, 0));
                    dict.Add(Neighbours.Left, (8, 5, 2));
                    dict.Add(Neighbours.Right, (0, 3, 6));
                    return dict;
                default:
                    dict.Add(Neighbours.Top, (0, 1, 2));
                    dict.Add(Neighbours.Bottom, (0, 1, 2));
                    dict.Add(Neighbours.Left, (0, 1, 2));
                    dict.Add(Neighbours.Right, (0, 1, 2));
                    return dict;
            }
        }
    }
}
