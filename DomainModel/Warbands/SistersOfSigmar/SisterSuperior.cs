﻿using DomainModel.Skills;
using DomainModel.Warbands.BaseClasses;

namespace DomainModel.Warbands.SistersOfSigmar
{
    public class SisterSuperior : HeroBase, IHero, ISistersOfSigmar
    {
        public SisterSuperior()
        {
            Movement.BaseValue = 4;
            WeaponSkill.BaseValue = 4;
            BallisticSkill.BaseValue = 3;
            Strength.BaseValue = 3;
            Toughness.BaseValue = 3;
            Wounds.BaseValue = 1;
            Initiative.BaseValue = 3;
            Attacks.BaseValue = 1;
            LeaderShip.BaseValue = 7;

            _AllowedWeapons.AddRange(SistersOfSigmarWarband.WeaponList);
            _AllowedWeapons.AddRange(SistersOfSigmarWarband.ArmourList);

            _AllowedSkills.AddRange(SkillProvider.Instance.CombatSkills);
            _AllowedSkills.AddRange(SkillProvider.Instance.AcademicSkills);
            _AllowedSkills.AddRange(SkillProvider.Instance.StrengthSkills);
            _AllowedSkills.AddRange(SkillProvider.Instance.SpeedSkills);
            _AllowedSkills.AddRange(SkillProvider.Instance.SistersOfSigmarSpecialSkills);
        }

        public override int HireFee => 35;

        public override int MaximumAllowedInWarBand => 3;

        public override IWarrior GetANewInstance()
        {
            return new SisterSuperior();
        }
    }
}