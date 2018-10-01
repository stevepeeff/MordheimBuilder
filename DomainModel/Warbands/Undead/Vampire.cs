using DomainModel.Skills;
using DomainModel.Warbands.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands.Undead
{
    internal class Vampire : UndeadHeroBase
    {
        public Vampire()
        {
            Movement.BaseValue = 5;
            WeaponSkill.BaseValue = 4;
            BallisticSkill.BaseValue = 4;
            Strength.BaseValue = 4;
            Toughness.BaseValue = 4;
            Wounds.BaseValue = 2;
            Initiative.BaseValue = 5;
            Attacks.BaseValue = 2;
            LeaderShip.BaseValue = 8;

            _AllowedSkills.AddRange(SkillProvider.Instance.CombatSkills);
            _AllowedSkills.AddRange(SkillProvider.Instance.AcademicSkills);
            _AllowedSkills.AddRange(SkillProvider.Instance.StrengthSkills);
            _AllowedSkills.AddRange(SkillProvider.Instance.SpeedSkills);
        }

        public override int HireFee => 110;

        public override int MaximumAllowedInWarBand => 1;

        public override IWarrior GetANewInstance()
        {
            return new Vampire();
        }
    }
}