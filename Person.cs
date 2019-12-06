using System;
using System.Collections.Generic;
using System.Text;

namespace ElevatorModeling
{
    public class Person
    {
        private int departureFloor;
        private int arrivalFloor;
        

        public int DepartureFloor => departureFloor;
        public int ArrivalFLoor => arrivalFloor;

        public Person(int departureFloor, int arrivalFloor)
        {
            this.departureFloor = departureFloor;
            this.arrivalFloor = arrivalFloor;
        }

    }
}
