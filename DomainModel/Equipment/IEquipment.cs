namespace DomainModel.Equipment
{
    public enum Availabilities
    {
        COMMON = 0,
        RARE_5 = 5,
        RARE_7 = 7,
        RARE_6 = 6,
        RARE_8 = 8,
        RARE_9 = 9,
        RARE_10 = 10,
        RARE_11 = 11,
        RARE_12 = 12,
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
        /// Gets the trade availability.
        /// </summary>
        /// <value>
        /// The trade availability.
        /// </value>
        Availability TradeAvailability { get; }

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