using DomainModel.Equipment.Armour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Equipment
{
    internal class EquipmentProvider
    {
        public static EquipmentProvider Instance { get; } = new EquipmentProvider();

        private EquipmentProvider()
        {
        }

        public IEquipment GetEquipment(string name)
        {
            return new Shield();
        }
    }
}