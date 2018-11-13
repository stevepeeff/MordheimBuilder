using DomainModel.Equipment;
using DomainModel.Equipment.Armour;
using DomainModel.Equipment.Weapons;
using DomainModel.Equipment.Weapons.CloseCombat;
using DomainModel.Warbands;
using MordheimTableTop.Warrior;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MordheimTableTop.Selection
{
    public class EquipmentSelectionViewModel : ViewModelBase
    {
        internal EquipmentSelectionViewModel(WarriorViewModel warrior)
        {
            WarriorVM = warrior;

            foreach (IEquipment item in Warrior.AllowedEquipment)
            {
                if (item is ICloseCombatWeapon) { CloseCombatWeapons.Add(new CloseCombatWeaponViewModel(item as ICloseCombatWeapon)); }
                if (item is IMisseleWeapon) { MisseleWeapons.Add(new MissleWeaponViewModel(item as IMisseleWeapon)); }
                if (item is IArmour) { Armours.Add(new ArmourViewModel(item as IArmour)); }
            }
        }

        public List<ArmourViewModel> Armours { get; } = new List<ArmourViewModel>();
        public List<CloseCombatWeaponViewModel> CloseCombatWeapons { get; } = new List<CloseCombatWeaponViewModel>();
        public List<MissleWeaponViewModel> MisseleWeapons { get; } = new List<MissleWeaponViewModel>();

        public ObservableCollection<EquipmentViewModel> Equipment { get { return WarriorVM.Equipment; } }

        public ICommand BuyEqpuimentCommand => new RelayCommand((parameter) => BuyEquipment(parameter));

        private void BuyEquipment(object parameter)
        {
            if (parameter is CloseCombatWeaponViewModel)
            {
                var ccWpn = parameter as CloseCombatWeaponViewModel;
                Warrior.AddEquipment(ccWpn.CloseCombatWeapon);
                Equipment.Add(ccWpn);
            }
            if (parameter is MissleWeaponViewModel)
            {
                var mslWpn = parameter as MissleWeaponViewModel;
                Warrior.AddEquipment(mslWpn.MisseleWeapon);
                Equipment.Add(mslWpn);
            }
            if (parameter is ArmourViewModel)
            {
                var armr = parameter as ArmourViewModel;
                Warrior.AddEquipment(armr.Armour);
                Equipment.Add(armr);
            }
        }

        internal WarriorViewModel WarriorVM { get; }

        public IWarrior Warrior { get { return WarriorVM.Warrior; } }
    }
}