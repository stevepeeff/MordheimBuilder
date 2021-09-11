using DomainModel.Psychology;
using DomainModel.Warbands.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands.Skaven
{
    public class RatOgre : WarriorBase, IHenchMen
    {
        public RatOgre()
        {
            Movement.BaseValue = 6;
            Strength.BaseValue = 5;
            Toughness.BaseValue = 5;
            Wounds.BaseValue = 3;
            Initiative.BaseValue = 4;
            Attacks.BaseValue = 3;
            LeaderShip.BaseValue = 4;

            AddAffliction(new Animal());
            AddAffliction(new Large());
            AddAffliction(new Stupid());
            AddAffliction(new Fear());
        }

        public override int HireFee => 210;

        public override int MaximumAllowedInWarBand => 1;

        public override int MaximumExperience => 0;

        public override IWarrior GetANewInstance()
        {
            return new RatOgre();
        }
    }
}