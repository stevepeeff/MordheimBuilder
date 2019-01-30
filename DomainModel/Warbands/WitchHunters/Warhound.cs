using DomainModel.Psychology;
using DomainModel.Warbands.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands.WitchHunters
{
    public class Warhound : WarriorBase, IHenchMen
    {
        public Warhound()
        {
            Movement.BaseValue = 6;
            WeaponSkill.BaseValue = 4;
            BallisticSkill.BaseValue = 0;
            Strength.BaseValue = 4;
            Initiative.BaseValue = 4;
            LeaderShip.BaseValue = 5;

            AddAffliction(new Animal());
        }

        public override int MaximumExperience => 0;

        public override int HireFee { get; } = 15;

        public override int MaximumAllowedInWarBand { get; } = 5;

        public override IWarrior GetANewInstance()
        {
            return new Warhound();
        }
    }
}