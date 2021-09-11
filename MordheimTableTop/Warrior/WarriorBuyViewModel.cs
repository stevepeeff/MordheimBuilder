using DomainModel.Skills;
using DomainModel.Warbands;
using MordheimBuilderLogic;
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

            BuyWarriorCommand = new RelayCommand(
                        x => BuilderLogicFactory.Instance.WarbandRoster.AddWarrior(_Warrior),
                        x => PurchaseAllowed());
        }

        /// <summary>
        /// Gets the buy warrior command.
        /// </summary>
        /// <value>
        /// The buy warrior command.
        /// </value>
        public ICommand BuyWarriorCommand { get; }

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
        public string MaximumInWarband
        {
            get
            {
                if (_Warrior.MaximumAllowedInWarBand == int.MaxValue) { return "∞"; }
                return _Warrior.MaximumAllowedInWarBand.ToString();
            }
        }

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
        public string WarriorTypeName
        {
            get
            {
                string retval = "(HenchMen) ";
                if (_Warrior is IHero)
                {
                    retval = "(Hero) ";
                }

                return (retval + _Warrior.TypeName.SplitCamelCasing());
            }
        }

        public IWarrior _Warrior { get; }

        private bool PurchaseAllowed()
        {
            return
                (
                BuilderLogicFactory.Instance.WarbandRoster.MaximumAllowedAmountOfWarriorReached(_Warrior) == false &&
                BuilderLogicFactory.Instance.WarbandRoster.MaximumAllowedAmountOfWarriorsReached() == false
                );
        }
    }
}