using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Injuries
{
    public class Dead
    {
        public int From { get; } = 11;

        public int Till { get; } = 15;

        public string Description { get; } = "Remove From Roster";
    }
}