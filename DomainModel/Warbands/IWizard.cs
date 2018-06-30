using DomainModel.Magic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands
{
    public interface IWizard
    {
        IList<ISpell> SpellList { get; }

        IList<ISpell> DrawnSpells { get; }
    }
}