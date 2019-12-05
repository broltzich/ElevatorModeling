using System;
using System.Collections.Generic;
using System.Text;

namespace ElevatorModeling
{
    public class Person
    {
        private int _departureFloor;
        private int _arrivalFloor;

        public int DepartureFloor => _departureFloor;
        public int ArrivalFLoor => _arrivalFloor;

        public Person(int departureFloor, int arrivalFloor)
        {
            _departureFloor = departureFloor;
            _arrivalFloor = arrivalFloor;
        }

    }
}
