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
    /// <summary>
    /// Class responsible for creating the list of all Skills
    /// </summary>
    public class SkillProvider
    {
        private SkillProvider()
        {
            AddSkill(new MightyBlow());
            AddSkill(new PitFighter());
            AddSkill(new Resilient());

            AddSkill(new BattleTongue());

            AddSkill(new QuickShot());

            AddSkill(new Leap());

            AddSkill(new StrikeToInjure());
        }

        public static SkillProvider Instance { get; } = new SkillProvider();

        //TODO remove specific skill lists, use helper functions in Skill Provider Tools

        public IList<IAcademic> AcademicSkills { get; } = new List<IAcademic>();
        public IList<ISkill> AllSkills { get; } = new List<ISkill>();
        public IList<ICombat> CombatSkills { get; } = new List<ICombat>();
        public IList<IShooting> ShootingSkills { get; } = new List<IShooting>();
        public IList<ISpeed> SpeedSkills { get; } = new List<ISpeed>();
        public IList<IStrength> StrengthSkills { get; } = new List<IStrength>();

        private void AddSkill(ISkill skill)
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

            if (AllSkills.FirstOrDefault(x => x.SkillName().Equals(skill.SkillName())) == null)
            {
                AllSkills.Add(skill);
            }
        }
    }
}