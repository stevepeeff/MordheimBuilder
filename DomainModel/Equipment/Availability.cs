using DomainModel.Warbands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Equipment
{
    public class Availability
    {
        private Type type;

        public Availabilities AvailabilityRoll { get; }

        public IReadOnlyList<IWarBand> ProperNAme { get; }

        public Availability(Availabilities availability)
        {
            AvailabilityRoll = availability;
        }

        public void AddException(Availabilities availability, List<Type> types)
        {
        }

        public Availability(Availabilities availability, Type type) : this(availability)
        {
            this.type = type;
        }

        public Availability(Availabilities availability, List<Type> types) : this(availability)
        {
            //    this.type = type;
        }
    }
}