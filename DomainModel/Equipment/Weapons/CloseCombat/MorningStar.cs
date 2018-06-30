using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Equipment.Weapons.CloseCombat
{
    public class MorningStar : EquipmentBase, ICloseCombatWeapon
    {
        public override int Cost { get; } = 15;

        public override int StrengthModifier { get; } = 1;

        public MorningStar()
        {
            _CloseCombatRules.Add(CloseCombatWeaponRules.Heavy);
            _CloseCombatRules.Add(CloseCombatWeaponRules.DifficultToUse);
        }
    }
}