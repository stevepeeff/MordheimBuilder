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
        public static List<Type> DistinctSkills<T>(this IReadOnlyCollection<ISkill> skillList) where T : ISkill
        {
            List<Type> result = new List<Type>();

            foreach (ISkill skill in skillList)
            {
                Type[] types = skill.GetType().GetInterfaces();

                foreach (Type interfaceType in types.ToList())
                {
                    if (!result.Contains(interfaceType) && !interfaceType.Name.Equals(nameof(ISkill)))
                    {
                        result.Add(interfaceType);
                    }
                }
            }

            return result;
        }

        public static IList<ISkill> GetSkillList(this Type skill)
        {
            return SkillProvider.Instance.AllSkills.Where(x => x.GetType().GetInterfaces().Contains(skill)).ToList();
        }

        public static string SkillName(this ISkill skill)
        {
            return skill.GetType().Name;
        }
    }
}