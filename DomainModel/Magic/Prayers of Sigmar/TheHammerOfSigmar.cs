using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Magic.Prayers_of_Sigmar
{
    public class TheHammerOfSigmar : SpellBase, IPrayerOfSigmar
    {
        public override int Difficulty { get; } = 7;

        public override int GainRequiredRoll { get; } = 1;

        public override string Description { get; } = "The wielder gains +2 Strength in hand-to-hand combat and all hits he inflicts cause double damage(eg, 2 wounds instead of 1). The Priest must test each shooting phase he wants to use the Hammer";
    }
}