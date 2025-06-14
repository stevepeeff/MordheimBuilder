﻿using DomainModel.Psychology;
using DomainModel.Skills;
using DomainModel.Warbands.BaseClasses;

namespace DomainModel.Warbands.Undead
{
    internal class Vampire : UndeadHeroBase
    {
        public Vampire()
        {
            Movement.BaseValue = 6;
            WeaponSkill.BaseValue = 4;
            BallisticSkill.BaseValue = 4;
            Strength.BaseValue = 4;
            Toughness.BaseValue = 4;
            Wounds.BaseValue = 2;
            Initiative.BaseValue = 5;
            Attacks.BaseValue = 2;
            LeaderShip.BaseValue = 8;

            _AllowedWeapons.AddRange(UndeadWarband.UndeadEquipmentList);

            _AllowedSkills.AddRange(SkillProvider.Instance.CombatSkills);
            _AllowedSkills.AddRange(SkillProvider.Instance.AcademicSkills);
            _AllowedSkills.AddRange(SkillProvider.Instance.StrengthSkills);
            _AllowedSkills.AddRange(SkillProvider.Instance.SpeedSkills);

            AddAffliction(new Fear());
            AddAffliction(new ImmuneToPsychology());
            AddAffliction(new ImmuneToPoison());
            AddAffliction(new NoPain());
        }

        public override int HireFee => 110;

        public override int InitialExperience { get; } = 20;

        public override int MaximumAllowedInWarBand => 1;

        public override IWarrior GetANewInstance()
        {
            return new Vampire();
        }
    }
}