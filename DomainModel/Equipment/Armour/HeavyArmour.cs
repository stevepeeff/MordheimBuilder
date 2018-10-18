using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Equipment.Armour
{
    public class HeavyArmour : EquipmentBase, IArmour
    {
        public override int Cost { get; } = 50;

        public int Save { get; } = 2;

        public string Description { get; } = "Heavy Armour 5+ Save";

        public HeavyArmour()
        {
            _ArmourRules.Add(ArmourRules.Movement);
        }
    }
}