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

        public override Availability TradeAvailability { get; } = new Availability(Availabilities.RARE_7);

        public FightingClaws()
        {
            _CloseCombatRules.Add(CloseCombatWeaponRules.Pair);
            _CloseCombatRules.Add(CloseCombatWeaponRules.Climb);
            _CloseCombatRules.Add(CloseCombatWeaponRules.Parry);
            _CloseCombatRules.Add(CloseCombatWeaponRules.Cumbersome);
        }
    }
}