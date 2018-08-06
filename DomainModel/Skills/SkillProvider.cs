using DomainModel.Skills.Shooting;
using DomainModel.Skills.Strength;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Skills
{
    class SkillProvider
    {
        public IList<IStrength> StrengthSkills { get; } = new List<IStrength>();

        private SkillProvider()
        {
        }

        public static SkillProvider Instance { get; } = new SkillProvider();

        public void AddSkill(ISkill skill)
        {
        }

        IList<IShooting> ShootingSkills { get; } = new List<IShooting>();
    }
}