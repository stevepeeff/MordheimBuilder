﻿namespace DomainModel.Equipment.Weapons.Missile
{
    public class HochlanLongRifle : EquipmentBase, IMisseleWeapon
    {
        public HochlanLongRifle()
        {
            _MisseleWeaponRules.Add(MisseleWeaponRules.PrepareShot);
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

        public override Availability TradeAvailability { get; } = new Availability(Availabilities.RARE_11);
    }
}