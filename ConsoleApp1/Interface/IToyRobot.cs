using ConsoleApp1.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Interface
{
    public interface IToyRobot
    {
        void Place(int x, int y, Direction facing);
        bool Move();
        void Left();
        void Right();
        string Report(bool report);
    }
}
