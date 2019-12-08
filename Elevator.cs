using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ElevatorModeling
{
    public class Elevator
    {
        private readonly int _capacity;
        private readonly List<Person> _persons = new List<Person>();

        public int Floors { get; }
        public int CurrentFloor { get; private set; } = 1;
        public bool IsFull => _persons.Count == _capacity;
        public Direction Direction { get; set; } = Direction.Up;


        public Elevator(int capacity, int floors)
        {
            _capacity = capacity;
            Floors = floors;
        }

        public void Go()
        {
            switch (Direction)
            {
                case Direction.Up:
                    if (CurrentFloor < Floors)
                    {
                        if (++CurrentFloor == Floors)
                        {
                            Direction = Direction.Down;
                        }
                    }
                    break;
                case Direction.Down:
                    if (CurrentFloor > 1)
                    {
                        if (--CurrentFloor == 1)
                        {
                            Direction = Direction.Up;
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        public bool TryDislodge()
        {
            var dislodged = _persons.FirstOrDefault(p => p.ArrivalFLoor == CurrentFloor);

            if (dislodged == null)
            {
                return false;
            }

            _persons.Remove(dislodged);

            return true;
        }

        public bool TryAddPerson(Person person)
        {
            if (_persons.Count < _capacity)
            {
                _persons.Add(person);
                return true;
            }

            return false;

        }

        public string Draw()
        {
            var sb = new StringBuilder("[ ");

            foreach(var person in _persons)
            {
                sb.Append(person.ArrivalFLoor).Append(" ");
            }

            for (int i = 0; i < _capacity - _persons.Count; i++)
            {
                sb.Append("* ");
            }

            sb.Append("]");

            return sb.ToString();
        }

    }

    

}
