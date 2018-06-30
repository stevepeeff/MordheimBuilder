using DomainModel.Injuries;
using DomainModel.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands.BaseClasses
{
    public abstract class HeroBase : WarriorBase, IHero
    {
        private List<Injury> _Injuries = new List<Injury>();

        public IReadOnlyCollection<Injury> Injuries { get { return _Injuries; } }

        public override int MaximumExperience { get; } = 30;

        public static bool LevelUpCalculationHero(int experienceValue)
        {
            int cumulative = 0;
            for (int i = 2; i <= 7; i++)
            {
                if (i <= 4)
                {
                    for (int y = 0; y < 4; y++)
                    {
                        cumulative += i;
                        if (experienceValue == cumulative) { return true; }
                        if (experienceValue < cumulative) { return false; }
                    }
                }
                else
                {
                    for (int y = 0; y < 3; y++)
                    {
                        cumulative += i;
                        if (experienceValue == cumulative) { return true; }
                        if (experienceValue < cumulative) { return false; }
                    }
                }
            }

            return false;
        }

        public void AddInjury(Injury injury)
        {
            _Injuries.Add(injury);
            Trigger();
        }

        public void AddSkill(ISkill skill)
        {
            _Skills.Add(skill);
            Trigger();
        }

        public override bool ExperienceIsLevelUp(int experienceValue)
        {
            return LevelUpCalculationHero(experienceValue);
        }
    }
}