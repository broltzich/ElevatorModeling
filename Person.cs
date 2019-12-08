using System;
using System.Collections.Generic;
using System.Text;

namespace ElevatorModeling
{
    public class Person
    {
        public int DepartureFloor { get; }
        public int ArrivalFLoor { get; }
        public Direction Direction => ArrivalFLoor > DepartureFloor ? Direction.Up : Direction.Down;

        public Person(int departureFloor, int arrivalFloor)
        {
            DepartureFloor = departureFloor;
            ArrivalFLoor = arrivalFloor;
        }

    }
}
