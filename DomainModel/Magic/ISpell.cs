namespace DomainModel.Magic
{
    public interface ISpell
    {
        string SpellName { get; }

        int Difficulty { get; }

        /// <summary>
        /// Gets the gain required roll.
        /// </summary>
        /// <value>
        /// The gain required roll.
        /// </value>
        int GainRequiredRoll { get; }

        string Description { get; }
    }
}