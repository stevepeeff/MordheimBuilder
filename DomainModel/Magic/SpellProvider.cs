using DomainModel.Magic.Prayers_of_Sigmar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Magic
{
    internal class SpellProvider
    {
        public static SpellProvider Instance => new SpellProvider();

        private List<ISpell> _Spells = new List<ISpell>();

        private SpellProvider()
        {
            _Spells.Add(new HeartsOfSteel());
            _Spells.Add(new TheHammerOfSigmar());
        }

        public ISpell GetSpell(string spellName)
        {
            return _Spells.First(x => x.SpellName.Equals(spellName));
        }

        /// <summary>
        /// Gets the prayers of sigmar.
        /// </summary>
        /// <value>
        /// The prayers of sigmar.
        /// </value>
        public IReadOnlyList<IPrayerOfSigmar> PrayersOfSigmar => _Spells.GetSpells<IPrayerOfSigmar>();
    }
}