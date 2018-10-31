using DomainModel.Equipment.Armour;
using DomainModel.Warbands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            Equipment.Add(new ArmourViewModel(new LightArmour()));
        }

        public ObservableCollection<ViewModelBase> Equipment { get; } = new ObservableCollection<ViewModelBase>();

        internal IWarrior Warrior { get; }
    }
}