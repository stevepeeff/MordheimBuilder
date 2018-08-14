using DomainModel.Magic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands
{
    public interface IWizard : IHero
    {
        IReadOnlyList<ISpell> SpellList { get; }

        IReadOnlyList<ISpell> DrawnSpells { get; }

        void AddSpell(ISpell spell);

        void AddSpell(string spellName);
    }
}