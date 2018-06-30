using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Equipment.Weapons.CloseCombat
{
    public class ClubMaceHammer : EquipmentBase, ICloseCombatWeapon
    {
        public override int Cost { get; } = 3;

        public ClubMaceHammer()
        {
            _CloseCombatRules.Add(CloseCombatWeaponRules.Concussion);
        }
    }
}