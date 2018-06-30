using DomainModel.Magic.Prayers_of_Sigmar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Magic
{
    public static class Spells
    {
        public static IList<ISpell> PrayersOfSigmar { get; } = new List<ISpell>() { new HeartsOfSteel(), new TheHammerOfSigmar() };
    }
}