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
    internal class SkillProvider
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

        /// <summary>
        /// Gets the academic skills.
        /// </summary>
        /// <value>
        /// The academic skills.
        /// </value>
        public IList<IAcademic> AcademicSkills => AllSkills.GetSkills<IAcademic>();

        /// <summary>
        /// Gets all skills.
        /// </summary>
        /// <value>
        /// All skills.
        /// </value>
        public IList<ISkill> AllSkills { get; } = new List<ISkill>();

        /// <summary>
        /// Gets the combat skills.
        /// </summary>
        /// <value>
        /// The combat skills.
        /// </value>
        public IList<ICombat> CombatSkills => AllSkills.GetSkills<ICombat>();

        /// <summary>
        /// Gets the shooting skills.
        /// </summary>
        /// <value>
        /// The shooting skills.
        /// </value>
        public IList<IShooting> ShootingSkills => AllSkills.GetSkills<IShooting>();

        /// <summary>
        /// Gets the speed skills.
        /// </summary>
        /// <value>
        /// The speed skills.
        /// </value>
        public IList<ISpeed> SpeedSkills => AllSkills.GetSkills<ISpeed>();

        /// <summary>
        /// Gets the strength skills.
        /// </summary>
        /// <value>
        /// The strength skills.
        /// </value>
        public IList<IStrength> StrengthSkills
        {
            get
            {
                return AllSkills.GetSkills<IStrength>();
            }
        }

        private void AddSkill(ISkill skill)
        {
            if (AllSkills.FirstOrDefault(x => x.SkillName().Equals(skill.SkillName())) == null)
            {
                AllSkills.Add(skill);
            }
        }
    }
}