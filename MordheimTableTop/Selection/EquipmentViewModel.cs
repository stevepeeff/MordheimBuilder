using DomainModel.Warbands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordheimTableTop.Selection
{
    internal class EquipmentViewModel : ViewModelBase
    {
        public EquipmentViewModel(IWarrior warrior)
        {
            Warrior = warrior;
        }

        internal IWarrior Warrior { get; }
    }
}