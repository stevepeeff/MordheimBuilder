using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Equipment.Armour
{
    public class Barding : EquipmentBase, IArmour
    {
        public override int Cost { get; } = 15;

        public int Save { get; } = 80;

        public override Availabilities Availability { get; } = Availabilities.RARE_8;
    }
}