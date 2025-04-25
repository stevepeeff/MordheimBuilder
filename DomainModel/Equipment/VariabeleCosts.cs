namespace DomainModel.Equipment
{
    public class VariabeleCosts
    {
        /// <summary>
        /// Gets or sets the d6 roll.
        /// </summary>
        /// <value>
        /// The d6 roll.
        /// </value>
        public int D6Roll { get; set; }

        /// <summary>
        /// Gets the multiplier.
        /// </summary>
        /// <value>
        /// The multiplier.
        /// </value>
        public int Multiplier { get; private set; } = 1;

        /// <summary>
        /// Gets the gold crowns.
        /// </summary>
        /// <value>
        /// The gold crowns.
        /// </value>
        public int GoldCrowns { get; private set; }

        /// <summary>
        /// Gets the total costs.
        /// </summary>
        /// <value>
        /// The total costs.
        /// </value>
        public int TotalCosts
        { get { return D6Roll * Multiplier * GoldCrowns; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="VariabeleCosts"/> class.
        /// </summary>
        /// <param name="gc">The gc.</param>
        /// <param name="d6Roll">The d6 roll.</param>
        public VariabeleCosts(int gc, int d6Roll)
        {
            GoldCrowns = gc;
            D6Roll = d6Roll;
        }

        public VariabeleCosts(int gc, int d6Roll, int multiplier) : this(gc, d6Roll)
        {
            Multiplier = multiplier;
        }
    }
}