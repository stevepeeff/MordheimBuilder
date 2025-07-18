﻿using DomainModel.Magic;
using DomainModel.Skills;
using DomainModel.Warbands.BaseClasses;
using System.Collections.Generic;

namespace DomainModel.Warbands.WitchHunters
{
    public class WarriorPriest : HumanHeroBase, IWizard
    {
        public WarriorPriest()
        {
            LeaderShip.BaseValue = 8;
            _AllowedWeapons.AddRange(WitchHuntersWarband.HeroEquipmentList);

            _AllowedSkills.AddRange(SkillProvider.Instance.CombatSkills);
            _AllowedSkills.AddRange(SkillProvider.Instance.AcademicSkills);
            _AllowedSkills.AddRange(SkillProvider.Instance.StrengthSkills);
        }

        public override IWarrior GetANewInstance()
        {
            return new WarriorPriest();
        }

        public override int InitialExperience { get; } = 12;

        public IReadOnlyList<ISpell> SpellList { get; } = SpellProvider.Instance.PrayersOfSigmar;

        public override int HireFee { get; } = 40;

        public override int MaximumAllowedInWarBand { get; } = 1;
    }
}