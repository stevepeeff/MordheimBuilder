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
        private static List<ISkill> _AllSkills = new List<ISkill>();

        static SkillProviderTools()
        {
            //_AllSkills.AddRange(AcademicSkills);
            //_AllSkills.AddRange(CombatSkills);
            //_AllSkills.AddRange(ShootingSkills);
            //_AllSkills.AddRange(SpeedSkills);
            //_AllSkills.AddRange(StrengthSkills);
        }

        internal static IList<IAcademic> AcademicSkills
        {
            get
            {
                return new List<IAcademic>()
                {
                    new BattleTongue()
                };
            }
        }

        internal static IList<ICombat> CombatSkills
        {
            get
            {
                return new List<ICombat>()
                {
                    new StrikeToInjure()
                };
            }
        }

        internal static IList<IShooting> ShootingSkills
        {
            get
            {
                return new List<IShooting>()
                {
                    new QuickShot()
                };
            }
        }

        internal static IList<ISpeed> SpeedSkills
        {
            get
            {
                return new List<ISpeed>()
                {
                    new Leap()
                };
            }
        }

        internal static IList<IStrength> StrengthSkills
        {
            get
            {
                return new List<IStrength>()
                {
                    new MightyBlow(),
                    new PitFighter(),
                    new Resilient(),
                };
            }
        }

        // internal IList<IStrength> StrengthSkills { get; } = new IList<ISkill>();

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

        public static IList<ISkill> GetSkillList(Type skill)
        {
            IList<ISkill> resultList = new List<ISkill>();

            foreach (ISkill item in _AllSkills)
            {
                if (item.GetType().GetInterfaces().Contains(skill))
                {
                    resultList.Add(item);
                }
            }
            return resultList;
        }

        public static string SkillName(this ISkill skill)
        {
            return skill.GetType().Name;
        }
    }
}