using DomainModel.Injuries;
using DomainModel.Magic;
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

        private List<ISpell> _DrawnSpells = new List<ISpell>();
        public IReadOnlyList<ISpell> DrawnSpells => _DrawnSpells;
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
            TriggerCharacteristicChanged();
        }

        public void AddSpell(ISpell spell)
        {
            _DrawnSpells.Add(spell);
        }

        public void AddSpell(string spellName)
        {
            AddSpell(SpellProvider.Instance.GetSpell(spellName));
        }

        public override bool IsLevelUp(int experienceValue)
        {
            return LevelUpCalculationHero(experienceValue);
        }
    }
}