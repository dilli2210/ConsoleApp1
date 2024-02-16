using ConsoleApp1.BusinessLayer;
using ConsoleApp1.Enum;
using ConsoleApp1.Interface;
using System;


namespace ToyRobotSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            IToyRobot robot = new ToyRobot();
            Console.WriteLine("Give Origin Max  values 5 for X & Y \n F -> DIRECTIOS");
            Console.WriteLine("Enter a command (PLACE X,Y,F):");
            string input = Console.ReadLine().Trim().ToUpper();
            int i = 0;
            bool isMoved = false;
            while (true)
            {

                string[] commandParts = input.Split(' ');

                if (commandParts.Length == 2)
                {
                    if (commandParts[0] == "PLACE" && i == 0)
                    {
                        string[] placeParams = commandParts[1].Split(',');

                        if (placeParams.Length == 3 && int.TryParse(placeParams[0], out int x) && int.TryParse(placeParams[1], out int y))
                        {
                            Direction direction;
                            if (Enum.TryParse(placeParams[2], true, out direction))
                            {
                                robot.Place(x, y, direction);
                                i++;
                            }
                            else
                            {
                                Console.WriteLine("Invalid direction.");
                                Console.WriteLine("Enter a command (PLACE X,Y,F):");
                                input = Console.ReadLine().Trim().ToUpper();

                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid parameters must gives values for X,Y and F.");
                            Console.WriteLine("Enter a command (PLACE X,Y,F):");
                            input = Console.ReadLine().Trim().ToUpper();

                        }
                    }


                    if (i == 1)
                    {
                        Console.WriteLine("Enter a command (PLACE X,Y,F | MOVE | LEFT | RIGHT | EXIT):");
                        string inputs = Console.ReadLine().Trim().ToUpper();
                        if (inputs == "EXIT")
                        {
                            break;
                        }
                        string[] commandPart = inputs.Split(' ');
                        switch (commandPart[0])
                        {
                            case "PLACE":
                                if (commandPart.Length == 2)
                                {
                                    string[] placeParams = commandPart[1].Split(',');
                                    if (placeParams.Length == 3 && int.TryParse(placeParams[0], out int x) && int.TryParse(placeParams[1], out int y))
                                    {
                                        Direction direction;
                                        if (Enum.TryParse(placeParams[2], true, out direction))
                                        {
                                            robot.Place(x, y, direction);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid direction.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid parameters for PLACE command.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid parameters for PLACE command.");
                                }
                                break;
                            case "MOVE":
                                isMoved = robot.Move();
                                Console.WriteLine(robot.Report(isMoved));
                                break;
                            case "LEFT":
                                robot.Left();
                                Console.WriteLine(robot.Report(true));
                                break;
                            case "RIGHT":
                                robot.Right();
                                Console.WriteLine(robot.Report(true));
                                break;
                            default:
                                Console.WriteLine("Invalid command.");
                                break;
                        }

                    }

                }
                else
                {
                    Console.WriteLine("Invalid parameters for PLACE command. Ex PLACE 0,0,NORTH");
                    Console.WriteLine("Enter a command (PLACE X,Y,F):");
                    input = Console.ReadLine().Trim().ToUpper();
                }

            }
        }
    }


}
