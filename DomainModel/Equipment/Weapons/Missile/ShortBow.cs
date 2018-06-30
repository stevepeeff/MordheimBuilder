using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Equipment.Weapons.Missile
{
    public class ShortBow : EquipmentBase, IMisseleWeapon
    {
        public override int Cost { get; } = 5;

        /// <summary>
        /// Gets the range.
        /// </summary>
        /// <value>
        /// The range.
        /// </value>
        public override int Range { get; } = 24;

        public override int Strength { get; } = 3;
    }
}