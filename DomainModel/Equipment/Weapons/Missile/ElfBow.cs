namespace DomainModel.Equipment.Weapons.Missile
{
    public class ElfBow : EquipmentBase, IMisseleWeapon
    {
        public override int Cost { get; } = 35;

        public override int Range { get; } = 36;

        public override int ArmorSaveModifier { get; } = -1;

        public override int Strength { get; } = 3;

        public override Availability TradeAvailability { get; } = new Availability(Availabilities.RARE_12);

        public ElfBow()
        {
            VariableCost = new VariabeleCosts(6, 3);
        }
    }
}