using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Equipment.Weapons.Missile
{
    public class HochlanLongRifle : EquipmentBase, IMisseleWeapon
    {
        public HochlanLongRifle()
        {
            _MisseleWeaponRules.Add(MisseleWeaponRules.Prepare);
            _MisseleWeaponRules.Add(MisseleWeaponRules.MoveOrFire);
            _MisseleWeaponRules.Add(MisseleWeaponRules.PickTarget);
        }

        public override int Cost { get; } = 200;

        /// <summary>
        /// Gets the range.
        /// </summary>
        /// <value>
        /// The range.
        /// </value>
        public override int Range { get; } = 48;

        public override int ArmorSaveModifier { get; } = -2;

        public override int Strength { get; } = 4;

        public override Availabilities Availability { get; } = Availabilities.RARE_11;
    }
}