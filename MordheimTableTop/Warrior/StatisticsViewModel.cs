using DomainModel.Warbands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordheimTableTop.Warrior
{
    public class StatisticsViewModel : ViewModelBase
    {
        private IWarrior _Warrior;

        public StatisticsViewModel(IWarrior warrior)
        {
            if (warrior == null) { throw new ArgumentNullException("warrior is null"); }
            _Warrior = warrior;
        }

        public StatisticViewModel Attacks => new StatisticViewModel(_Warrior.Attacks);
        public StatisticViewModel BallisticSkill => new StatisticViewModel(_Warrior.BallisticSkill);
        public StatisticViewModel Initiative => new StatisticViewModel(_Warrior.Initiative);
        public StatisticViewModel LeaderShip => new StatisticViewModel(_Warrior.LeaderShip);
        public StatisticViewModel Movement => new StatisticViewModel(_Warrior.Movement);
        public StatisticViewModel Save => new StatisticViewModel(_Warrior.Save);
        public StatisticViewModel Strength => new StatisticViewModel(_Warrior.Strength);
        public StatisticViewModel Toughness => new StatisticViewModel(_Warrior.Toughness);
        public StatisticViewModel WeaponSkill => new StatisticViewModel(_Warrior.WeaponSkill);
        public StatisticViewModel Wounds => new StatisticViewModel(_Warrior.Wounds);
    }
}