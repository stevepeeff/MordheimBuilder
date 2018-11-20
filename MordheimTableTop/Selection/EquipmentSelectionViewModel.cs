using DomainModel.Equipment;
using DomainModel.Equipment.Armour;
using DomainModel.Equipment.Weapons;
using DomainModel.Equipment.Weapons.CloseCombat;
using DomainModel.Warbands;
using DomainModel.Warbands.CultOfThePossessed;
using DomainModel.Warbands.CultOfThePossessed.Mutations;
using MordheimTableTop.Warrior;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

            if (WarriorVM.Warrior is IMutant)
            {
                foreach (var item in MutationsProvider.Instance.Mutations)
                {
                    Mutations.Add(new MutationViewModel(item));
                }
            }
        }

        public List<ArmourViewModel> Armours { get; } = new List<ArmourViewModel>();

        public ICommand BuyEqpuimentCommand => new RelayCommand((parameter) => BuyEquipment(parameter));

        public List<CloseCombatWeaponViewModel> CloseCombatWeapons { get; } = new List<CloseCombatWeaponViewModel>();

        public ObservableCollection<EquipmentViewModel> Equipment { get { return WarriorVM.Equipment; } }

        public List<MissleWeaponViewModel> MisseleWeapons { get; } = new List<MissleWeaponViewModel>();

        public List<MutationViewModel> Mutations { get; } = new List<MutationViewModel>();

        /// <summary>
        /// Gets the show armour selection.
        /// </summary>
        /// <value>
        /// The show armour selection.
        /// </value>
        public Visibility ShowArmourSelection
        {
            get
            {
                if (Armours.Any()) { return Visibility.Visible; }
                return Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Gets the show missile weapon selection.
        /// </summary>
        /// <value>
        /// The show missile weapon selection.
        /// </value>
        public Visibility ShowMissileWeaponSelection
        {
            get
            {
                if (MisseleWeapons.Any()) { return Visibility.Visible; }
                return Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Gets the show mutations selection.
        /// </summary>
        /// <value>
        /// The show mutations selection.
        /// </value>
        public Visibility ShowMutationsSelection
        {
            get
            {
                if (Mutations.Any()) { return Visibility.Visible; }
                return Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Gets the show close combat weapon selection.
        /// </summary>
        /// <value>
        /// The show close combat weapon selection.
        /// </value>
        public Visibility ShowCloseCombatWeaponSelection
        {
            get
            {
                if (CloseCombatWeapons.Any()) { return Visibility.Visible; }
                return Visibility.Collapsed;
            }
        }

        public IWarrior Warrior { get { return WarriorVM.Warrior; } }

        internal WarriorViewModel WarriorVM { get; }

        private void BuyEquipment(object parameter)
        {
            if (parameter is CloseCombatWeaponViewModel)
            {
                var ccWpn = parameter as CloseCombatWeaponViewModel;
                if (Warrior.AddEquipment(ccWpn.CloseCombatWeapon))
                {
                    Equipment.Add(ccWpn);
                }
            }
            if (parameter is MissleWeaponViewModel)
            {
                var mslWpn = parameter as MissleWeaponViewModel;
                if (Warrior.AddEquipment(mslWpn.MisseleWeapon))
                {
                    Equipment.Add(mslWpn);
                }
            }
            if (parameter is ArmourViewModel)
            {
                var armr = parameter as ArmourViewModel;
                if (Warrior.AddEquipment(armr.Armour))
                {
                    Equipment.Add(armr);
                }
            }
            if (parameter is MutationViewModel)
            {
                var mutation = parameter as MutationViewModel;
                if (Warrior.AddMutation(mutation.Mutation))
                {
                    Equipment.Add(mutation);
                }
            }
        }
    }
}