using DomainModel.Psychology;
using DomainModel.Warbands.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands.Undead
{
    internal class Zombie : WarriorBase, IHenchMen
    {
        public Zombie()
        {
            Movement.BaseValue = 4;
            WeaponSkill.BaseValue = 2;
            BallisticSkill.BaseValue = 0;
            Strength.BaseValue = 3;
            Toughness.BaseValue = 3;
            Wounds.BaseValue = 1;
            Initiative.BaseValue = 1;
            Attacks.BaseValue = 1;
            LeaderShip.BaseValue = 5;

            AddAffliction(new Fear());
            AddAffliction(new MayNotRun());
            AddAffliction(new ImmuneToPsychology());
            AddAffliction(new ImmuneToPoison());
            AddAffliction(new NoPain());
            AddAffliction(new NoBrain());
        }

        public override int HireFee => 15;

        public override int MaximumAllowedInWarBand => INFINITE;

        public override IWarrior GetANewInstance()
        {
            return new Ghoul();
        }
    }
}