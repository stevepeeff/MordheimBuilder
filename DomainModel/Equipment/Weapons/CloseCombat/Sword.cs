using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Equipment.Weapons.CloseCombat
{
    public class Sword : EquipmentBase, ICloseCombatWeapon
    {
        public override int Cost { get; } = 10;

        public Sword()
        {
            _CloseCombatRules.Add(CloseCombatWeaponRules.Parry);
        }
    }
}