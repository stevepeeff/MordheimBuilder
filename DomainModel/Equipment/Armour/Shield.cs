using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Equipment.Armour
{
    public class Shield : EquipmentBase, IArmour
    {
        public override int Cost { get; } = 5;

        public int Save { get; } = 1;

        public override string Description { get; } = "Shield +1 Save";
    }
}