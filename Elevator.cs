using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ElevatorModeling
{
    public class Elevator
    {
        private int capacity;
        private int floors;
        private int currentFloor = 1;

        public List<Person> elevatorParty = new List<Person>();

        public Elevator(int capacity, int floors)
        {
            this.capacity = capacity;
            this.floors = floors;
        }

        public void GoUp()
        {
            if (currentFloor < floors)
            {
                Thread.Sleep(1000);
                currentFloor += 1;
            }
        }

        public void GoDown()
        {
            if (currentFloor > 1)
            {
                Thread.Sleep(1000);
                currentFloor -= 1;
            }
        }
        public void Dislodge()
        {
            foreach (var person in elevatorParty)
            {
                if (person.ArrivalFLoor == currentFloor)
                {
                    Thread.Sleep(1000);
                    elevatorParty.Remove(person);
                }
            }
        }

        public void AddPerson(Person person)
        {
            if (elevatorParty.Count < capacity)
            {
                Thread.Sleep(1000);
                elevatorParty.Add(person);
            }
        }
    }
    
}
