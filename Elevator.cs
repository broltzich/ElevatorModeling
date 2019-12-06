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
                currentFloor += 1;
            }
        }

        public void GoDown()
        {
            if (currentFloor > 1)
            {
                currentFloor -= 1;
            }
        }
        public void Dislodge()
        {
            foreach (var person in elevatorParty)
            {
                if (person.ArrivalFLoor == currentFloor)
                {
                    elevatorParty.Remove(person);
                }
            }
        }

        public void AddPerson(Person person)
        {
            if (elevatorParty.Count < capacity)
            {
                elevatorParty.Add(person);
            }
        }
    }

    public enum ElevatorState
    {
        Waiting,
        GoingUp,
        GoingDown
    }
    
}
