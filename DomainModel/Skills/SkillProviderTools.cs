using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainModel.Skills
{
    public static class SkillProviderTools
    {
        /// <summary>
        /// Distinct the names.
        /// </summary>
        /// <param name="skills">The skills.</param>
        /// <returns></returns>
        public static List<string> DistinctNames(this IReadOnlyCollection<ISkill> skills)
        {
            List<string> distinctSkills = new List<string>();

            foreach (var skill in skills)
            {
                Type[] types = skill.GetType().GetInterfaces();
                foreach (Type item in types)
                {
                    if (!item.Name.Equals(nameof(ISkill)))
                    {
                        string skillName = item.Name;
                        if (!distinctSkills.Contains(skillName))
                        {
                            distinctSkills.Add(skillName);
                        }
                    }
                }
            }

            return distinctSkills;
        }

        /// <summary>
        /// Gets the skill.
        /// </summary>
        /// <param name="skills">The skills.</param>
        /// <param name="skillName">Name of the skill.</param>
        /// <returns></returns>
        public static ISkill GetSkill(this IList<ISkill> skills, string skillName)
        {
            return skills.FirstOrDefault(x => x.SkillName.Equals(skillName));
        }

        /// <summary>
        /// Gets the skills.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="skills">The skills.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Skills the name.
        /// </summary>
        /// <param name="skill">The skill.</param>
        /// <returns></returns>
        public static string SkillName(this ISkill skill)
        {
            return skill.GetType().Name;
        }
    }
}