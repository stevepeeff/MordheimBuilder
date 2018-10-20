using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Equipment.Weapons.Missile
{
    public class HandGun : EquipmentBase, IMisseleWeapon
    {
        public HandGun()
        {
            _MisseleWeaponRules.Add(MisseleWeaponRules.Prepare);
            _MisseleWeaponRules.Add(MisseleWeaponRules.MoveOrFire);
        }

        public override int Cost { get; } = 35;

        /// <summary>
        /// Gets the range.
        /// </summary>
        /// <value>
        /// The range.
        /// </value>
        public override int Range { get; } = 24;

        public override int ArmorSaveModifier { get; } = -2;

        public override int Strength { get; } = 4;

        public override Availability TradeAvailability { get; } = new Availability(Availabilities.RARE_8);
    }
}