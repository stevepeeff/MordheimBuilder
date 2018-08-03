using DomainModel.Equipment.Armour;
using DomainModel.Equipment.Weapons.CloseCombat;
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

        private List<IEquipment> _AllEquipment = new List<IEquipment>();

        public void AddEquipment(IEquipment equipment)
        {
            if (_AllEquipment.FirstOrDefault(x => x.Name.Equals(equipment.Name)) == null)
            {
                _AllEquipment.Add(equipment);
            }
        }

        public IEquipment GetEquipment(string name)
        {
            return _AllEquipment.Single(x => x.Name.Equals(name));
        }
    }
}