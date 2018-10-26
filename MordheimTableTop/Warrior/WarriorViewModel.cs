using DomainModel.Warbands;
using MordheimBuilderLogic;
using MordheimTableTop.Warrior.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MordheimTableTop.Warrior
{
    internal class WarriorViewModel : ViewModelBase
    {
        private readonly IWarrior _Warrior;

        public WarriorViewModel(IWarrior warrior)
        {
            _Warrior = warrior;
        }

        /// <summary>
        /// Gets the decrease henchmen command.
        /// </summary>
        /// <value>
        /// The decrease henchmen command.
        /// </value>
        public ICommand DecreaseHenchmenCommand => new DecreaseBuyAmount(_Warrior);

        public int? GroupCosts
        {
            get
            {
                if (_Warrior is IHenchMen)
                {
                    IHenchMen henchMen = _Warrior as IHenchMen;
                    return (henchMen.GroupCosts);
                }
                else
                {
                    return (_Warrior.HireFee + _Warrior.EquipmentCosts);
                }
            }
        }

        public int? GroupCount
        {
            get
            {
                if (_Warrior is IHenchMen)
                {
                    IHenchMen henchMen = _Warrior as IHenchMen;
                    return henchMen.AmountInGroup;
                }

                return null;
            }
        }

        /// <summary>
        /// Gets the increase henchmen command.
        /// </summary>
        /// <value>
        /// The increase henchmen command.
        /// </value>
        public ICommand IncreaseHenchmenCommand => new IncreaseBuyAmount(_Warrior);

        /// <summary>
        /// Gets the show increase decrease buttons.
        /// </summary>
        /// <value>
        /// The show increase decrease buttons.
        /// </value>
        public Visibility ShowIncreaseDecreaseButtons
        {
            get
            {
                if (_Warrior is IHenchMen) { return Visibility.Visible; }
                return Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        public ICommand RemoveWarriorCommand => new RelayCommand(x => BuilderLogicFactory.Instance.WarbandRoster.RemoveWarrior(_Warrior));
        public StatisticsViewModel StatisticsVM { get { return new StatisticsViewModel(_Warrior); } }

        public string WarriorTypeName { get { return _Warrior.TypeName.SplitCamelCasing(); } }
    }
}