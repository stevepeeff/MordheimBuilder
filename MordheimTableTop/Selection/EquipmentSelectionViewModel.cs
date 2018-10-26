using DomainModel.Equipment;
using DomainModel.Equipment.Armour;
using DomainModel.Equipment.Weapons;
using DomainModel.Equipment.Weapons.CloseCombat;
using DomainModel.Warbands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            }
        }

        public List<IArmour> Armours { get; } = new List<IArmour>();

        public CloseCombatWeaponViewModel SelectedCloseCombatWeapon { get; set; }

        public List<CloseCombatWeaponViewModel> CloseCombatWeapons { get; } = new List<CloseCombatWeaponViewModel>();
        public List<IMisseleWeapon> MisseleWeapons { get; } = new List<IMisseleWeapon>();
        public IWarrior Warrior { get; }
    }
}