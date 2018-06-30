using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Equipment.Weapons.Missile
{
    public class Sling : EquipmentBase, IMisseleWeapon
    {
        public Sling()
        {
            _MisseleWeaponRules.Add(MisseleWeaponRules.FireTwiceAtHalfRange);
        }

        public override int Cost { get; } = 2;

        /// <summary>
        /// Gets the range.
        /// </summary>
        /// <value>
        /// The range.
        /// </value>
        public override int Range { get; } = 18;

        /// <summary>
        /// Gets the strength.
        /// </summary>
        /// <value>
        /// The strength.
        /// </value>
        public override int Strength { get; } = 3;
    }
}