﻿using DomainModel.Psychology;
using DomainModel.Warbands.BaseClasses;

namespace DomainModel.Warbands.Skaven
{
    public class GaintRat : WarriorBase, IHenchMen
    {
        public GaintRat()
        {
            Movement.BaseValue = 6;
            WeaponSkill.BaseValue = 2;
            BallisticSkill.BaseValue = 0;
            Initiative.BaseValue = 4;
            LeaderShip.BaseValue = 4;

            AddAffliction(new Animal());
        }

        public override int HireFee => 15;

        public override int MaximumAllowedInWarBand => INFINITE;

        public override int MaximumExperience => 0;

        public override IWarrior GetANewInstance()
        {
            return new GaintRat();
        }
    }
}