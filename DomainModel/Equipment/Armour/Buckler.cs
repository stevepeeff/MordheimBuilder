using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Equipment.Armour
{
    public class Buckler : EquipmentBase, IArmour
    {
        public override int Cost { get; } = 5;

        public int Save { get; } = NONE;

        public string Description { get; } = "Buckler, no save. Parry";

        public Buckler()
        {
            _ArmourRules.Add(ArmourRules.Parry);
        }
    }
}