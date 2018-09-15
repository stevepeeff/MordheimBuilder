using DomainModel.Skills;
using DomainModel.Warbands.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands.Skaven
{
    internal class BlackSkaven : SkavenHeroBase
    {
        public BlackSkaven()
        {
            Strength.BaseValue = 4;

            WeaponSkill.BaseValue = 4;
            Strength.BaseValue = 4;
            Initiative.BaseValue = 5;
            LeaderShip.BaseValue = 6;

            _AllowedSkills.AddRange(SkillProvider.Instance.CombatSkills);
            _AllowedSkills.AddRange(SkillProvider.Instance.ShootingSkills);
            _AllowedSkills.AddRange(SkillProvider.Instance.AcademicSkills);
            _AllowedSkills.AddRange(SkillProvider.Instance.StrengthSkills);
            _AllowedSkills.AddRange(SkillProvider.Instance.SpeedSkills);
        }

        public override int HireFee => 40;

        public override int InitialExperience { get; } = 8;

        public override int MaximumAllowedInWarBand => 2;

        public override IWarrior GetANewInstance()
        {
            return new BlackSkaven();
        }
    }
}