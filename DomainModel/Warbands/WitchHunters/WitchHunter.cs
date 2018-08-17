using DomainModel.Psychology;
using DomainModel.Skills;
using DomainModel.Warbands.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands.WitchHunters
{
    public class WitchHunter : HumanHeroBase
    {
        public WitchHunter()
        {
            AddAffliction(new BurnTheWitch());
            _AllowedWeapons.AddRange(WitchHuntersWarband.HeroEquipmentList);

            _AllowedSkills.AddRange(SkillProvider.Instance.CombatSkills);
            _AllowedSkills.AddRange(SkillProvider.Instance.ShootingSkills);
            _AllowedSkills.AddRange(SkillProvider.Instance.AcademicSkills);
            _AllowedSkills.AddRange(SkillProvider.Instance.SpeedSkills);
        }

        public override int InitialExperience { get; } = 8;

        public override int HireFee { get; } = 30;

        public override int MaximumAllowedInWarBand { get; } = 3;

        public override IWarrior GetANewInstance()
        {
            return new WitchHunter();
        }
    }
}