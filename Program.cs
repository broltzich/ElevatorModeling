using System;
using System.Collections.Generic;
using System.Threading;

namespace ElevatorModeling
{
    class Program
    {
        static void Main(string[] args)
        {
            var model = new ModelingController(new Elevator(4, 5));
            while(true)
            {
                Console.Clear();
                Console.WriteLine(model.DrawModel());
                //Thread.Sleep(10);
                model.Tick();
                Console.ReadKey();
            }
        }
    }
}
