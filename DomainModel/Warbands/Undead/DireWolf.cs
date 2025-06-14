﻿using DomainModel.Psychology;
using DomainModel.Warbands.BaseClasses;

namespace DomainModel.Warbands.Undead
{
    internal class DireWolf : WarriorBase, IHenchMen
    {
        public DireWolf()
        {
            Movement.BaseValue = 9;
            //WeaponSkill.BaseValue = 3;
            BallisticSkill.BaseValue = 0;
            Strength.BaseValue = 4;
            Initiative.BaseValue = 4;
            LeaderShip.BaseValue = 4;

            AddAffliction(new Animal());
            AddAffliction(new MayNotRun());
            AddAffliction(new SlaveringCharge());
            AddAffliction(new Fear());
            AddAffliction(new ImmuneToPsychology());
            AddAffliction(new ImmuneToPoison());
            AddAffliction(new NoPain());
        }

        /// <summary>
        /// Gets the maximum experience.
        /// Dire Wolfs never gain experience
        /// </summary>
        /// <value>
        /// The maximum experience.
        /// </value>
        public override int MaximumExperience => 0;

        /// <summary>
        /// Gets the hire fee.
        /// </summary>
        /// <value>
        /// The hire fee.
        /// </value>
        public override int HireFee => 50;

        public override int MaximumAllowedInWarBand => 5;

        public override IWarrior GetANewInstance()
        {
            return new DireWolf();
        }
    }
}