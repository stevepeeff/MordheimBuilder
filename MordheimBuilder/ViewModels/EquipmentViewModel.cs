using DomainModel.Equipment;
using DomainModel.Equipment.Armour;
using DomainModel.Equipment.Weapons;
using DomainModel.Equipment.Weapons.CloseCombat;
using DomainModel.Equipment.Weapons.Missile;
using DomainModel.Warbands;
using DomainModel.Warbands.WitchHunters;
using MordheimBuilder.Commands;
using MordheimBuilder.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace MordheimBuilder
{
    public class EquipmentViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EquipmentViewModel"/> class.
        /// </summary>
        /// <param name="warriorViewModel">The warrior view model.</param>
        /// <exception cref="ArgumentNullException">WarriorViewModel is null</exception>
        public EquipmentViewModel(WarriorViewModel warriorViewModel)
        {
            if (warriorViewModel == null) { throw new ArgumentNullException("WarriorViewModel is null"); }
            WarriorViewModel = warriorViewModel;
            Warrior = warriorViewModel.Warrior;
            SetEquipment();

            RemoveEquipmentCommand = new RemoveEquipment(this);
            SelectEquipmentCommand = new SelectEquipment(this);

            foreach (IEquipment equipment in Warrior.AllowedEquipment)
            {
                if (equipment is ICloseCombatWeapon)
                {
                    Weapons.Add(new CloseCombatWeaponViewModel(equipment as ICloseCombatWeapon));
                }
                if (equipment is IMisseleWeapon)
                {
                    MissileWeapons.Add(new MissileWeaponViewModel(equipment as IMisseleWeapon));
                }
                if (equipment is IArmour)
                {
                    Armour.Add(new ArmorViewModel(equipment as IArmour));
                }
            }
            Warrior.PropertiesChanged += Warrior_PropertiesChanged;
        }

        /// <summary>
        /// Gets the Armour.
        /// </summary>
        /// <value>
        /// The armour.
        /// </value>
        public IList<ArmorViewModel> Armour { get; } = new List<ArmorViewModel>();

        /// <summary>
        /// Gets the effects.
        /// </summary>
        /// <value>
        /// The effects.
        /// </value>
        /// <summary>
        /// Gets the equipment costs.
        /// </summary>
        /// <value>
        /// The equipment costs.
        /// </value>
        public int EquipmentCosts { get { return Warrior.EquipmentCosts; } }

        /// <summary>
        /// Gets or sets the equipped weapons.
        /// </summary>
        /// <value>
        /// The equipped weapons.
        /// </value>
        public ObservableCollection<EquipmentSummaryViewModel> EquippedWeapons { get { return WarriorViewModel.EquippedWeapons; } }

        /// <summary>
        /// Gets or sets the missile weapons.
        /// </summary>
        /// <value>
        /// The missile weapons.
        /// </value>
        public IList<MissileWeaponViewModel> MissileWeapons { get; } = new List<MissileWeaponViewModel>();

        /// <summary>
        /// Gets the remove equipment command.
        /// </summary>
        /// <value>
        /// The remove equipment command.
        /// </value>
        public ICommand RemoveEquipmentCommand { get; private set; }

        /// <summary>
        /// Gets the select equipment command.
        /// </summary>
        /// <value>
        /// The select equipment command.
        /// </value>
        public ICommand SelectEquipmentCommand { get; private set; }

        /// <summary>
        /// Gets the total equipment costs.
        /// </summary>
        /// <value>
        /// The total equipment costs.
        /// </value>
        public string TotalEquipmentCosts
        {
            get
            {
                return $"Total Costs {Warrior.EquipmentCosts}";
            }
        }

        public IWarrior Warrior { get; private set; }

        /// <summary>
        /// Gets the warrior view model.
        /// </summary>
        /// <value>
        /// The warrior view model.
        /// </value>
        public WarriorViewModel WarriorViewModel { get; private set; }

        /// <summary>
        /// Gets the weapons.
        /// </summary>
        /// <value>
        /// The weapons.
        /// </value>
        public IList<CloseCombatWeaponViewModel> Weapons { get; } = new List<CloseCombatWeaponViewModel>();

        private void SetEquipment()
        {
            // EquippedWeapons.Add(new EquipmentSummaryViewModel(DummyEquipment.Dummy));

            EquippedWeapons.Clear();
            foreach (IEquipment item in Warrior.Equipment)
            {
                EquippedWeapons.Add(new EquipmentSummaryViewModel(item));
            }
            //if (EquippedWeapons.Count == 0) { }
        }

        private void Warrior_PropertiesChanged(object sender, EventArgs e)
        {
            RaisePropertyChangedEvent(nameof(EquipmentCosts));
            SetEquipment();
        }
    }
}