using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Equipment.Weapons
{
    public interface IWeapon : IEquipment
    {
        int ArmorSaveModifier { get; }
    }
}