using DomainModel.Warbands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public ICommand RemoveWarriorCommand { get; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        public StatisticsViewModel StatisticsVM { get { return new StatisticsViewModel(_Warrior); } }

        public string WarriorTypeName { get { return _Warrior.TypeName.SplitCamelCasing(); } }
    }
}