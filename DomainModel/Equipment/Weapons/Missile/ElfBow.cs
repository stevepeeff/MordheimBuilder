using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Equipment.Weapons.Missile
{
    public class ElfBow : EquipmentBase, IMisseleWeapon
    {
        public override int Cost { get; } = 30;

        public override int Range { get; } = 36;

        public override int ArmorSaveModifier { get; } = -1;

        public override int Strength { get; } = 3;

        public override Availabilities Availability { get; } = Availabilities.RARE_12;

        public ElfBow()
        {
            VariableCost = new VariabeleCosts(6, 3);
        }
    }
}