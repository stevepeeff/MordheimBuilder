using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Equipment.Weapons.Missile
{
    public class LongBow : EquipmentBase, IMisseleWeapon
    {
        public override int Cost { get; } = 15;

        public override int Range { get; } = 30;

        public override int Strength { get; } = 3;
    }
}