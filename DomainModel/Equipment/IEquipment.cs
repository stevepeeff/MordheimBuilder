using DomainModel.Equipment.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Equipment
{
    public enum Availabilities
    {
        COMMON = 0,
        RARE_5 = 5,
        RARE_7 = 8,
        RARE_8 = 8,
        RARE_9 = 9,
        RARE_10 = 10,
        RARE_11 = 11,
        RARE_12 = 12
    }

    public enum Usage
    {
        INFINITE,
        ONE_USE,
        ONE_BATTLE,
    }

    public interface IEquipment
    {
        /// <summary>
        /// Gets the availability.
        /// </summary>
        /// <value>
        /// The availability.
        /// </value>
        Availabilities Availability { get; }

        /// <summary>
        /// Gets the cost.
        /// </summary>
        /// <value>
        /// The cost.
        /// </value>
        int Cost { get; }

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        string Description { get; }

        /// <summary>
        /// Gets the duration.
        /// </summary>
        /// <value>
        /// The duration.
        /// </value>
        Usage Duration { get; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; }

        /// <summary>
        /// Gets the variable cost.
        /// </summary>
        /// <value>
        /// The variable cost.
        /// </value>
        VariabeleCosts VariableCost { get; }
    }
}