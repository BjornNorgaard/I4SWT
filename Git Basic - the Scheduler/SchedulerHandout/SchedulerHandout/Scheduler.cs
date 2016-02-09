using System;
using System.Collections.Generic;
using System.Linq;

namespace SchedulerHandout
{
    // Provided implementation of a Scheduler - contains constructor, Spawn() and the Priority enum
    public class Scheduler
    {
        public enum Priority
        {
            High,
            Med,
            Low
        };

        private readonly List<string>[] _threads;

        public Scheduler()
        {
            _threads = new List<string>[Enum.GetNames(typeof (Priority)).Length]; // Create threads array
            for (var i = 0; i < _threads.Count(); i++)
            {
                _threads[i] = new List<string>();
            }
        }

        public void Spawn(string name, Priority priority)
        {
            for (var i = 0; i < Enum.GetNames(typeof (Priority)).Length; i++)
            {
                for (var j = 0; j < _threads[i].Count; j++)
                {
                    if (_threads[i][j] == name)
                    {
                        // Need error handling here!
                    }
                }
            }
            _threads[(int) priority].Add(name);

        }
    }
}
