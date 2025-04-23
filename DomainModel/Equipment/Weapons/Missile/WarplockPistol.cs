namespace DomainModel.Equipment.Weapons.Missile
{
    public class WarplockPistol : EquipmentBase, IMisseleWeapon

    {
        public WarplockPistol()
        {
            _MisseleWeaponRules.Add(MisseleWeaponRules.FireEveryOtherTurn);
            _MisseleWeaponRules.Add(MisseleWeaponRules.Stealthy);
        }

        /// <summary>
        /// Gets the armor save modifier.
        /// </summary>
        /// <value>
        /// The armor save modifier.
        /// </value>
        public override int ArmorSaveModifier { get; } = -3;

        /// <summary>
        /// Gets the trade availability.
        /// </summary>
        /// <value>
        /// The trade availability.
        /// </value>
        public override Availability TradeAvailability { get; } = new Availability(Availabilities.RARE_11);

        /// <summary>
        /// Gets the cost.
        /// </summary>
        /// <value>
        /// The cost.
        /// </value>
        public override int Cost { get; } = 35;

        /// <summary>
        /// Gets the range.
        /// </summary>
        /// <value>
        /// The range.
        /// </value>
        public override int Range { get; } = 8;

        /// <summary>
        /// Gets the strength.
        /// </summary>
        /// <value>
        /// The strength.
        /// </value>
        public override int Strength { get; } = 5;
    }
}