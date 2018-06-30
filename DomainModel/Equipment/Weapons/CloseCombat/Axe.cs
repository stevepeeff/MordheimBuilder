using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Equipment.Weapons.CloseCombat
{
    public class Axe : EquipmentBase, ICloseCombatWeapon
    {
        public override int Cost { get; } = 5;

        public override int ArmorSaveModifier { get; } = -1;

        public Axe()
        {
            _CloseCombatRules.Add(CloseCombatWeaponRules.CuttingEdge);
        }
    }
}