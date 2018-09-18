using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Equipment.Weapons.CloseCombat
{
    public class WeepingBlades : EquipmentBase, ICloseCombatWeapon
    {
        public override int Cost { get; } = 50;

        public override Availabilities Availability { get; } = Availabilities.RARE_9;

        public override bool CountsAsPair { get; } = true;

        public WeepingBlades()
        {
            _CloseCombatRules.Add(CloseCombatWeaponRules.Pair);
            _CloseCombatRules.Add(CloseCombatWeaponRules.Venomous);
            _CloseCombatRules.Add(CloseCombatWeaponRules.Parry);
        }
    }
}