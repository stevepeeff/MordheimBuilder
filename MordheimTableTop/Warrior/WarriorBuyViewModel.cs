using DomainModel.Skills;
using DomainModel.Warbands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MordheimTableTop.Warrior
{
    internal class WarriorBuyViewModel : ViewModelBase
    {
        public WarriorBuyViewModel(IWarrior warrior)
        {
            _Warrior = warrior;
        }

        /// <summary>
        /// Gets the buy warrior command.
        /// </summary>
        /// <value>
        /// The buy warrior command.
        /// </value>
        public ICommand BuyWarriorCommand => new RelayCommand(x => BuyWarrior());

        /// <summary>
        /// Gets the hire fee.
        /// </summary>
        /// <value>
        /// The hire fee.
        /// </value>
        public int HireFee { get { return _Warrior.HireFee; } }

        /// <summary>
        /// Gets the maximum in warband.
        /// </summary>
        /// <value>
        /// The maximum in warband.
        /// </value>
        public int MaximumInWarband { get { return _Warrior.MaximumAllowedInWarBand; } }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets the skill summary.
        /// </summary>
        /// <value>
        /// The skill summary.
        /// </value>
        public string SkillSummary
        {
            get
            {
                string skillList = String.Empty;

                foreach (string skillName in _Warrior.AllowedSkills.DistinctNames())
                {
                    string formatttedSkillName = skillName.Remove(0, 1).SplitCamelCasing();

                    if (String.IsNullOrEmpty(skillList))
                    {
                        skillList = $" {formatttedSkillName}"; ;
                    }
                    else
                    {
                        skillList += $" ,{formatttedSkillName}";
                    }
                }

                if (String.IsNullOrEmpty(skillList)) { skillList = "-"; }
                return skillList;
            }
        }

        /// <summary>
        /// Gets the special rules summary.
        /// </summary>
        /// <value>
        /// The special rules summary.
        /// </value>
        public string SpecialRulesSummary
        {
            get
            {
                string retval = " -";

                bool appendComma = false;
                foreach (var item in _Warrior.Afflictions)
                {
                    if (appendComma == false)
                    {
                        retval = $" {item.Name.SplitCamelCasing()}";
                    }
                    else
                    {
                        retval += $" ,{item.Name.SplitCamelCasing()}";
                    }

                    appendComma = true;
                }

                return retval;
            }
        }

        /// <summary>
        /// Gets the statistics vm.
        /// </summary>
        /// <value>
        /// The statistics vm.
        /// </value>
        public StatisticsViewModel StatisticsVM { get { return new StatisticsViewModel(_Warrior); } }

        /// <summary>
        /// Gets the name of the warrior type.
        /// </summary>
        /// <value>
        /// The name of the warrior type.
        /// </value>
        public string WarriorTypeName { get { return _Warrior.TypeName.SplitCamelCasing(); } }

        private IWarrior _Warrior { get; }

        private void BuyWarrior()
        {
        }
    }
}