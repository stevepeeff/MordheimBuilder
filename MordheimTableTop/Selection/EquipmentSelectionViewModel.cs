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
                if (item is IMisseleWeapon) { MisseleWeapons.Add(new MissleWeaponViewModel(item as IMisseleWeapon)); }
                if (item is IArmour) { Armours.Add(new ArmourViewModel(item as IArmour)); }
            }
        }

        public List<ArmourViewModel> Armours { get; } = new List<ArmourViewModel>();

        public List<CloseCombatWeaponViewModel> CloseCombatWeapons { get; } = new List<CloseCombatWeaponViewModel>();
        public List<MissleWeaponViewModel> MisseleWeapons { get; } = new List<MissleWeaponViewModel>();
        public ArmourViewModel SelectedArmour { get; set; }
        public CloseCombatWeaponViewModel SelectedCloseCombatWeapon { get; set; }
        public MissleWeaponViewModel SelectedMissleWeapon { get; set; }
        public IWarrior Warrior { get; }
    }
}