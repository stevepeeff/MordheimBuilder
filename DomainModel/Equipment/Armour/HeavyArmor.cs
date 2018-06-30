using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Equipment.Armour
{
    public class HeavyArmor : EquipmentBase, IArmour
    {
        public override int Cost { get; } = 50;

        public int Save { get; } = 2;

        public HeavyArmor()
        {
            _ArmourRules.Add(ArmourRules.Movement);
        }
    }
}