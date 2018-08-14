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
    public static class SkillProviderTools
    {
        public static IList<T> GetSkills<T>(this IList<ISkill> skills) where T : ISkill
        {
            IList<T> retval = new List<T>();

            foreach (ISkill item in skills)
            {
                if (item is T)
                {
                    retval.Add((T)item);
                }
            }

            return retval;
        }

        public static ISkill GetSkill(this IList<ISkill> skills, string skillName)
        {
            return skills.FirstOrDefault(x => x.SkillName.Equals(skillName));
        }

        public static string SkillName(this ISkill skill)
        {
            return skill.GetType().Name;
        }
    }
}