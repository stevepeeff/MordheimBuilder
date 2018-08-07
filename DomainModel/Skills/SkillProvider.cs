using DomainModel.Skills.Academic;
using DomainModel.Skills.Combat;
using DomainModel.Skills.Shooting;
using DomainModel.Skills.Speed;
using DomainModel.Skills.Strength;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Skills
{
    internal class SkillProvider
    {
        public IList<IStrength> StrengthSkills { get; } = new List<IStrength>();

        private SkillProvider()
        {
        }

        public static SkillProvider Instance { get; } = new SkillProvider();

        public void AddSkill(ISkill skill)
        {
            if (skill is IStrength)
            {
                if (StrengthSkills.FirstOrDefault(x => x.Name.Equals(skill.Name)) == null)
                {
                    StrengthSkills.Add(skill as IStrength);
                }
            }
            else if (skill is IShooting)
            {
                if (ShootingSkills.FirstOrDefault(x => x.Name.Equals(skill.Name)) == null)
                {
                    ShootingSkills.Add(skill as IShooting);
                }
            }
            else if (skill is IAcademic)
            {
                if (AcademicSkills.FirstOrDefault(x => x.Name.Equals(skill.Name)) == null)
                {
                    AcademicSkills.Add(skill as IAcademic);
                }
            }
            else if (skill is ICombat)
            {
                if (CombatSkills.FirstOrDefault(x => x.Name.Equals(skill.Name)) == null)
                {
                    CombatSkills.Add(skill as ICombat);
                }
            }
            else if (skill is ISpeed)
            {
                if (ShootingSkills.FirstOrDefault(x => x.Name.Equals(skill.Name)) == null)
                {
                    SpeedSkills.Add(skill as ISpeed);
                }
            }
            else
            {
                throw new NotImplementedException($"Skill: '{skill.Name}' is not known by the SkillProvider");
            }
        }

        public IList<IShooting> ShootingSkills { get; } = new List<IShooting>();

        public IList<IAcademic> AcademicSkills { get; } = new List<IAcademic>();

        public IList<ICombat> CombatSkills { get; } = new List<ICombat>();

        public IList<ISpeed> SpeedSkills { get; } = new List<ISpeed>();
    }
}