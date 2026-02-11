using DomainModel.Warbands;
using System;

namespace MordheimTableTop.Warrior
{
    /// <summary>
    /// ViewModel representing statistics
    /// </summary>
    /// <seealso cref="MordheimTableTop.ViewModelBase" />
    public class StatisticsViewModel : ViewModelBase
    {
        private readonly IWarrior _Warrior;

        /// <summary>
        /// Initializes a new instance of the <see cref="StatisticsViewModel"/> class.
        /// </summary>
        /// <param name="warrior">The warrior.</param>
        /// <exception cref="System.ArgumentNullException">warrior is null</exception>
        public StatisticsViewModel(IWarrior warrior)
        {
            if (warrior == null) { throw new ArgumentNullException("warrior is null"); }
            _Warrior = warrior;
        }

        /// <summary>Gets the attacks.</summary>
        public StatisticViewModel Attacks => new StatisticViewModel(_Warrior.Attacks);

        /// <summary>
        /// Gets the ballistic skill.
        /// </summary>
        public StatisticViewModel BallisticSkill => new StatisticViewModel(_Warrior.BallisticSkill);

        /// <summary>
        /// Gets the initiative.
        /// </summary>
        public StatisticViewModel Initiative => new StatisticViewModel(_Warrior.Initiative);

        /// <summary>
        /// Gets the leader ship.
        /// </summary>
        public StatisticViewModel LeaderShip => new StatisticViewModel(_Warrior.LeaderShip);

        /// <summary>
        /// Gets the movement.
        /// </summary>
        public StatisticViewModel Movement => new StatisticViewModel(_Warrior.Movement);

        /// <summary>
        /// Gets the save.
        /// </summary>
        public StatisticViewModel Save => new StatisticViewModel(_Warrior.Save);

        /// <summary>
        /// Gets the strength.
        /// </summary>
        public StatisticViewModel Strength => new StatisticViewModel(_Warrior.Strength);

        /// <summary>
        /// Gets the toughness.
        /// </summary>
        public StatisticViewModel Toughness => new StatisticViewModel(_Warrior.Toughness);

        /// <summary>
        /// Gets the weapon skill.
        /// </summary>
        public StatisticViewModel WeaponSkill => new StatisticViewModel(_Warrior.WeaponSkill);

        /// <summary>
        /// Gets the wounds.
        /// </summary>
        public StatisticViewModel Wounds => new StatisticViewModel(_Warrior.Wounds);
    }
}