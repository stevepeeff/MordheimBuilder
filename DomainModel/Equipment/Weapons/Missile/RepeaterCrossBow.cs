using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Equipment.Weapons.Missile
{
    public class RepeaterCrossBow : EquipmentBase, IMisseleWeapon
    {
        public override int Cost { get; } = 40;

        public override int Range { get; } = 24;

        public override int ArmorSaveModifier { get; } = -3;

        public override Availability TradeAvailability { get; } = new Availability(Availabilities.RARE_8);

        public RepeaterCrossBow()
        {
            _MisseleWeaponRules.Add(MisseleWeaponRules.FireTwice);
        }
    }
}