using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Injuries
{
    internal class Detail
    {
        public int From { get; }
        public int Till { get; }
        public string Description { get; }

        public Statistic Result { get; }

        public Detail(int from, string description, Durations duration, Statistic statistic) : this(from, from, description, duration, statistic)
        {
        }

        public Durations Duration { get; }

        public Detail(int from, int till, string description, Durations duration, Statistic statistic)
        {
            From = from;
            Till = till;
            Description = description;
        }
    }
}