using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Equipment.Weapons.CloseCombat
{
    public class FightingClaws : EquipmentBase, ICloseCombatWeapon
    {
        public override int Cost { get; } = 35;

        public override Availabilities Availability { get; } = Availabilities.RARE_7;

        public override bool CountsAsPair { get; } = true;

        public FightingClaws()
        {
            _CloseCombatRules.Add(CloseCombatWeaponRules.Pair);
            _CloseCombatRules.Add(CloseCombatWeaponRules.Climb);
            _CloseCombatRules.Add(CloseCombatWeaponRules.Parry);
            _CloseCombatRules.Add(CloseCombatWeaponRules.Cumbersome);
        }
    }
}