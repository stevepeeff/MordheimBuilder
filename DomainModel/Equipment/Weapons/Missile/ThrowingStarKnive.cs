using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Equipment.Weapons.Missile
{
    public class ThrowingStarKnive : EquipmentBase, IMisseleWeapon
    {
        public override int Cost { get; } = 15;

        /// <summary>
        /// Gets the range.
        /// </summary>
        /// <value>
        /// The range.
        /// </value>
        public override int Range { get; } = 6;

        public override Availabilities Availability { get; } = Availabilities.RARE_5;

        public ThrowingStarKnive()
        {
            _MisseleWeaponRules.Add(MisseleWeaponRules.ThrownWeapon);
        }
    }
}