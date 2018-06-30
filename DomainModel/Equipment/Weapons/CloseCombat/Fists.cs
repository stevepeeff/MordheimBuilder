using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Equipment.Weapons.CloseCombat
{
    /// <summary>
    /// Applies to warriors who lost their weapons.
    /// Zombies, animals, etc, ignore these rules
    /// </summary>
    public class Fists : EquipmentBase, ICloseCombatWeapon
    {
        public override int Cost { get; }

        public override int ArmorSaveModifier { get; } = 1;
    }
}