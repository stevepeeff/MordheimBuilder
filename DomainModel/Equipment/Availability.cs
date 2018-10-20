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
        private List<Type> _Types;

        /// <summary>
        /// Initializes a new instance of the <see cref="Availability"/> class.
        /// </summary>
        /// <param name="availability">The availability.</param>
        public Availability(Availabilities availability)
        {
            AvailabilityRoll = availability;
        }

        /// <summary>
        /// Gets the availability roll.
        /// </summary>
        /// <value>
        /// The availability roll.
        /// </value>
        public Availabilities AvailabilityRoll { get; }

        /// <summary>
        /// Gets the exception availability roll.
        /// </summary>
        /// <value>
        /// The exception availability roll.
        /// </value>
        public Availabilities ExceptionAvailabilityRoll { get; private set; }

        public Availabilities GetException(IWarrior warrior)
        {
            if (Exceptions != null)
            {
                foreach (Type item in Exceptions)
                {
                    if (item.IsInterface && warrior.GetType().GetInterfaces().Any(x => x.Equals(item)))
                    {
                        return ExceptionAvailabilityRoll;
                    }
                    else if (item.Name.Equals(warrior.GetType().Name))
                    {
                        return ExceptionAvailabilityRoll;
                    }
                }
            }

            return AvailabilityRoll;
        }

        /// <summary>
        /// Gets the exceptions.
        /// </summary>
        /// <value>
        /// The exceptions.
        /// </value>
        public IReadOnlyList<Type> Exceptions => _Types;

        /// <summary>
        /// Adds the exception.
        /// </summary>
        /// <param name="exceptionAvailability">The exception availability.</param>
        /// <param name="types">The types.</param>
        public void AddException(Availabilities exceptionAvailability, List<Type> types)
        {
            ExceptionAvailabilityRoll = exceptionAvailability;

            if (_Types == null) { _Types = new List<Type>(); }
            _Types.AddRange(types);
        }

        /// <summary>
        /// Adds the exception.
        /// </summary>
        /// <param name="exceptionAvailability">The exception availability.</param>
        /// <param name="type">The type.</param>
        public void AddException(Availabilities exceptionAvailability, Type type)
        {
            ExceptionAvailabilityRoll = exceptionAvailability;

            if (_Types == null) { _Types = new List<Type>(); }
            _Types.Add(type);
        }
    }
}