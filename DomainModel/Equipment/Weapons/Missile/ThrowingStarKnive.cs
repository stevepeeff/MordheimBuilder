﻿namespace DomainModel.Equipment.Weapons.Missile
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

        public override Availability TradeAvailability { get; } = new Availability(Availabilities.RARE_5);

        public ThrowingStarKnive()
        {
            _MisseleWeaponRules.Add(MisseleWeaponRules.ThrownWeapon);
        }
    }
}