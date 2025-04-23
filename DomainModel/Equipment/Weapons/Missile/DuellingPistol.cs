namespace DomainModel.Equipment.Weapons.Missile
{
    public class DuellingPistol : EquipmentBase, IMisseleWeapon
    {
        public override int Cost { get; } = 30;

        /// <summary>
        /// Gets the range.
        /// </summary>
        /// <value>
        /// The range.
        /// </value>
        public override int Range { get; } = 10;

        public override int ArmorSaveModifier { get; } = -2;

        public override int Strength { get; } = 4;

        public override Availability TradeAvailability { get; } = new Availability(Availabilities.RARE_10);

        public DuellingPistol()
        {
            _MisseleWeaponRules.Add(MisseleWeaponRules.Accuracy);
            _MisseleWeaponRules.Add(MisseleWeaponRules.PrepareShot);
            _MisseleWeaponRules.Add(MisseleWeaponRules.HandToHand);
        }
    }
}