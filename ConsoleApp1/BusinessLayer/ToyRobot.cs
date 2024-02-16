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

        public bool Move()
        {
            bool move = false;
            if(facing == Direction.NORTH)
            {
                if (move = IsValidPosition(x, y + 1))
                {
                    y++;
                }
                    
            }
            else if(facing == Direction.EAST)
            {
                if (move = IsValidPosition(x + 1, y))
                {
                    x++;
                }
                   
            }
            else if (facing == Direction.SOUTH)
            {
                if (move = IsValidPosition(x, y - 1))
                {
                    y--;
                }

            }
            else if (facing == Direction.WEST)
            {
                if (move = IsValidPosition(x - 1, y))
                {
                    x--;
                }

            }

            return move;

        }

        public void Left()
        {
            facing = (Direction)(((int)facing + 3) % 4);
        }

        public void Right()
        {
            facing = (Direction)(((int)facing + 1) % 4);
        }

        public string Report(bool report)
        { 
         if(!report)
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
