using DomainModel.Equipment;
using DomainModel.Equipment.Armour;
using DomainModel.Equipment.Weapons;
using DomainModel.Equipment.Weapons.CloseCombat;
using DomainModel.Warbands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MordheimTableTop.Selection
{
    internal class EquipmentSelectionViewModel : ViewModelBase
    {
        public EquipmentSelectionViewModel(IWarrior warrior)
        {
            Warrior = warrior;

            foreach (IEquipment item in Warrior.AllowedEquipment)
            {
                if (item is ICloseCombatWeapon) { CloseCombatWeapons.Add(new CloseCombatWeaponViewModel(item as ICloseCombatWeapon)); }
                if (item is IMisseleWeapon) { MisseleWeapons.Add(new MissleWeaponViewModel(item as IMisseleWeapon)); }
                if (item is IArmour) { Armours.Add(new ArmourViewModel(item as IArmour)); }
            }
            Equipment.Add(new ArmourViewModel(new LightArmour()));
        }

        public List<ArmourViewModel> Armours { get; } = new List<ArmourViewModel>();
        public List<CloseCombatWeaponViewModel> CloseCombatWeapons { get; } = new List<CloseCombatWeaponViewModel>();
        public List<MissleWeaponViewModel> MisseleWeapons { get; } = new List<MissleWeaponViewModel>();

        /// <summary>
        /// Gets or sets the selected armour.
        /// </summary>
        /// <value>
        /// The selected armour.
        /// </value>
        public ArmourViewModel SelectedArmour { get; set; }

        /// <summary>
        /// Gets or sets the selected close combat weapon.
        /// </summary>
        /// <value>
        /// The selected close combat weapon.
        /// </value>
        public CloseCombatWeaponViewModel SelectedCloseCombatWeapon { get; set; }

        /// <summary>
        /// Gets or sets the selected missle weapon.
        /// </summary>
        /// <value>
        /// The selected missle weapon.
        /// </value>
        public MissleWeaponViewModel SelectedMissleWeapon { get; set; }

        public ObservableCollection<ViewModelBase> Equipment { get; } = new ObservableCollection<ViewModelBase>();

        public ICommand BuyEqpuimentCommand => new RelayCommand((parameter) => BuyEquipment(parameter));

        private void BuyEquipment(object parameter)
        {
        }

        public IWarrior Warrior { get; }
    }
}