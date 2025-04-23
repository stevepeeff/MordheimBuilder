using DomainModel.Magic;
using System.Collections.Generic;

namespace DomainModel.Warbands
{
    /// <summary>
    /// A wizard uses magic
    /// </summary>
    /// <seealso cref="DomainModel.Warbands.IHero" />
    public interface IWizard : IHero
    {
        /// <summary>
        /// Gets the spell list.
        /// </summary>
        /// <value>
        /// The spell list.
        /// </value>
        IReadOnlyList<ISpell> SpellList { get; }

        /// <summary>
        /// Gets the drawn spells.
        /// </summary>
        /// <value>
        /// The drawn spells.
        /// </value>
        IReadOnlyList<ISpell> DrawnSpells { get; }

        /// <summary>
        /// Adds the spell.
        /// </summary>
        /// <param name="spell">The spell.</param>
        void AddSpell(ISpell spell);

        /// <summary>
        /// Adds the spell.
        /// </summary>
        /// <param name="spellName">Name of the spell.</param>
        void AddSpell(string spellName);
    }
}