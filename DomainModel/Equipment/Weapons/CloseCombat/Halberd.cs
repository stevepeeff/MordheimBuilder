using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Equipment.Weapons.CloseCombat
{
    public class Halberd : EquipmentBase, ICloseCombatWeapon
    {
        public override int Cost { get; } = 10;

        public override int StrengthModifier { get; } = 1;

        public Halberd()
        {
            _CloseCombatRules.Add(CloseCombatWeaponRules.TwoHandend);
        }
    }
}