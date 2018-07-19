using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Equipment.Armour
{
    public class LightArmour : EquipmentBase, IArmour
    {
        public int Save { get; } = 1;

        public override int Cost { get; } = 20;

        public string Description { get; } = "Light Armour 6+ Save";
    }
}