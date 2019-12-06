using System;
using System.Collections.Generic;
using System.Text;

namespace ElevatorModeling
{
    class ModelingController
    {
        private int floors;
        private Elevator elevator;
        private List<Queue<Person>> queueList = new List<Queue<Person>>();

        public ModelingController(Elevator elevator, int floors)
        {
            this.elevator = elevator;
            this.floors = floors;

            for (int i = 0; i < floors; i++)
            {
                queueList.Add(new Queue<Person>());
            }
        }

        public void Tick()
        {

        }
    }
}
