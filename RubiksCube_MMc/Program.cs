using System;
using System.Configuration;
using RubiksCube_MMc.Model;
using RubiksCube_MMc.Enums;
using System.Collections.Generic;
using System.Text;

namespace RubiksCube_MMc
{
    static class MainClass
    {

        public static void Main(string[] args)
        {
            Cube cube = new Cube();

            string input = "";

            while (input != "0")
            {
                PrintMenu();
                input = Console.ReadLine();
                switch(input)
                {
                    case "1":
                        PrintFaceMenu();
                        input = Console.ReadLine();
                        switch(input)
                        {
                            case "1":
                                cube.RotateClockwise(FaceEnum.Front);
                                break;
                            case "2":
                                cube.RotateClockwise(FaceEnum.Rear);
                                break;
                            case "3":
                                cube.RotateClockwise(FaceEnum.Left);
                                break;
                            case "4":
                                cube.RotateClockwise(FaceEnum.Right);
                                break;
                            case "5":
                                cube.RotateClockwise(FaceEnum.Top);
                                break;
                            case "6":
                                cube.RotateClockwise(FaceEnum.Bottom);
                                break;
                            case "0":
                                input = "";
                                break;
                            default:
                                Console.WriteLine(ConfigurationManager.AppSettings["InvalidOperation"].ToString());
                                break;
                        }
                        break;
                    case "2":
                        PrintFaceMenu();
                        input = Console.ReadLine();
                        switch (input)
                        {
                            case "1":
                                cube.RotateAnticlockwise(FaceEnum.Front);
                                break;
                            case "2":
                                cube.RotateAnticlockwise(FaceEnum.Rear);
                                break;
                            case "3":
                                cube.RotateAnticlockwise(FaceEnum.Left);
                                break;
                            case "4":
                                cube.RotateAnticlockwise(FaceEnum.Right);
                                break;
                            case "5":
                                cube.RotateAnticlockwise(FaceEnum.Top);
                                break;
                            case "6":
                                cube.RotateAnticlockwise(FaceEnum.Bottom);
                                break;
                            case "0":
                                input = "";
                                break;
                            default:
                                Console.WriteLine(ConfigurationManager.AppSettings["InvalidOperation"].ToString());
                                break;
                        }
                        break;
                    case "3":
                        PrintCube(cube);
                        break;
                }
            }

            Console.WriteLine("Thank you for playing!");
        }

        private static void PrintMenu()
        {
            Console.Write(ConfigurationManager.AppSettings["Menu"].ToString());
        }

        private static void PrintFaceMenu()
        {
            Console.Write(ConfigurationManager.AppSettings["SideSelection"].ToString());
        }

        private static void PrintCube(Cube cube)
        {

            PrintFace(cube);

        }

        private static void PrintFace(Cube cube)
        {
            Face face = cube.GetFace(FaceEnum.Top);

            StringBuilder sb = new StringBuilder();
            sb.Append("   ");
            for (int i = 0; i < 3; i++)
            {
                sb.Append(face.GetSquare(i).GetColour());
            }
            sb.Append("\n   ");
            for (int i = 3; i < 6; i++)
            {
                sb.Append(face.GetSquare(i).GetColour());
            }
            sb.Append("\n   ");
            for (int i = 6; i < 9; i++)
            {
                sb.Append(face.GetSquare(i).GetColour());
            }

            sb.Append("\n");
            List<FaceEnum> list = new List<FaceEnum>() { FaceEnum.Left, FaceEnum.Front, FaceEnum.Right, FaceEnum.Rear };

            foreach(var item in list)
            {
                for(int i = 0; i < 3; i++)
                {
                    face = cube.GetFace(item);
                    sb.Append(face.GetSquare(i).GetColour());
                }
            }

            sb.Append("\n");

            foreach (var item in list)
            {
                for (int i = 3; i < 6; i++)
                {
                    face = cube.GetFace(item);
                    sb.Append(face.GetSquare(i).GetColour());
                }
            }

            sb.Append("\n");

            foreach (var item in list)
            {
                for (int i = 6; i < 9; i++)
                {
                    face = cube.GetFace(item);
                    sb.Append(face.GetSquare(i).GetColour());
                }
            }

            sb.Append("\n");

            face = cube.GetFace(FaceEnum.Bottom);

            sb.Append("   ");
            for (int i = 0; i < 3; i++)
            {
                sb.Append(face.GetSquare(i).GetColour());
            }
            sb.Append("\n   ");
            for (int i = 3; i < 6; i++)
            {
                sb.Append(face.GetSquare(i).GetColour());
            }
            sb.Append("\n   ");
            for (int i = 6; i < 9; i++)
            {
                sb.Append(face.GetSquare(i).GetColour());
            }

            sb.Append("\n\n");

            Console.Write(sb);
        }
    }
}
