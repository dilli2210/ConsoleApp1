using ConsoleApp1.Enum;
using ConsoleApp1.Interface;

namespace ConsoleApp1.BusinessLayer
{
    public class ToyRobot : IToyRobot
    {
        private int x;
        private int y;
        private Direction facing;


        public void Place(int x, int y, Direction facing)
        {
  
            if (IsValidPosition(x, y))
            {
                this.x = x;
                this.y = y;
                this.facing = facing;

            }
            else
            {
                Console.WriteLine("Invalid placement. The robot must be placed within the tabletop boundaries.");
            }
        }

        public void Move()
        {
            switch (facing)
            {
                case Direction.NORTH:
                    if (IsValidPosition(x, y + 1))
                        y++;
                    break;
                case Direction.EAST:
                    if (IsValidPosition(x + 1, y))
                        x++;
                    break;
                case Direction.SOUTH:
                    if (IsValidPosition(x, y - 1))
                        y--;
                    break;
                case Direction.WEST:
                    if (IsValidPosition(x - 1, y))
                        x--;
                    break;
            }
        }

        public void Left()
        {
            facing = (Direction)(((int)facing + 3) % 4);
        }

        public void Right()
        {
            facing = (Direction)(((int)facing + 1) % 4);
        }

        public string Report()
        { 
         if(facing == Direction.NORTH && x == 4 && y == 0)
            {
                return $"REPORT \n Output: {x},{y},{facing} ,{"ROBOT AT THE EDGE OF TABLE SO PLEASE CHOOSE LEFT OR RIGHT TO MOVE "}";
            }
         else if(facing == Direction.EAST && x == 4 && y == 0)
            {
                return $"REPORT \n Output: {x},{y},{facing} ,{"ROBOT AT THE EDGE OF TABLE SO PLEASE CHOOSE LEFT OR RIGHT TO MOVE "}";
            }
            else if (facing == Direction.SOUTH && x == 0 && y == 0)
            {
                return $"REPORT \n Output: {x},{y},{facing} ,{"ROBOT AT THE EDGE OF TABLE SO PLEASE CHOOSE LEFT OR RIGHT TO MOVE "}";
            }
            else if (facing == Direction.WEST && x == 0 && y == 0)
            {
                return $"REPORT \n Output: {x},{y},{facing} ,{"ROBOT AT THE EDGE OF TABLE SO PLEASE CHOOSE LEFT OR RIGHT TO MOVE "}";
            }
            return $" REPORT \n Output: {x},{y},{facing}";       
        }

        private bool IsValidPosition(int x, int y)
        {
            return x >= 0 && x < 5 && y >= 0 && y < 5;
        }

    }
}
