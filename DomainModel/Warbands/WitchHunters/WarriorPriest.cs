using DomainModel.Magic;
using DomainModel.Magic.Prayers_of_Sigmar;
using DomainModel.Warbands.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands.WitchHunters
{
    public class WarriorPriest : HumanHeroBase, IWizard
    {
        public WarriorPriest()
        {
            LeaderShip.BaseValue = 8;
            _AllowedWeapons.AddRange(WitchHuntersWarband.HeroEquipmentList);

            //TODO TESTING
            AddSpell(new TheHammerOfSigmar());
        }

        public void AddSpell(ISpell spell)
        {
            DrawnSpells.Add(spell);
        }

        public override IWarrior GetANewInstance()
        {
            return new WarriorPriest();
        }

        public override int InitialExperience { get; } = 12;

        public IList<ISpell> SpellList { get; } = Spells.PrayersOfSigmar;

        public IList<ISpell> DrawnSpells { get; } = new List<ISpell>();

        public override int HireFee { get; } = 40;

        public override int MaximumAllowedInWarBand { get; } = 1;
    }
}