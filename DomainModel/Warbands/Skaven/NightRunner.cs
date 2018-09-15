using DomainModel.Warbands.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands.Skaven
{
    internal class NightRunner : SkavenHeroBase
    {
        public NightRunner()
        {
            WeaponSkill.BaseValue = 2;
            LeaderShip.BaseValue = 4;
        }

        public override int HireFee => 20;

        public override int MaximumAllowedInWarBand => 2;

        public override IWarrior GetANewInstance()
        {
            return new NightRunner();
        }
    }
}