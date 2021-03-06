﻿using DomainModel.Psychology;
using DomainModel.Warbands.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands.Undead
{
    internal class DireWolf : WarriorBase, IHenchMen
    {
        public DireWolf()
        {
            Movement.BaseValue = 6;
            WeaponSkill.BaseValue = 2;
            BallisticSkill.BaseValue = 0;
            Initiative.BaseValue = 4;
            LeaderShip.BaseValue = 4;

            //AddAffliction(new Animal());
            //AddAffliction(new Animal());
            AddAffliction(new Fear());
            AddAffliction(new ImmuneToPsychology());
            AddAffliction(new ImmuneToPoison());
            AddAffliction(new NoPain());
        }

        public override int HireFee => 50;

        public override int MaximumAllowedInWarBand => 5;

        public override IWarrior GetANewInstance()
        {
            return new DireWolf();
        }
    }
}