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
            Warrior = warrior;
        }

        public ICommand BuyWarriorCommand => new RelayCommand(x => BuyWarrior());

        /// <summary>
        /// Gets the maximum in warband.
        /// </summary>
        /// <value>
        /// The maximum in warband.
        /// </value>
        public int MaximumInWarband { get { return Warrior.MaximumAllowedInWarBand; } }

        public string Name { get; set; }

        public int HireFee { get { return Warrior.HireFee; } }

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

                foreach (string skillName in Warrior.AllowedSkills.DistinctNames())
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
                foreach (var item in Warrior.Afflictions)
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
        public StatisticsViewModel StatisticsVM { get { return new StatisticsViewModel(Warrior); } }

        /// <summary>
        /// Gets the warrior.
        /// </summary>
        /// <value>
        /// The warrior.
        /// </value>
        public IWarrior Warrior { get; }

        /// <summary>
        /// Gets the name of the warrior type.
        /// </summary>
        /// <value>
        /// The name of the warrior type.
        /// </value>
        public string WarriorTypeName { get { return Warrior.TypeName.SplitCamelCasing(); } }

        private void BuyWarrior()
        {
        }
    }
}