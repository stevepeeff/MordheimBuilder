using DomainModel.Psychology;
using DomainModel.Warbands.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands.WitchHunters
{
    public class WitchHunter : HumanHeroBase
    {
        public WitchHunter()
        {
            AddAffliction(new BurnTheWitch());
            _AllowedWeapons.AddRange(WitchHunters.HeroEquipmentList);
        }

        public override int InitialExperience { get; } = 8;

        public override int HireFee { get; } = 30;

        public override int MaximumAmountInWarBand { get; } = 3;

        public override IWarrior GetANewInstance()
        {
            return new WitchHunter();
        }
    }
}