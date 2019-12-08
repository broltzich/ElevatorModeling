using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElevatorModeling
{
    class ModelingController
    {
        private readonly Elevator _elevator;
        private readonly List<Queue<Person>> _queueList = new List<Queue<Person>>();
        private int[] _delivered;
        private int _total;
        private int _currentWaiting;

        public ModelingController(Elevator elevator)
        {
            _elevator = elevator;
            _delivered = new int[elevator.Floors];

            for (int i = 0; i < _elevator.Floors; i++)
            {
                _queueList.Add(new Queue<Person>());
            }
        }

        // All actions that happen on one system tick
        public void Tick()
        {
            GeneratePerson();

            if (_elevator.TryDislodge())
            {
                _delivered[_elevator.CurrentFloor - 1]++;
                _total++;
                return;
            }
            if (TryBoardPerson())
            {
                _currentWaiting--;
                return;
            }

            _elevator.Go();
        }

        public string DrawModel()
        {
            var len = _elevator.Draw().Length;
            var sb = new StringBuilder();

            sb.Append("(floor: delivered / waiting)\n");

            for (var i = _elevator.Floors; i > 0; i--)
            {
                sb.Append($"({i}: {_delivered[i - 1]} / {_queueList[i - 1].Count})");

                if (_elevator.CurrentFloor == i)
                {
                    sb.Append(_elevator.Draw());
                }
                else
                {
                    sb.Append(new string(' ', len));
                }

                sb.AppendLine(string.Join(" ", _queueList[i - 1].Select(p => p.ArrivalFLoor)));
            }

            sb.AppendLine(_elevator.Direction.ToString())
                .AppendLine($"total delivered: {_total}")
                .AppendLine($"currently waiting: {_currentWaiting}");
            return sb.ToString();
        }

        private void GeneratePerson()
        {
            var rnd = new Random(DateTime.Now.Millisecond);
            if (rnd.Next(100)  < 40)                                                                            // kind of chance that person will be generated ;
            {
                var departure = rnd.Next(1, _elevator.Floors + 1);
                var arrival = departure;

                while (departure == arrival)
                {
                    arrival = rnd.Next(1, _elevator.Floors + 1);
                }

                var generatedPerson = new Person(departure, arrival);
                _queueList[generatedPerson.DepartureFloor - 1].Enqueue(generatedPerson);
                _currentWaiting++;
            }
        }

        private bool TryBoardPerson()
        {
            var currentQueue = _queueList[_elevator.CurrentFloor - 1];
            
            if (!currentQueue.Any())
            {
                return false;
            }

            var currentQueuePeek = currentQueue.Peek();

            if (currentQueuePeek.Direction == _elevator.Direction && _elevator.TryAddPerson(currentQueuePeek))
            {
                currentQueue.Dequeue();
                return true;
            }
            return false;
        }
    }

    public enum Direction
    {
        Up,
        Down
    }
}
