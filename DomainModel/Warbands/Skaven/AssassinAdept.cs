using DomainModel.Skills;
using DomainModel.Warbands.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands.Skaven
{
    public class AssassinAdept : SkavenHeroBase
    {
        public AssassinAdept()
        {
            Strength.BaseValue = 4;
            BallisticSkill.BaseValue = 4;
            WeaponSkill.BaseValue = 4;
            Strength.BaseValue = 4;
            Initiative.BaseValue = 5;
            LeaderShip.BaseValue = 7;

            _AllowedSkills.AddRange(SkillProvider.Instance.CombatSkills);
            _AllowedSkills.AddRange(SkillProvider.Instance.ShootingSkills);
            _AllowedSkills.AddRange(SkillProvider.Instance.AcademicSkills);
            _AllowedSkills.AddRange(SkillProvider.Instance.StrengthSkills);
            _AllowedSkills.AddRange(SkillProvider.Instance.SpeedSkills);
            _AllowedSkills.AddRange(SkillProvider.Instance.SkavenSpecialSkills);
        }

        public override int HireFee { get; } = 60;

        public override int MaximumAllowedInWarBand { get; } = 1;

        public override int InitialExperience { get; } = 20;

        public override IWarrior GetANewInstance()
        {
            return new AssassinAdept();
        }
    }
}