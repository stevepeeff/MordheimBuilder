using DomainModel.Skills;
using DomainModel.Warbands.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands.Skaven
{
    internal class EshinSorcerer : SkavenHeroBase
    {
        public EshinSorcerer()
        {
            Movement.BaseValue = 5;
            Initiative.BaseValue = 4;

            _AllowedSkills.AddRange(SkillProvider.Instance.AcademicSkills);
            _AllowedSkills.AddRange(SkillProvider.Instance.SpeedSkills);
        }

        public override int HireFee => 45;

        public override int MaximumAllowedInWarBand => 1;

        public override IWarrior GetANewInstance()
        {
            return new EshinSorcerer();
        }
    }
}